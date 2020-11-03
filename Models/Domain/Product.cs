using DA1.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductImage { get; set; }
        public double ProductPrice { get; set; }        
        public int Discount { get; set; }
        public DateTime CreateDate { get; set; }
        public CategoryProduct Category { get; set; }
        public int CategoryId { get; set; }
    }
}
