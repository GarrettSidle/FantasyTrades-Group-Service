// Infrastructure/Persistence/GroupDbContext.cs
using Microsoft.EntityFrameworkCore;
using FantasyTradesGroupService.Domain.Entities;

namespace FantasyTradesGroupService.Infrastructure.Persistence
{
    public class GroupDbContext : DbContext
    {
        public GroupDbContext(DbContextOptions<GroupDbContext> options)
            : base(options) { }

        public DbSet<Group> Groups => Set<Group>();
        public DbSet<GroupMember> GroupMembers => Set<GroupMember>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Group
            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasMany(e => e.Members)
                    .WithOne(e => e.Group)
                    .HasForeignKey(e => e.GroupId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.OwnsOne(e => e.Code, code =>
                {
                    code.Property(c => c.Value).HasColumnName("GroupCode").IsRequired();
                });
            });

            // Configure GroupMember
            modelBuilder.Entity<GroupMember>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Role).IsRequired();
            });
        }
    }
}
