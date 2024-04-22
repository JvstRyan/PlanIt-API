using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlanIt.API.Models.Domain;
using System.Data;

namespace PlanIt.API.Data
{
    public class PlanItDbContext : IdentityDbContext<IdentityUser>
    {

        public PlanItDbContext(DbContextOptions<PlanItDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }


        public DbSet<Dates> Dates { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<DateAnswer> DateAnswers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            var adminId = "accd3ab5-37d6-4999-9618-3f9bea33a00c";
            var volunteerId = "1a258f84-c213-4651-b09d-6feb2da3fd63";
            var guestId = "9431a31c-5b3b-4191-8c04-f19f34ff3c57";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminId,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },

                new IdentityRole
                {
                    Id = volunteerId,
                    Name = "volunteer",
                    NormalizedName = "VOLUNTEER"

                },

                new IdentityRole
                {
                    Id = guestId,
                    Name = "guest",
                    NormalizedName = "GUEST"
                }

            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

    }
}

