using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Models.Domain
{
    public class OrderDetail
    {
        [Key]
        [Column (Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
