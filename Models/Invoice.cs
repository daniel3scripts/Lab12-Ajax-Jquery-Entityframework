using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstDemo.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(8)]
        public string InvoiceNumber { get; set; }
        
        public  List<Product> Products { get; set; }



    }
}