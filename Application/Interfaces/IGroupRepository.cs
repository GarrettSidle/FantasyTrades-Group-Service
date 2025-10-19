using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyTradesGroupService.Domain.Entities;

namespace FantasyTradesGroupService.Application.Interfaces
{
    public interface IGroupRepository
    {
        Task AddAsync(FantasyTradesGroupService.Domain.Entities.Group group);

        Task<FantasyTradesGroupService.Domain.Entities.Group?> GetByIdAsync(Guid id);
        
        Task<FantasyTradesGroupService.Domain.Entities.Group?> GetByCodeAsync(string code);

        Task<IEnumerable<FantasyTradesGroupService.Domain.Entities.Group>> GetGroupsByMemberIdAsync(Guid userId);

        Task AddMemberAsync(FantasyTradesGroupService.Domain.Entities.GroupMember member);

        Task DeleteAsync(FantasyTradesGroupService.Domain.Entities.Group group);

        Task SaveChangesAsync();
    }
}
