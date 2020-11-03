using DA1.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Models
{
    public class ProductDetail
    {
         [Key]public int ProductIdDetail { get; set; }
        public string Description { get; set; }
        public string Displacement{ get; set; }
        public string Maxpower { get; set; }
        public string Topspeed { get; set; }
        public string TAcceleration { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierID { get; set; }
        public string Invented { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
