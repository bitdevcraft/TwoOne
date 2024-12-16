using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwoOne.Domain.Common.Auditable;

namespace TwoOne.Persistence.Configurations.Audits;

internal sealed class AuditEntryConfiguration : IEntityTypeConfiguration<AuditEntry>
{
    public void Configure(EntityTypeBuilder<AuditEntry> builder)
    {
        builder.ToTable("AuditEntries", "audit");

        builder.HasKey(x => x.Id);
    }
}
