using MediatR;
using FantasyTradesGroupService.Application.Interfaces;
using FantasyTradesGroupService.Domain.Dtos;

namespace FantasyTradesGroupService.Application.Query.GetGroupById;

public class GetGroupByIdHandler : IRequestHandler<GetGroupByIdQuery, GroupDto?>
{
    private readonly IGroupRepository _repo;

    public GetGroupByIdHandler(IGroupRepository repo)
    {
        _repo = repo;
    }

    public async Task<GroupDto?> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var group = await _repo.GetByIdAsync(request.GroupId);
        return group == null ? null : GroupDto.FromEntity(group);
    }
}
