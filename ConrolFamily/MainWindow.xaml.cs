using ControlFamily.Context;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConrolFamily
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddIncButton_Click(object sender, RoutedEventArgs e)
        {
            RecordingIncomeWindow form = new RecordingIncomeWindow();
            form.ShowDialog();
        }

        private void AddExpButton_Click(object sender, RoutedEventArgs e)
        {
            RecordingExpenseWindow form = new RecordingExpenseWindow();
            form.ShowDialog();
        }

        private void ViewStatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            ViewStatistics form = new ViewStatistics();
            form.ShowDialog();
        }

        private void CreatingReport_Click(object sender, RoutedEventArgs e)
        {
            CreatingReport form = new CreatingReport();
            form.ShowDialog();
        }
    }
}
