using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class ClubDbContext : DbContext
    {
        public DbSet<Club> Club { get; set; }

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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Club>().ToTable("Club");
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
