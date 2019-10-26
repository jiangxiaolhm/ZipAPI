using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZipAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
    }
}
