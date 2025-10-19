using MediatR;
using FantasyTradesGroupService.Domain.Dtos;

namespace FantasyTradesGroupService.Application.Query.GetGroupByCode;

public record GetGroupByCodeQuery(string Code) : IRequest<GroupDto?>;