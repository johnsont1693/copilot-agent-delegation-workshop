using ClinicalOpsLog.Models;
using ClinicalOpsLog.Pages;
using ClinicalOpsLog.Services;
using FluentAssertions;
using Xunit;

namespace ClinicalOpsLog.Tests;

public sealed class MessageInboxServiceTests
{
    private readonly MessageInboxService _sut = new();

    [Fact]
    public void GetMessages_ReturnsAllSeedMessages()
    {
        var messages = _sut.GetMessages();

        messages.Should().HaveCount(5);
    }

    [Fact]
    public void GetMessages_WithCriticalPriority_ReturnsOnlyCriticalMessages()
    {
        var messages = _sut.GetMessages(MessagePriority.Critical);

        messages.Should().NotBeEmpty();
        messages.Should().OnlyContain(message => message.Priority == MessagePriority.Critical);
    }

    [Fact]
    public void GetMessages_WithHighPriority_ReturnsOnlyHighMessages()
    {
        var messages = _sut.GetMessages(MessagePriority.High);

        messages.Should().NotBeEmpty();
        messages.Should().OnlyContain(message => message.Priority == MessagePriority.High);
    }

    [Fact]
    public void OnGet_WithSelectedPriority_PassesPriorityToService()
    {
        var page = new InboxModel(_sut) { Priority = MessagePriority.Critical };

        page.OnGet();

        page.Messages.Should().NotBeEmpty();
        page.Messages.Should().OnlyContain(message => message.Priority == MessagePriority.Critical);
    }

    [Fact]
    public void OnGet_WithInvalidPriority_ShowsAllMessages()
    {
        var page = new InboxModel(_sut) { Priority = (MessagePriority)999 };

        page.OnGet();

        page.Priority.Should().BeNull();
        page.Messages.Should().BeEquivalentTo(_sut.GetMessages());
    }

    [Fact]
    public void GetById_WithKnownId_ReturnsCorrectMessage()
    {
        var knownId = Guid.Parse("11111111-0000-0000-0000-000000000001");

        var result = _sut.GetById(knownId);

        result.Should().NotBeNull();
        result!.Priority.Should().Be(MessagePriority.High);
    }

    [Fact]
    public void GetById_WithUnknownId_ReturnsNull()
    {
        var result = _sut.GetById(Guid.NewGuid());

        result.Should().BeNull();
    }

    [Fact]
    public void Acknowledge_SetsIsAcknowledgedTrue()
    {
        var id = Guid.Parse("11111111-0000-0000-0000-000000000001");

        _sut.Acknowledge(id);

        _sut.GetById(id)!.IsAcknowledged.Should().BeTrue();
    }

    [Fact]
    public void Acknowledge_WithUnknownId_DoesNotThrow()
    {
        var act = () => _sut.Acknowledge(Guid.NewGuid());

        act.Should().NotThrow();
    }
}
