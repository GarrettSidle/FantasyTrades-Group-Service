using MediatR;

namespace FantasyTradesGroupService.Application.Command.DeleteGroup;

public record DeleteGroupCommand(Guid GroupId) : IRequest;