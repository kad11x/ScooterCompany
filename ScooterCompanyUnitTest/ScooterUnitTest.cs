using Core;
using Core.Model;
using Core.Model.Enum;
using DataAccess;
using DataAccess.DataAccessObjects;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace ScooterCompanyUnitTest
{
    public class ScooterUnitTest
    {
        [SetUp]
        public void Setup()
        {
            using DataAccessContext context = new();
            
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            
        }

   

        [Test]
        public void ShouldReturnAvailableScootersWithBatteryAbove20()
        {
            // Arrange

            List<Scooter> scooters = new List<Scooter>
            {
                new Scooter { Brand = "Brand1", BatteryCapacity = 25, Status = ScooterStatus.Available },
                new Scooter { Brand = "Brand2", BatteryCapacity = 15, Status = ScooterStatus.Available },
                new Scooter { Brand = "Brand3", BatteryCapacity = 30, Status = ScooterStatus.InUse },
                new Scooter { Brand = "Brand4", BatteryCapacity = 22, Status = ScooterStatus.Available },
                new Scooter { Brand = "Brand5", BatteryCapacity = 18, Status = ScooterStatus.OutOfOrder }
            };

            using DataAccessContext context = new();

            context.Scooters.AddRange(scooters);
            context.SaveChanges();
            ScooterRepository scooterRepository = new();
                // Act
            List<Scooter> result = scooterRepository.GetAvailableScootersWithBatteryAbove20();

            // Assert

            Assert.That(result.Count, Is.EqualTo(2));

        
        }


    }
}
