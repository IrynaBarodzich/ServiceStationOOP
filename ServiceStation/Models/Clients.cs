using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceStation.Models
{
    public class Clients
    {

        public int ClientsID { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        [StringLength(50, ErrorMessage = "Last Name must be shorter than 50 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter First Name")]
        [StringLength(50, ErrorMessage = "First Name must be shorter than 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        [StringLength(50, ErrorMessage = "Addres must be shorter than 50 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Phone Number")]
        [RegularExpression(@"[0-9_+-]{1,20}", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        public virtual ICollection<Cars> Cars { get; set; }

    }

    
}