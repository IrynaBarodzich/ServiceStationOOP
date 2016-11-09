using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceStation.Attributes;
using ServiceStation.Models;

namespace ServiceStation.ViewModels
{
    public class CarsViewModel
    {
        public int CarsID { get; set; }
        [Required(ErrorMessage = "Enter Make")]
        [StringLength(50, ErrorMessage = "Make must be shorter than 50 characters")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Enter Model")]
        [StringLength(50, ErrorMessage = "Model must be shorter than 50 characters")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Enter Year")]
        [RangeUntilCurrentYear(1900, ErrorMessage = "Enter a valid year")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Enter VIN")]
        [StringLength(17, MinimumLength = 11, ErrorMessage = "Enter a valid VIN")]
        public string VIN { get; set; }
        public int ClientsID { get; set; }
        public ICollection<OrdersViewModel> Orders { get; set; }
        public ClientsViewModel Clients { get; set; }
    }
}