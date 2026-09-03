using Core.Model;
using Core.Model.Enum;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataAccessObjects
{
    public class ScooterRepository: IScooterRepository
    {
        private readonly DataAccessContext? _context;

        public ScooterRepository()
        {   
            _context = new();
        }

        public List<Scooter> GetAvailableScootersWithBatteryAbove20()
        {
           List<Scooter> availableScooters = _context.Scooters
                .Where(s => s.Status == ScooterStatus.Available && s.BatteryCapacity > 20)
                .ToList();

            return availableScooters;
        }

        
    }
}
