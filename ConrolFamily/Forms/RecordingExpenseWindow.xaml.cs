using ControlFamily.Context;
using ControlFamily.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ConrolFamily
{

    public partial class RecordingExpenseWindow : Window
    {
        private readonly MyDbContext DbContext;

        public RecordingExpenseWindow()
        {
            InitializeComponent();
            DbContext = new MyDbContext();
        }
        private void RecordingExpenseWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DbContext.Expenses.Load();
            dgGrid.ItemsSource = DbContext.Expenses.Local.ToObservableCollection();
        }

        private void AddExpenseButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(AmountExpenseTxt.Text) || ExpenseDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Поля 'Сума' та 'Дата' є обов'язковими. Будь ласка, заповніть обидва поля.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double amountExpense;
            if (!double.TryParse(AmountExpenseTxt.Text, out amountExpense))
            {
                MessageBox.Show("Будь ласка, введіть коректну суму виьрати у вигляді числа.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Expense expense = new Expense()
            {
                NameExpense = NameExpenseTxt.Text,
                AmountExpense = Convert.ToDouble(AmountExpenseTxt.Text),
                DateExpense = ExpenseDatePicker.SelectedDate.Value,
            };

            DbContext.Expenses.Add(expense);
            DbContext.SaveChanges();

            NameExpenseTxt.Text = "";
            AmountExpenseTxt.Text = "";
            ExpenseDatePicker.SelectedDate = null;

            MessageBox.Show("Витрату успішно додано!", "Додавання витрати", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteExpense_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedExpense = dgGrid.SelectedItem as Expense;
            if (selectedExpense != null)
            {
                DbContext.Expenses.Remove(selectedExpense);
                DbContext.SaveChanges();
            }
        }
    }
}