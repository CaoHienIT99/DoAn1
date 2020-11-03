using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Models.Domain
{
    public partial class UserRole
    {
        public User User { get; set; }
        [Key]
        //[Column ( = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
       public int UserID { get; set; }
        public Role Role { get; set; }
        public int RoleID { get; set; }
    }
}
