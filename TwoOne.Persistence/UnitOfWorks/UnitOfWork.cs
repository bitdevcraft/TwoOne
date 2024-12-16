using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TwoOne.Domain.Common;
using TwoOne.Domain.Common.Auditable;
using TwoOne.Domain.Common.Repositories;

namespace TwoOne.Persistence.UnitOfWorks;

internal sealed class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;

    async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
    {
        UpdateAuditableEntities();

        List<EntityAuditInformation> entityAuditInformation = BeforeSaveChanges();
        //var userId = await Users.Select(x => x.Id).FirstOrDefaultAsync(cancellationToken);
        int returnValue = await _dbContext.SaveChangesAsync(cancellationToken);

        bool success = returnValue > 0;

        if (success is not true)
        {
            return returnValue;
        }

        //if all changes are saved then only create audit
        foreach (EntityAuditInformation item in entityAuditInformation)
        {
            dynamic entity = item.Entity;
            var changes = (List<AuditEntry>)item.Changes;

            if (changes.Count == 0)
            {
                continue;
            }

            Audit audit =
                new()
                {
                    TableName = item.TableName,
                    RecordId = entity.Id,
                    ChangeDate = DateTime.UtcNow,
                    Operation = item.OperationType,
                    Changes = changes,
                    //ChangedById = userId // LoggedIn user Id
                };

            _ = await _dbContext.AddAsync(audit, cancellationToken);
        }

        //Save audit data
        await _dbContext.SaveChangesAsync(cancellationToken);

        return returnValue;
    }

    private void UpdateAuditableEntities()
    {
        IEnumerable<EntityEntry<IAuditableEntity>> entries =
            _dbContext.ChangeTracker.Entries<IAuditableEntity>();

        foreach (EntityEntry<IAuditableEntity> entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property(a => a.CreatedAt).CurrentValue = DateTime.UtcNow;
            }

            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Property(a => a.UpdatedAt).CurrentValue = DateTime.UtcNow;
            }

            if (entityEntry.State == EntityState.Deleted)
            {
                entityEntry.Property(a => a.DeletedAt).CurrentValue = DateTime.UtcNow;
                entityEntry.Property(a => a.IsDeleted).CurrentValue = true;
            }
        }
    }

    private List<EntityAuditInformation> BeforeSaveChanges()
    {
        List<EntityAuditInformation> entityAuditInformation = [];

        IEnumerable<EntityEntry> entityEntries = _dbContext
            .ChangeTracker.Entries()
            .Where(x => x.State != EntityState.Unchanged);

        foreach (EntityEntry entityEntry in entityEntries)
        {
            dynamic entity = entityEntry.Entity;
            bool isAdd = entityEntry.State == EntityState.Added;
            List<AuditEntry> changes = [];

            foreach (PropertyEntry property in entityEntry.Properties)
            {
                if (isAdd && property.CurrentValue == null)
                {
                    continue;
                }

                if (
                    property.IsModified
                    && Equals(property.CurrentValue, property.OriginalValue)
                )
                {
                    continue;
                }

                if (property.Metadata.Name == "Id")
                {
                    continue;
                }

                changes.Add(
                    new AuditEntry()
                    {
                        FieldName = property.Metadata.Name,
                        NewValue = property.CurrentValue?.ToString(),
                        OldValue = isAdd ? null : property.OriginalValue?.ToString()
                    }
                );
            }

            entityAuditInformation.Add(
                new EntityAuditInformation()
                {
                    Entity = entity,
                    TableName = entityEntry.Metadata.GetTableName() ?? entity.GetType().Name,
                    State = entityEntry.State,
                    IsDeleteChanged = false,
                    Changes = changes
                }
            );
        }

        return entityAuditInformation;
    }
}
