using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Models.Domain
{
    public class User
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string pass { get; set; }
        public string Fullname { get; set; }
        public string Adress { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
    }
}
