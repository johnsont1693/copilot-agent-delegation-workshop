using ClinicalOpsLog.Models;

namespace ClinicalOpsLog.Services;

public interface IMessageInboxService
{
    IReadOnlyList<ClinicalMessage> GetMessages();
    ClinicalMessage? GetById(Guid id);
    void Acknowledge(Guid id);
}

/// <summary>
/// In-memory implementation for workshop demonstration purposes.
/// All data is synthetic. Replace with a real data source in production.
/// </summary>
public sealed class MessageInboxService : IMessageInboxService
{
    private readonly List<ClinicalMessage> _messages = SeedData.Messages.ToList();

    public IReadOnlyList<ClinicalMessage> GetMessages() => _messages.AsReadOnly();

    public ClinicalMessage? GetById(Guid id) =>
        _messages.FirstOrDefault(m => m.Id == id);

    public void Acknowledge(Guid id)
    {
        var index = _messages.FindIndex(m => m.Id == id);
        if (index >= 0)
        {
            _messages[index] = _messages[index] with { IsAcknowledged = true };
        }
    }
}
