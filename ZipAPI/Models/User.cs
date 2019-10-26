using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZipAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal MonthlySalary { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal MonthlyExpenses { get; set; }
        public Account Account { get; set; }
    }
}
