using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestUMS.Models
{
    public class IndexViewModel
    {
        public List<Airport> Airports { get; set; }
        public List<Plane> Planes { get; set; }
        public List<Flight> Flights { get; set; }
        public List<PassengerBooking> Bookings { get; set; }
    }

}
