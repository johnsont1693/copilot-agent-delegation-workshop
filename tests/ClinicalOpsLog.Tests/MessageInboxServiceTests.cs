using ClinicalOpsLog.Models;
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

        messages.Should().NotBeEmpty();
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
