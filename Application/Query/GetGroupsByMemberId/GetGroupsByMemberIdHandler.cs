using MediatR;
using FantasyTradesGroupService.Application.Interfaces;
using FantasyTradesGroupService.Domain.Dtos;

namespace FantasyTradesGroupService.Application.Query.GetGroupsByMemberId;

public class GetGroupsByMemberIdHandler : IRequestHandler<GetGroupsByMemberIdQuery, IEnumerable<GroupDto>>
{
    private readonly IGroupRepository _repo;

    public GetGroupsByMemberIdHandler(IGroupRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<GroupDto>> Handle(GetGroupsByMemberIdQuery request, CancellationToken cancellationToken)
    {
        var groups = await _repo.GetGroupsByMemberIdAsync(request.UserId);
        return groups.Select(g => GroupDto.FromEntity(g));
    }
}