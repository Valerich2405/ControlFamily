using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFamily.Models
{
    public class Income
    {
        [Key]
        public int IdIncome { get; set; }

        public string? NameIncome { get; set; }

        [Required]
        public double AmountIncome { get; set; }

        [Required]
        public DateTime DateIncome { get; set; }

        public string Category { get; set; } = "Income";
    }
}
