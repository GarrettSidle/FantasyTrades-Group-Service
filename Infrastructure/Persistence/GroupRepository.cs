// Infrastructure/Persistence/GroupRepository.cs
using FantasyTradesGroupService.Application.Interfaces;
using FantasyTradesGroupService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace FantasyTradesGroupService.Infrastructure.Persistence
{
    public class GroupRepository : IGroupRepository
    {
        private readonly GroupDbContext _db;

        public GroupRepository(GroupDbContext db) => _db = db;

    public async Task AddAsync(Group group) => await _db.Groups.AddAsync(group);

    public async Task AddMemberAsync(GroupMember member) => await _db.GroupMembers.AddAsync(member);

        public async Task<Group?> GetByIdAsync(Guid id) =>
            await _db.Groups.Include(g => g.Members).FirstOrDefaultAsync(g => g.Id == id);

    public async Task<Group?> GetByCodeAsync(string code) =>
            await _db.Groups
                .Include(g => g.Members)
                .FirstOrDefaultAsync(g => EF.Property<string>(g.Code, "Value") == code.ToUpperInvariant());

    public async Task<IEnumerable<Group>> GetGroupsByMemberIdAsync(Guid userId) =>
            await _db.Groups
                .Include(g => g.Members)
                .Where(g => g.Members.Any(m => m.UserId == userId))
                .ToListAsync();

        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}
