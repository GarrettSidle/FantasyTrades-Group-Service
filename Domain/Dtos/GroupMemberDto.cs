using System;
using FantasyTradesGroupService.Domain.Entities;

namespace FantasyTradesGroupService.Domain.Dtos;

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