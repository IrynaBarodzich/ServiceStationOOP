using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ServiceStation.Attributes;

namespace ServiceStation.Models
{
    public class Cars
    {
        [Required]
        public int CarsID { get; set; }
        [Required]
        [StringLength(50)]
        public string Make { get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [StringLength(50)]
        public string VIN { get; set; }
        public int ClientsID { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual Clients Clients { get; set; }
 
    }
}