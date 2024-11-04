using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruckData.Models
{
    public class Truck
    {
        public int TruckId { get; set; }

        [Required(ErrorMessage = "Truck Code is required")]
        [StringLength(50, ErrorMessage = "Truck code cannot exceed 50 characters.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Truck Name is required")]
        [StringLength(50, ErrorMessage = "Truck Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }
    }
}