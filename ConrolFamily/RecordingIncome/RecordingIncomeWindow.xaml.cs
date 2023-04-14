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

    public partial class RecordingIncomeWindow : Window
    {
        MyDbContext _dbConteiner;

        public RecordingIncomeWindow()
        {
            InitializeComponent();
        }
        private void RecordingIncomeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _dbConteiner = new MyDbContext();
            _dbConteiner.Incomes.Load();
            dgGrid.ItemsSource = _dbConteiner.Incomes.Local.ToObservableCollection();
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

            _dbConteiner.Incomes.Add(income);
            _dbConteiner.SaveChanges();

            NameIncomeTxt.Text = "";
            AmountIncomeTxt.Text = "";
            IncomeDatePicker.SelectedDate = null;

            MessageBox.Show("Дохід успішно додано!", "Додавання доходу", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            Income selectedIncome = dgGrid.SelectedItem as Income;
            if (selectedIncome != null)
            {
                _dbConteiner.Incomes.Remove(selectedIncome);
                _dbConteiner.SaveChanges();
            }
        }
    }
}
