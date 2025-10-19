using FantasyTradesGroupService.Domain.ValueObjects;
using FantasyTradesGroupService.Domain.Exceptions;
using FantasyTradesGroupService.Domain.Entities;

namespace FantasyTradesGroupService.Domain.Entities
{
    public class Group
    {

        private readonly List<GroupMember> _members = new();

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid CreatedByUserId { get; private set; }
        public GroupCode Code { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime DraftDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public IReadOnlyCollection<GroupMember> Members => _members.AsReadOnly();

        private Group() { } // for EF / serialization

        public Group(string name, Guid createdByUserId, DateTime draftDate, DateTime endDate)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatedByUserId = createdByUserId;
            Code = GroupCode.Generate();
            CreatedAt = DateTime.UtcNow;
            DraftDate = draftDate;
            EndDate = endDate;
        }

        public void AddMember(Guid userId, string username, string role = "Member")
        {
            if (_members.Any(m => m.UserId == userId))
                throw new DomainException("User already in group.");

            _members.Add(new GroupMember(Id, userId, username, role));
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Group name cannot be empty.");
            Name = name;
        }

        public void UpdateDates(DateTime draftDate, DateTime endDate)
        {
            DraftDate = draftDate;
            EndDate = endDate;
        }
    }
}
