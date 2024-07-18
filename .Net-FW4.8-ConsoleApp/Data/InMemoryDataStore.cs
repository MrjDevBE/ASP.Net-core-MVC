using System.Collections.Generic;
using TestUMS.Models;

namespace TestUMS.Data
{
    public static class InMemoryDataStore
    {
        public static List<Airport> Airports { get; set; } = new List<Airport>
        {
            new Airport { Id = 1, Name = "NAIA", Address = "Pasay" }
        };

        public static List<Plane> Planes { get; set; } = new List<Plane>
        {
            new Plane { Id = 1, Code = "BPAL123", Airline = "PAL", Model = "Boeing 737" }
        };

        public static List<Flight> Flights { get; set; } = new List<Flight>
        {
            new Flight { Id = 1, FlightNumber = "YU2387f", AirportName = "NAIA", Plane = "PAL" }
        };

        public static List<PassengerBooking> PassengerBookings { get; set; } = new List<PassengerBooking>
        {
            new PassengerBooking { Id = 1, Name = "Juan Dela Cruz", FlightNumber = "YU2387f" }
        };
    }
}
