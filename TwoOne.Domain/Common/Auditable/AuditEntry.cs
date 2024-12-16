using System.ComponentModel.DataAnnotations.Schema;

namespace TwoOne.Domain.Common.Auditable;

public class AuditEntry : BaseEntity
{
    public string? FieldName { get; init; }

    public string? OldValue { get; init; }
    public string? NewValue { get; init; }

    [ForeignKey(nameof(Audit))] public int AuditId { get; init; }
    public Audit? Audit { get; init; }
}
