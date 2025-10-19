using System;
using System.Collections.Generic;
using FantasyTradesGroupService.Domain.Entities;

namespace FantasyTradesGroupService.Application.Query.GetGroupById;

public class GroupDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public Guid CreatedByUserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<GroupMemberDto> Members { get; set; } = new List<GroupMemberDto>();

    public static GroupDto FromEntity(Group group)
    {
        return new GroupDto
        {
            Id = group.Id,
            Name = group.Name,
            Code = group.Code.ToString(),
            CreatedByUserId = group.CreatedByUserId,
            CreatedAt = group.CreatedAt,
            Members = group.Members.Select(m => GroupMemberDto.FromEntity(m))
        };
    }
}

public class GroupMemberDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime JoinedAt { get; set; }

    public static GroupMemberDto FromEntity(GroupMember member)
    {
        return new GroupMemberDto
        {
            Id = member.Id,
            UserId = member.UserId,
            Username = member.Username,
            Role = member.Role,
            JoinedAt = member.JoinedAt
        };
    }
}
