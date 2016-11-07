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
        [Required(ErrorMessage = "Enter Date of Order")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Enter Amount")]
        [Range(0,10000,ErrorMessage = "Order amount can be from $0 to $10,000")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Select Status")]
        public string Status { get; set; }
        public int CarsID { get; set; }
        public virtual Cars Cars { get; set; } 

    }
}