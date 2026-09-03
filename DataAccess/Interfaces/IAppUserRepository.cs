using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IAppUserRepository
    {
        // Hente alle turer for en bestemt bruker, sortert etter starttidspunkt.
        List<Trip> GetTripsForUser(int userId);

        // Finne hvilken bruker som har kjørt flest turer.
        AppUser GetUserWithMostTrips();
    }
}
