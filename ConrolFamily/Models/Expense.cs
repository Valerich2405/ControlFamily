using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFamily.Models
{
    public class Expense
    {
        [Key]
        public int IdExpense { get; set; }

        public string? NameExpense { get; set; }

        [Required]
        public double AmountExpense { get; set; }

        [Required]
        public DateTime DateExpense { get; set; }

        public string Category { get; set; } = "Expense";
    }
}
