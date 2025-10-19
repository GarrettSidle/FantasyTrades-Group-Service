using MediatR;
using FluentValidation;
using FantasyTradesGroupService.Domain.Exceptions;
using FantasyTradesGroupService.Application.Interfaces;

namespace FantasyTradesGroupService.Application.Command.AddGroupMember;

public class AddGroupMemberHandler : IRequestHandler<AddGroupMemberCommand, Unit>
{
    private readonly IGroupRepository _repo;

    public AddGroupMemberHandler(IGroupRepository repo)
    {
        _repo = repo;
    }

    public async Task<Unit> Handle(AddGroupMemberCommand request, CancellationToken cancellationToken)
    {
        var group = await _repo.GetByIdAsync(request.GroupId);
        
        if (group == null)
            throw new DomainException("Group not found.");

        // Check for duplicate membership
        if (group.Members.Any(m => m.UserId == request.UserId))
            throw new DomainException("User already in group.");

        var member = new FantasyTradesGroupService.Domain.Entities.GroupMember(group.Id, request.UserId, request.Username, request.Role);
        await _repo.AddMemberAsync(member);
        await _repo.SaveChangesAsync();

        return Unit.Value;
    }
}