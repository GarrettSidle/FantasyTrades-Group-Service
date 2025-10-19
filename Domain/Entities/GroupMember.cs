using System;
using FantasyTradesGroupService.Domain.Entities;

namespace FantasyTradesGroupService.Domain.Entities
{
    public class GroupMember
    {
        public Guid Id { get; set; }                    // Unique ID for this membership
        public Guid GroupId { get; set; }               // FK → Group
        public Guid UserId { get; set; }                // FK → User (from Auth service)
        public string Username { get; set; } = string.Empty; // Cached username for quick lookup
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        // Optional: role in group (useful for group admin features)
        public string Role { get; set; } = "Member";

        // Navigation property (optional if using EF Core)
        public Group? Group { get; set; }

        public GroupMember() { }

        public GroupMember(Guid groupId, Guid userId, string username, string role)
        {
            Id = Guid.NewGuid();
            GroupId = groupId;
            UserId = userId;
            Username = username;
            Role = role;
            JoinedAt = DateTime.UtcNow;
        }
    }
}
