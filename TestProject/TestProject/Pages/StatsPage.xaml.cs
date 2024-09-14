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
using TestProject.Models;
using TestProject.Windows;
using TestProject.Pages;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using TestProject.Classes;

namespace TestProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для StatsPage.xaml
    /// </summary>
    public partial class StatsPage : Page
    {
        public static StatsPage Instance { get; set; }

        private readonly AppDbContext _context;
        private string _selectedFilePath;
        public StatsPage()
        {
            InitializeComponent();

            Instance = this;
            _context = new AppDbContext();

            ShowAndFilterStats();
        }

        private void ShowAndFilterStats()
        {
            var departments = _context.Departments
                .Select(d => d.Name)
                .ToList();
            var departmentsList = new List<string> { "Все подразделения" };
            departmentsList.AddRange(departments);

            var startDate = StartDp.SelectedDate?.ToUniversalTime() ?? DateTime.MinValue.ToUniversalTime();
            var endDate = EndDp.SelectedDate?.ToUniversalTime() ?? DateTime.MaxValue.ToUniversalTime();

            var selectedDepartment = DepartmentsCb.SelectedItem as string;

            var employees = _context.Employees
                .Include(e => e.Position)
                .OrderBy(e => e.Id)
                .AsQueryable()
                .Where(e =>
                    (e.HireDate <= endDate && e.HireDate >= startDate) &&
                    (e.TerminationDate == null || e.TerminationDate >= startDate && e.TerminationDate <= endDate))
                .ToList();

            if (selectedDepartment != "Все подразделения")
            {
                var departmentId = _context.Departments
                    .Where(d => d.Name == selectedDepartment)
                    .Select(d => d.Id)
                    .FirstOrDefault();

                if (departmentId != 0)
                {
                    var employeeIdsInDepatment = _context.EmployeeDepartments
                        .Where(ed => ed.DepartmentId == departmentId)
                        .Select(ed => ed.EmployeeId)
                        .ToList();

                    employees = employees
                        .Where(e => employeeIdsInDepatment.Contains(e.Id))
                        .ToList();
                }
            }

            DepartmentsCb.ItemsSource = departmentsList;
            EmployeesDg.ItemsSource = employees;

            var hiredEmployeesCount = employees.Count(e => e.HireDate <= endDate);
            var dismissedEmployeesCount = employees.Count(e => e.TerminationDate != null && e.TerminationDate >= startDate && e.TerminationDate <= endDate);


            TakedEmployeesTbk.Text = $"Принято сотрудников: {hiredEmployeesCount}";
            DissmissedEmployeesTbk.Text = $"Уволено сотрудников: {dismissedEmployeesCount}";
        }

        private void DepartmentsCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_context != null) ShowAndFilterStats();
        }

        private void StartDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_context != null) ShowAndFilterStats();
        }

        private void EndDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_context != null) ShowAndFilterStats();
        }

        private void DragDropArea_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null && files.Length > 0)
                {
                    var filePath = files[0];
                    if (IsValidFile(filePath))
                    {
                        _selectedFilePath = filePath;

                        string fileName = Path.GetFileName(filePath);
                        FileNameTbk.Text = fileName;
                        SelectFileSp.Visibility = Visibility.Collapsed;
                        StartLoadSp.Visibility = Visibility.Visible;
                    }
                    else MessageBox.Show("Пожалуйста выберите файл Excel.", "Неверный тип файла", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private bool IsValidFile(string filePath)
        {
            var extension = System.IO.Path.GetExtension(filePath).ToLower();
            return extension == ".xls" || extension == ".xlsx";
        }

        private void DragDropArea_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy; 
            }
            else
            {
                e.Effects = DragDropEffects.None; 
            }
            e.Handled = true;
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                Title = "Выберите файл"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string file = openFileDialog.FileName;
                _selectedFilePath = file;

                string fileName = Path.GetFileName(file);
                FileNameTbk.Text = fileName;
                SelectFileSp.Visibility = Visibility.Collapsed;
                StartLoadSp.Visibility = Visibility.Visible;
            }
        }

        private void StartLoadBtn_Click(object sender, RoutedEventArgs e)
        {
            var context = new AppDbContext();
            var importer = new ImportData(context);
            importer.ImportFromExcel(_selectedFilePath);
            MessageBox.Show("Импорт завершен успешно!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ChooseNewFileBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectFileSp.Visibility = Visibility.Visible;
            StartLoadSp.Visibility = Visibility.Collapsed;
        }
    }
}
