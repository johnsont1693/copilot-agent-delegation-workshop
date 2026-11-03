using ClinicalOpsLog.Models;
using ClinicalOpsLog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClinicalOpsLog.Pages;

public class InboxModel : PageModel
{
    private readonly IMessageInboxService _inbox;

    public InboxModel(IMessageInboxService inbox) => _inbox = inbox;

    [BindProperty(SupportsGet = true)]
    public MessagePriority? Priority { get; set; }

    public IReadOnlyList<ClinicalMessage> Messages { get; private set; } = [];
    public int TotalCount { get; private set; }
    public int UnacknowledgedCount { get; private set; }

    public void OnGet()
    {
        if (Priority.HasValue && !Enum.IsDefined(Priority.Value))
        {
            Priority = null;
        }

        var all = _inbox.GetMessages(Priority);
        Messages = all.OrderByDescending(m => m.ReceivedAt).ToList();
        TotalCount = all.Count;
        UnacknowledgedCount = all.Count(m => !m.IsAcknowledged);
    }
}
