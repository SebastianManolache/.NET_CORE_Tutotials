using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System;
namespace WebApplication1
{
    public class ClubDbContext : DbContext
    {
        public DbSet<Club> Club { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<PlayerProfile> PlayerProfile { get; set; }

        public ClubDbContext()
        {
            //// Get the ObjectContext related to this DbContext
            //var objectContext = (this as IObjectContextAdapter).ObjectContext;

            //// Sets the command timeout for all the commands
            //objectContext.CommandTimeout = 120;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-S6MRRV2;Database=SalesClubDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>()
                .HasMany(club => club.Players)
                .WithOne(player => player.Club)
                .IsRequired();

            modelBuilder.Entity<Player>()
                .HasOne(player => player.PlayerProfile)
                .WithOne(profile =>profile.Player)
                .HasForeignKey<PlayerProfile>(profile =>profile.PlayerId);
        }

    }
}
