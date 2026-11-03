namespace ClinicalOpsLog.Models;

public enum MessagePriority
{
    Low,
    Medium,
    High
}

/// <summary>All data in this model is synthetic and does not represent real patient or clinical information.</summary>
public record ClinicalMessage(
    Guid Id,
    string Subject,
    string Body,
    MessagePriority Priority,
    DateTimeOffset ReceivedAt,
    bool IsAcknowledged
);
