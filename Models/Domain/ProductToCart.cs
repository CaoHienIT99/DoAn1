using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Models.Domain
{
    public class ProductToCart
    {
        [Key]
        public int CartID { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

    }
}
