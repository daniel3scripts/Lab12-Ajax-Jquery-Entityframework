using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CodeFirstDemo.Models
{
    public class Seller
    {

        public int SellerId { get; set; }
        public string SellerName { get; set; }

        public string SellerLastName { get; set; }
        [Required]
        [StringLength(8)]
        public string Dni { get; set; } 
        public string Email { get; set; }
        [Required]
        [StringLength(11)]
        public string Ruc { get; set; }
        [Required]
        public DateTime SellerDate { get; set; }
       

       


    }
}