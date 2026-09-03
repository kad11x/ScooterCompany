using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class AppUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int PhoneNumber { get; set; }

        public List<Trip> Trips { get; set; } = new List<Trip>();
    }
}
