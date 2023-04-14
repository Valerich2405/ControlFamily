using System;
using Microsoft.EntityFrameworkCore;
using ControlFamily.Models;
using System.Transactions;

namespace ControlFamily.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base()
        {
        }
        public DbSet<Income> Incomes { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }
    }
}
