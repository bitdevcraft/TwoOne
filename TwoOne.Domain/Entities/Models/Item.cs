using TwoOne.Domain.Common;
using TwoOne.Domain.Entities.Users;

namespace TwoOne.Domain.Entities.Models;

public class Item : BaseEntity , IAuditableEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Sku { get; set; }
    public string? Category { get; set; }
    
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