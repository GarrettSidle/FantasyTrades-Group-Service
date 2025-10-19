using MediatR;
using FantasyTradesGroupService.Application.Interfaces;
using FantasyTradesGroupService.Domain.Exceptions;

namespace FantasyTradesGroupService.Application.Command.UpdateGroup;

public class UpdateGroupHandler : IRequestHandler<UpdateGroupCommand>
{
    private readonly IGroupRepository _repo;

    public UpdateGroupHandler(IGroupRepository repo)
    {
        _repo = repo;
    }

    public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _repo.GetByIdAsync(request.GroupId);
        if (group == null)
            throw new DomainException("Group not found.");

        group.UpdateName(request.Name);
        group.UpdateDates(request.DraftDate, request.EndDate);
        await _repo.SaveChangesAsync();

        return Unit.Value;
    }
}