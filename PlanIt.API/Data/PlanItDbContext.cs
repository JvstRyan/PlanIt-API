using Microsoft.EntityFrameworkCore;
using PlanIt.API.Models.Domain;

namespace PlanIt.API.Data
{
    public class PlanItDbContext : DbContext
    {

        public PlanItDbContext(DbContextOptions<PlanItDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }


        public DbSet<Dates> Dates { get; set; }
        public DbSet<Response> Responses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dates>().HasData(
         new Dates { Id = Guid.NewGuid(), Date = new DateTime(2024, 1, 1), Status = "active" },
         new Dates { Id = Guid.NewGuid(), Date = new DateTime(2024, 2, 1), Status = "active" },
         new Dates { Id = Guid.NewGuid(), Date = new DateTime(2024, 3, 1), Status = "active" },
         new Dates { Id = Guid.NewGuid(), Date = new DateTime(2024, 4, 1), Status = "active" },
         new Dates { Id = Guid.NewGuid(), Date = new DateTime(2024, 5, 1), Status = "active" },
         new Dates { Id = Guid.NewGuid(), Date = new DateTime(2024, 6, 1), Status = "active" }
         );



        }

    }
}
