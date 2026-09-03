using System;
using System.Collections.Generic;
using System.Text;
using Core.Model.Enum;

namespace Core.Model
{
    public class Scooter
    {
        public int Id { get; set; }

        public string? Brand { get; set; }

        public int BatteryCapacity { get; set; }

        public ScooterStatus Status { get; set; }

        public List<Trip> Trips { get; set; } = new List<Trip>();



    }
}
