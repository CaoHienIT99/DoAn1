using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Models.Domain
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

    }
}
