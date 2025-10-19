using MediatR;
using FantasyTradesGroupService.Domain.Dtos;

namespace FantasyTradesGroupService.Application.Query.GetGroupsByMemberId;

public record GetGroupsByMemberIdQuery(Guid UserId) : IRequest<IEnumerable<GroupDto>>;