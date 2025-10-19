// Application/Commands/CreateGroup/CreateGroupHandler.cs
using MediatR;
using FantasyTradesGroupService.Domain.Entities;
using FantasyTradesGroupService.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace FantasyTradesGroupService.Application.Command.CreateGroup;

public class CreateGroupHandler : IRequestHandler<CreateGroupCommand, Guid>
{
    private readonly IGroupRepository _repo;

    public CreateGroupHandler(IGroupRepository repo)
    {
        _repo = repo;
    }

    public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = new Group(request.Name, request.CreatorUserId);
        group.AddMember(request.CreatorUserId, request.CreatorUsername, "Creator");

        await _repo.AddAsync(group);
        await _repo.SaveChangesAsync();

        return group.Id;
    }
}
