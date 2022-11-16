using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstDemo.Models
{
    public class Customer

    {
        public int CustomerID { get; set; } 
        public string CustomerName { get; set; }   
        [Required]
        public string CustomerLastName { get; set; }
        [Required]
        [StringLength(8)]
        public string Dni { get; set; }
        public string Email { get; set; }   
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        
    }
}