using Clean.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Clean.Data
{
    public class DataContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<UserSettings> UsersSettings { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Plan> Plans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.LogTo(message => Console.WriteLine(message));
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-K9COD6U;Database=sample_db;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Settings) // קשר בין User ל-UserSettings
                .WithOne(us => us.User) // קשר הפוך
                .HasForeignKey<UserSettings>(us => us.UserId); // הגדרת מפתח החוץ
        }

    }
}
