using EventManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<EventList> EventsList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Reviews)
                .HasForeignKey(r => r.EventId);
            
            modelBuilder.Entity<EventList>()
                .HasOne(r => r.User)
                .WithMany(u => u.EventLists)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<EventList>()
                .HasOne(r => r.Event)
                .WithMany(e => e.EventLists)
                .HasForeignKey(r => r.EventId);
        }
    }
}
