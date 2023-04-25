using ControlFamily.Context;
using Microsoft.EntityFrameworkCore;
using ControlFamily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ConrolFamily
{
    public partial class ViewStatistics : Window
    {
        private readonly MyDbContext DbContext;
        public ViewStatistics()
        {
            InitializeComponent();
            DbContext = new MyDbContext();
        }

        private void ViewStatistics_OnClick(object sender, RoutedEventArgs e)
        {
            var startDate = StartDatePicker.SelectedDate;
            var endDate = EndDatePicker.SelectedDate;

            if (startDate == null || endDate == null)
            {
                MessageBox.Show("Будь ласка, введіть початкову та кінцеву дату за яку ви хочете переглянути статистику.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (DbContext)
            {
                var incomes = DbContext.Incomes
                .Where(i => i.DateIncome >= startDate && i.DateIncome <= endDate)
                .Select(i => new
                {
                    Id = i.IdIncome,
                    Name = i.NameIncome,
                    Amount = i.AmountIncome,
                    Date = i.DateIncome,
                    Category = "Income"
                });

                var expenses = DbContext.Expenses
                   .Where(e => e.DateExpense >= startDate && e.DateExpense <= endDate)
                   .Select(e => new
                   {
                       Id = e.IdExpense,
                       Name = e.NameExpense,
                       Amount = e.AmountExpense,
                       Date = e.DateExpense,
                       Category = "Expense"
                   });

                var totalIncomes = incomes.Sum(i => i.Amount);
                var totalExpenses = expenses.Sum(e => e.Amount);

                var data = incomes.Concat(expenses).ToList()
                    .OrderBy(d => d.Date);
                dgGrid.ItemsSource = data;

                TotalIncome.Text = $"+{totalIncomes}";
                TotalExpense.Text = $"-{totalExpenses}";

                var totalBalance = totalIncomes - totalExpenses;

                if (totalBalance >= 0)
                {
                    TotalBalance.Foreground = Brushes.Green;
                }
                else
                {
                    TotalBalance.Foreground = Brushes.Red;
                }

                TotalBalance.Text = $"{(totalBalance >= 0 ? "+" : "-")}{Math.Abs(totalBalance)}";

                StartDatePicker.SelectedDate = null;
                EndDatePicker.SelectedDate = null;

                MessageBox.Show($"Статистика за період з {startDate} по {endDate} успішно виведена.", "Виведення статистики", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}