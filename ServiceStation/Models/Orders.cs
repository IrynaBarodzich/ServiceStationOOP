using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceStation.Models
{
    public class Orders
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