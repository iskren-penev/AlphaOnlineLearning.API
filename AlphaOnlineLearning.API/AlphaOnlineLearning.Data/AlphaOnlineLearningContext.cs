using AlphaOnlineLearning.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AlphaOnlineLearning.Data
{
    public class AlphaOnlineLearningContext : IdentityDbContext
    {
        public AlphaOnlineLearningContext(DbContextOptions<AlphaOnlineLearningContext> options)
            : base(options)
        {

        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Course> Courses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // for testing purposes use in memory database
                var connectionStringBuilder = new SqliteConnectionStringBuilder() { DataSource = ":memory:" };
                var connection = new SqliteConnection(connectionStringBuilder.ToString());
                optionsBuilder.UseSqlite(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCourse>().HasKey(uc => new { uc.UserId, uc.CourseId });
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("Created");
                modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified");
            }

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            DateTime timestamp = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => (e.State == EntityState.Added || e.State == EntityState.Modified)
                             && !e.Metadata.IsOwned()))
            {
                entry.Property("LastModified").CurrentValue = timestamp;
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = timestamp;
                }
            }
            return base.SaveChanges();
        }
    }
}
