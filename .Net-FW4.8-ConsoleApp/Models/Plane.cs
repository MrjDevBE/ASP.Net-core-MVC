using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestUMS.Models
{
    public class Plane
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Airline { get; set; }

        [Required]
        [StringLength(100)]
        public string Model { get; set; }
    }
}