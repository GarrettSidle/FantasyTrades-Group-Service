using MediatR;
using FantasyTradesGroupService.Domain.Dtos;

namespace FantasyTradesGroupService.Application.Query.GetGroupById;

public record GetGroupByIdQuery(Guid GroupId) : IRequest<GroupDto?>;
