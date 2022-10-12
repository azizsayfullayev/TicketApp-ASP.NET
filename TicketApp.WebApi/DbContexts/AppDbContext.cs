using Microsoft.EntityFrameworkCore;
using TicketApp.WebApi.Models;

namespace TicketApp.WebApi.DbContexts
{
    public class AppDbContext :DbContext
    {
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(p => p.Email)
                .IsUnique();
        }
    }
}
