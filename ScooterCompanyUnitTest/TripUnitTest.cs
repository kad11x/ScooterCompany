using Core.Model;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.DataAccessObjects;
using Core.Model.Enum;

namespace ScooterCompanyUnitTest
{
    public class TripUnitTest
    {
        [SetUp]
        public void Setup()
        {
            using DataAccessContext context = new();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

        }



        [Test]

        public void ShouldReturnActiveTrips()
        {
            // Arrange

            Scooter scooter1 = new Scooter { Brand = "Brand1", BatteryCapacity = 25, Status = ScooterStatus.InUse };
            Scooter scooter2 = new Scooter { Brand = "Brand2", BatteryCapacity = 15, Status = ScooterStatus.Available };
            Scooter scooter3 = new Scooter { Brand = "Brand3", BatteryCapacity = 30, Status = ScooterStatus.InUse };


            List<Trip> trips = new List<Trip>
            {
                new Trip { StartTime = DateTime.UtcNow, EndTime = DateTime.MinValue, Cost = 20.0M, Distance = 5D, Scooter = scooter1 },
                new Trip { StartTime = DateTime.UtcNow, EndTime = DateTime.UtcNow.AddMinutes(20), Cost = 50.0M, Distance = 10D, Scooter = scooter2 },
                new Trip { StartTime = DateTime.UtcNow, EndTime = DateTime.MinValue, Cost = 30.0M, Distance = 7D, Scooter = scooter3 },

            };

            AppUser appUser = new()
            {
                Name = "arne",
                PhoneNumber = 97543273,
                Trips = trips
            };


            using DataAccessContext context = new();
            context.Scooters.Add(scooter1);
            context.Scooters.Add(scooter2);
            context.Scooters.Add(scooter3);
            context.AppUsers.Add(appUser);
            context.Trips.AddRange(trips);
            context.SaveChanges();
            TripRepository tripRepository = new();
            // Act
            List<Trip> result = tripRepository.GetActiveTrips();
            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]

        public void ReturnCorrectAvgPricePerKmForCompletedTrips()
        {
            //arrange 

            Scooter scooter1 = new Scooter { Brand = "Brand1", BatteryCapacity = 25, Status = ScooterStatus.InUse };
            Scooter scooter2 = new Scooter { Brand = "Brand2", BatteryCapacity = 15, Status = ScooterStatus.Available };
            Scooter scooter3 = new Scooter { Brand = "Brand3", BatteryCapacity = 30, Status = ScooterStatus.InUse };

            List<Trip> trips = new List<Trip>
            {
                new Trip { StartTime = DateTime.UtcNow, EndTime = DateTime.UtcNow.AddMinutes(20), Cost = 20.0M, Distance = 5D, Scooter = scooter1 },
                new Trip { StartTime = DateTime.UtcNow, EndTime = DateTime.UtcNow.AddMinutes(20), Cost = 50.0M, Distance = 10D, Scooter = scooter2 },
                new Trip { StartTime = DateTime.UtcNow, EndTime = DateTime.MinValue, Cost = 30.0M, Distance = 7D, Scooter = scooter3 },

            };

            AppUser appUser = new()
            {
                Name = "arne",
                PhoneNumber = 97543273,
                Trips = trips
            };

            int correctValue = 9;

            using DataAccessContext context = new();
            context.Scooters.Add(scooter1);
            context.Scooters.Add(scooter2);
            context.Scooters.Add(scooter3);
            context.AppUsers.Add(appUser);
            context.Trips.AddRange(trips);
            context.SaveChanges();
            TripRepository tripRepository = new();

            //act

            int result = tripRepository.AvgPricePerKmForCompletedTrips();



            //assert

            Assert.That(result, Is.EqualTo(correctValue));






        }


    }
    

        


}
