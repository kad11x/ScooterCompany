using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Interfaces;

namespace DataAccess.DataAccessObjects
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly DataAccessContext? _context;

        public AppUserRepository()
        {
            _context = new();
        }


        // Hente alle turer for en bestemt bruker, sortert etter starttidspunkt.
        public List<Trip> GetTripsForUser(int userId)
        {
            List<Trip> trips = _context.Trips
                .Where(t => t.AppUserId == userId)
                .OrderBy(t => t.StartTime)
                .ToList();

            return trips;

        }

        // Finne hvilken bruker som har kjørt flest turer.
        public AppUser GetUserWithMostTrips()
        {
            AppUser? user = _context.AppUsers
                .OrderByDescending(u => u.Trips.Count)
                .FirstOrDefault();
            return user;

        }
    }
}
