using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceStation.Models;

namespace ServiceStation.ViewModels
{
    public class OrdersViewModel
    {
        public int OrdersID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Status { get; set; }
        public int CarsID { get; set; }
        public Cars Cars { get; set; } 
    }
}