using ClinicalOpsLog.Models;

namespace ClinicalOpsLog.Services;

/// <summary>
/// Synthetic seed data for workshop use.
/// All names, identifiers, and content are fabricated and do not represent real patients or clinical events.
/// </summary>
internal static class SeedData
{
    internal static readonly IReadOnlyList<ClinicalMessage> Messages = new[]
    {
        new ClinicalMessage(
            Guid.Parse("11111111-0000-0000-0000-000000000001"),
            "Equipment calibration overdue",
            "Infusion pump unit 4-B is past its scheduled calibration window.",
            MessagePriority.High,
            DateTimeOffset.UtcNow.AddHours(-2),
            IsAcknowledged: false),

        new ClinicalMessage(
            Guid.Parse("11111111-0000-0000-0000-000000000002"),
            "Shift handoff summary available",
            "Night shift summary for Unit 7 is ready for review.",
            MessagePriority.Medium,
            DateTimeOffset.UtcNow.AddHours(-5),
            IsAcknowledged: true),

        new ClinicalMessage(
            Guid.Parse("11111111-0000-0000-0000-000000000003"),
            "Routine supply restock confirmation",
            "PPE restock for supply room C completed.",
            MessagePriority.Low,
            DateTimeOffset.UtcNow.AddHours(-8),
            IsAcknowledged: true),

        new ClinicalMessage(
            Guid.Parse("11111111-0000-0000-0000-000000000004"),
            "Critical alert: ventilator maintenance required",
            "Ventilator unit 2-A has triggered a maintenance alert. Do not assign until serviced.",
            MessagePriority.Critical,
            DateTimeOffset.UtcNow.AddMinutes(-30),
            IsAcknowledged: false),

        new ClinicalMessage(
            Guid.Parse("11111111-0000-0000-0000-000000000005"),
            "Staff scheduling update",
            "Revised coverage schedule for the weekend posted in the staff portal.",
            MessagePriority.Medium,
            DateTimeOffset.UtcNow.AddHours(-12),
            IsAcknowledged: false),
    };
}
