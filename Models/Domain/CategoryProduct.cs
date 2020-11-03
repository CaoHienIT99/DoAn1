using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Models.Domain
{
    public class CategoryProduct
    {
        [Key] public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        
        public List<Product> Products { get; set; }
    }
}
 