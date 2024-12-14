using Microsoft.AspNetCore.Identity;

using TwoOne.Domain.Common;
using TwoOne.Domain.Entities.Authorizations.Roles;
using TwoOne.Domain.Entities.ValueObjects;

namespace TwoOne.Domain.Entities.Users;

public class User : IdentityUser, IAuditableEntity
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Mobile { get; set; }
    
    // Role
    public Role? Role { get; set; }
    public string? RoleId { get; set; }
    
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