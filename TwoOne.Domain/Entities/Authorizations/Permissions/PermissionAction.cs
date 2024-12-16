using TwoOne.Domain.Common;

namespace TwoOne.Domain.Entities.Authorizations.Permissions;

public class PermissionAction : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}
