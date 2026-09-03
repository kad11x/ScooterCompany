using Core.Model;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataAccessObjects
{
    public class TripRepository : ITripRepository
    {
        private readonly DataAccessContext? _context;

        public TripRepository()
        {
            _context = new();
        }

        //Hente alle turer som ikke er ferdige enda.
        public List<Trip> GetActiveTrips()
        {
            List<Trip> ActiveTrips = _context.Trips
                .Where(t => t.EndTime == DateTime.MinValue)
                .ToList();

            return ActiveTrips;
        }

        //Regne ut gjennomsnittlig pris per km for alle fullførte turer. '

        public int AvgPricePerKmForCompletedTrips()
        {
            int avgPricePerKm = 0;

            List<Trip> CompletedTrips = _context.Trips
                .Where(t => t.EndTime != DateTime.MinValue)
                .ToList();

            
            for (int i = 0; i < CompletedTrips.Count; i++)
            {
                avgPricePerKm += (int)(CompletedTrips[i].Cost / (decimal)CompletedTrips[i].Distance);
            }


            return avgPricePerKm;

        }
    }
}
