using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestUMS.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string FlightNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string AirportName { get; set; }

        [Required]
        [StringLength(100)]
        public string Plane { get; set; }
    }

}

// Models/Flight.cs
namespace YourNamespace.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string AirportName { get; set; }
        public string PlaneCode { get; set; }
    }
}
