using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZipAPI.ViewModels
{
    public class UserPostDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [Range(0D, Double.PositiveInfinity)]
        public decimal MonthlySalary { get; set; }
        [Required]
        [Range(0D, Double.PositiveInfinity)]
        public decimal MonthlyExpenses { get; set; }
    }
}
