using MediatR;

namespace FantasyTradesGroupService.Application.Command.AddGroupMember;

public record AddGroupMemberCommand(
    Guid GroupId,
    Guid UserId,
    string Username,
    string Role = "Member"
) : IRequest;