using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Trip
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; } = DateTime.MinValue;
        public double Distance { get; set; }
        public decimal Cost { get; set; }

        public AppUser? AppUser { get; set; }

        public int AppUserId { get; set; }

        public Scooter? Scooter { get; set; }

        public int ScooterId { get; set; }
    }
}
