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
using ClosedXML.Excel;
using ControlFamily.Context;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Win32;

namespace ConrolFamily
{
    public partial class CreatingReport : Window
    {
        public CreatingReport()
        {
            InitializeComponent();
        }

        private void CreatingReport_OnClick(object sender, RoutedEventArgs e)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Звіт");

                string reportTitle = ReportTitle.Text;
                var startDate = StartDatePicker.SelectedDate;
                var endDate = EndDatePicker.SelectedDate;

                if (reportTitle == null || startDate == null || endDate == null)
                {
                    MessageBox.Show("Будь ласка, введіть назву та початкову і кінцеву дати за які ви хочете згенерувати звіт.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                using (var dbConteiner = new MyDbContext())
                {
                    var incomes = dbConteiner.Incomes
                        .Where(i => i.DateIncome >= startDate && i.DateIncome <= endDate)
                        .Select(i => new
                        {
                            Id = i.IdIncome,
                            Name = i.NameIncome,
                            Amount = i.AmountIncome,
                            Date = i.DateIncome,
                            Category = "Income"
                        });

                    var expenses = dbConteiner.Expenses
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
                    var totalBalance = totalIncomes - totalExpenses;

                    var data = incomes.Concat(expenses).ToList()
                        .OrderBy(d => d.Date);

                    worksheet.Cell("A1").Value = "Звіт за період:";
                    worksheet.Cell("A1").Style.Font.Bold = true;
                    worksheet.Cell("B1").Value = $"з {startDate}";
                    worksheet.Cell("B1").Style.Font.Bold = true;
                    worksheet.Cell("C1").Value = $"по {endDate}.";
                    worksheet.Cell("C1").Style.Font.Bold = true;
                    worksheet.Cell("A2").Value = "Назва:";
                    worksheet.Cell("A2").Style.Font.Bold = true;
                    worksheet.Cell("B2").Value = "Сума:";
                    worksheet.Cell("B2").Style.Font.Bold = true;
                    worksheet.Cell("C2").Value = "Дата:";
                    worksheet.Cell("C2").Style.Font.Bold = true;
                    
                    int row = 3;
                    foreach (var item in data)
                    {
                        worksheet.Cell($"A{row}").Value = item.Name;
                        worksheet.Cell($"B{row}").Value = item.Amount;
                        worksheet.Cell($"C{row}").Value = item.Date;

                        if (item.Category == "Income")
                        {
                            worksheet.Cell($"B{row}").Style.Font.FontColor = XLColor.Green;
                        }
                        else
                        {
                            worksheet.Cell($"B{row}").Style.Font.FontColor = XLColor.Red;
                        }

                        row++;
                    }

                    worksheet.Cell($"A{row}").Value = "Всього доходів:";
                    worksheet.Cell($"B{row}").Value = totalIncomes;
                    worksheet.Cell($"A{row}").Style.Font.Bold = true;
                    worksheet.Cell($"B{row}").Style.Font.Bold = true;
                    worksheet.Cell($"B{row}").Style.Font.FontColor =  XLColor.Green;
                    row++;
                    worksheet.Cell($"A{row}").Value = "Всього витрат:";
                    worksheet.Cell($"B{row}").Value = totalExpenses;
                    worksheet.Cell($"A{row}").Style.Font.Bold = true;
                    worksheet.Cell($"B{row}").Style.Font.Bold = true;
                    worksheet.Cell($"B{row}").Style.Font.FontColor = XLColor.Red;
                    row++;
                    worksheet.Cell($"A{row}").Value = "Загальний баланс:";
                    worksheet.Cell($"B{row}").Value = totalBalance;
                    worksheet.Cell($"A{row}").Style.Font.Bold = true;
                    worksheet.Cell($"B{row}").Style.Font.Bold = true;
                    worksheet.Cell($"B{row}").Style.Font.FontColor = totalBalance >= 0 ? XLColor.Green : XLColor.Red;

                    worksheet.Column("A").Width = 20;
                    worksheet.Column("B").Width = 20;
                    worksheet.Column("C").Width = 20;

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = reportTitle;
                    saveFileDialog.Filter = "Excel File|*.xlsx";
                    saveFileDialog.Title = "Зберегти звіт";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string filePath = saveFileDialog.FileName;
                        workbook.SaveAs(filePath);
                        MessageBox.Show($"Звіт за {startDate}-{endDate} збережено успішно!", "Збереження звіту", MessageBoxButton.OK, MessageBoxImage.Information);

                        ReportTitle.Text = "";
                        StartDatePicker.SelectedDate = null;
                        EndDatePicker.SelectedDate = null;
                    }
                    else
                    {
                        MessageBox.Show("Звіт не збережено. Можливо, ви не вказали шлях для збереження звіту.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
