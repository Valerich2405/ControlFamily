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
using System.Globalization;

namespace ConrolFamily
{

    public partial class RecordingIncomeWindow : Window
    {
        private readonly MyDbContext DbContext;

        public RecordingIncomeWindow()
        {
            InitializeComponent();
            DbContext = new MyDbContext();
        }
        private void RecordingIncomeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DbContext.Incomes.Load();
            dgGrid.ItemsSource = DbContext.Incomes.Local.ToObservableCollection();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(AmountIncomeTxt.Text) || IncomeDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Поля 'Сума' та 'Дата' є обов'язковими. Будь ласка, заповніть обидва поля.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double amountIncome;
            if (!double.TryParse(AmountIncomeTxt.Text, out amountIncome))
            {
                MessageBox.Show("Будь ласка, введіть коректну суму доходу у вигляді числа.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Income income = new Income()
            {
                NameIncome = NameIncomeTxt.Text,
                AmountIncome = Convert.ToDouble(AmountIncomeTxt.Text),
                DateIncome = IncomeDatePicker.SelectedDate.Value,
            };

            DbContext.Incomes.Add(income);
            DbContext.SaveChanges();

            NameIncomeTxt.Text = "";
            AmountIncomeTxt.Text = "";
            IncomeDatePicker.SelectedDate = null;

            MessageBox.Show("Дохід успішно додано!", "Додавання доходу", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedIncome = dgGrid.SelectedItem as Income;
            if (selectedIncome != null)
            {
                DbContext.Incomes.Remove(selectedIncome);
                DbContext.SaveChanges();
            }
        }
    }
}