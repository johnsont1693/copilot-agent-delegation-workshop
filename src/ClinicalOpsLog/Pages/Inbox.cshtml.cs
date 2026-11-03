using ClinicalOpsLog.Models;
using ClinicalOpsLog.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClinicalOpsLog.Pages;

public class InboxModel : PageModel
{
    private readonly IMessageInboxService _inbox;

    public InboxModel(IMessageInboxService inbox) => _inbox = inbox;

    public IReadOnlyList<ClinicalMessage> Messages { get; private set; } = [];
    public int TotalCount { get; private set; }
    public int UnacknowledgedCount { get; private set; }

    public void OnGet()
    {
        var all = _inbox.GetMessages();
        Messages = all.OrderByDescending(m => m.ReceivedAt).ToList();
        TotalCount = all.Count;
        UnacknowledgedCount = all.Count(m => !m.IsAcknowledged);
    }
}
