
using System.Reflection.Emit;
using static System.Collections.Specialized.BitVector32;
using Microsoft.EntityFrameworkCore;
using Core.Model;

namespace DataAccess
{
    public class DataAccessContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Port=55432;Database=ScooterCompany;Username=postgres;Password=mypassword");
        }


        public DbSet<AppUser> AppUsers { get; set; }
        
        public DbSet<Scooter> Scooters { get; set; }
        public DbSet<Trip> Trips { get; set; }


       

    }


}

