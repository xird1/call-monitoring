
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TelusInternational.DataAccess.Entities;

namespace TelusInternational.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<MonitorData> MonitorData { get; set; }
        public DbSet<QueueGroup> QueueGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QueueGroup>()
                .HasOne(e => e.MonitorData)
                .WithOne(e => e.QueueGroup)
                .HasForeignKey<MonitorData>(e => e.QueueGroupId)
                .IsRequired();
        }
    }
}
