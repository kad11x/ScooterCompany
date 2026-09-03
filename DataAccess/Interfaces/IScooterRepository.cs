using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IScooterRepository
    {
       // Finne alle scootere som er ledige og har batteriprosent over 20. 
        List<Scooter> GetAvailableScootersWithBatteryAbove20();
    }
}
