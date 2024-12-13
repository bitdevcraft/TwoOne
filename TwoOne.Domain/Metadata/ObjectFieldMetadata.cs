using TwoOne.Domain.Common;
using TwoOne.Domain.Entities.Users;

namespace TwoOne.Domain.Metadata;

public class ObjectFieldMetadata : BaseEntity , IAuditableEntity
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool IsPrimaryKey { get; set; }

    public bool IsRequired { get; set; }

    public bool IsCollection { get; set; }

    public bool IsLookup { get; set; }

    public string? RelatedObject { get; set; }

    public ObjectMetadata? ObjectMetadata { get; set; }

    public string? ObjectMetadataId { get; set; }
    
    // Auditable
    public DateTime? CreatedAt { get; set; }
    public User? CreatedBy { get; set; }
    public string? CreatedById { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public User? UpdatedBy { get; set; }
    public string? UpdatedById { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public User? DeletedBy { get; set; }
    public string? DeletedById { get; set; }
}