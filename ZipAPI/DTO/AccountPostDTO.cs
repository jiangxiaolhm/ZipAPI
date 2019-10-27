using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZipAPI.ViewModels
{
    public class AccountPostDTO
    {
        [Required]
        public int UserId { get; set; }
    }
}
