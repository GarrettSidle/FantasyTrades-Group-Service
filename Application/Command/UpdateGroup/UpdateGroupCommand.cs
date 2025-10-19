using MediatR;

namespace FantasyTradesGroupService.Application.Command.UpdateGroup;

public record UpdateGroupCommand(Guid GroupId, string Name) : IRequest;