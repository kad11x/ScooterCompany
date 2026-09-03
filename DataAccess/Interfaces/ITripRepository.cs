using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface ITripRepository
    {
        //Hente alle turer som ikke er ferdige enda.

        List<Trip> GetActiveTrips();

        //Regne ut gjennomsnittlig pris per km for alle fullførte turer. '

        int AvgPricePerKmForCompletedTrips();
    }
}
