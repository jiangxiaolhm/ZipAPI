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
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string EmailAddress { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        [Range(0D, Double.PositiveInfinity)]
        public decimal MonthlySalary { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        [Range(0D, Double.PositiveInfinity)]
        public decimal MonthlyExpenses { get; set; }

        public Account Account { get; set; }
    }
}
