using Microsoft.EntityFrameworkCore;

namespace user_skills.Models
{
    public class UserSkillContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSkill>()
                .HasKey(t => new { t.UserId, t.SkillId });
    
            modelBuilder.Entity<UserSkill>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserSkills)
                .HasForeignKey(sc => sc.UserId);
    
            modelBuilder.Entity<UserSkill>()
                .HasOne(sc => sc.Skill)
                .WithMany(c => c.UserSkills)
                .HasForeignKey(sc => sc.SkillId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=skills.db");
        }
    }
}