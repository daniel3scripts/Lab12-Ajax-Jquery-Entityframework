using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstDemo.Models
{
    public class Product
    {
        
        public int ProductID { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}