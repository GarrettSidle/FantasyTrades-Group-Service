// Application/Commands/CreateGroup/CreateGroupCommand.cs
using MediatR;
using System;

namespace FantasyTradesGroupService.Application.Command.CreateGroup;

public record CreateGroupCommand(string Name, Guid CreatorUserId, string CreatorUsername) : IRequest<Guid>;
