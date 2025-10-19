using MediatR;
using FantasyTradesGroupService.Application.Interfaces;
using FantasyTradesGroupService.Domain.Dtos;

namespace FantasyTradesGroupService.Application.Query.GetGroupByCode;

public class GetGroupByCodeHandler : IRequestHandler<GetGroupByCodeQuery, GroupDto?>
{
    private readonly IGroupRepository _repo;

    public GetGroupByCodeHandler(IGroupRepository repo)
    {
        _repo = repo;
    }

    public async Task<GroupDto?> Handle(GetGroupByCodeQuery request, CancellationToken cancellationToken)
    {
        var group = await _repo.GetByCodeAsync(request.Code);
        return group == null ? null : GroupDto.FromEntity(group);
    }
}