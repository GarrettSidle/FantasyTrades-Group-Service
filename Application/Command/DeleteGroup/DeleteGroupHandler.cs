using MediatR;
using FantasyTradesGroupService.Application.Interfaces;
using FantasyTradesGroupService.Domain.Exceptions;

namespace FantasyTradesGroupService.Application.Command.DeleteGroup;

public class DeleteGroupHandler : IRequestHandler<DeleteGroupCommand>
{
    private readonly IGroupRepository _repo;

    public DeleteGroupHandler(IGroupRepository repo)
    {
        _repo = repo;
    }

    public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _repo.GetByIdAsync(request.GroupId);
        if (group == null)
            throw new DomainException("Group not found.");

        await _repo.DeleteAsync(group);
        await _repo.SaveChangesAsync();

        return Unit.Value;
    }
}