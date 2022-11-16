using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstDemo.Models
{
    public class EnvoiceDetail
    {
        [Key]
        public int EnvoiceDetailID { get; set; }
        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }   
        public Seller Seller { get; set; }
    }
}