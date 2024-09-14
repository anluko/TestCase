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
using TestProject.Models;
using TestProject.Windows;
using TestProject.Pages;

namespace TestProject
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public static EmployeesPage Instance { get; set; }
        private readonly AppDbContext _context;
        public EmployeesPage()
        {
            InitializeComponent();

            Instance = this;
            _context = new AppDbContext();

            loadAndFilterData();
        }

        public void loadAndFilterData()
        {
            var employeesQuery = _context.Employees
                .Include(e => e.Position)
                .AsQueryable();
            var departments = _context.Departments
                .Select(d => d.Name)
                .ToList();

            var departmentsList = new List<string> { "Все подразделения" };
            departmentsList.AddRange(departments);

            var searchText = EmployeesWindow.Instance.SearchTb.Text.ToLower();
            var selectedDepartment = EmployeesWindow.Instance.DepartmentsCb.SelectedItem as string;

            if (!string.IsNullOrEmpty(searchText))
            {
                employeesQuery = employeesQuery.Where(e =>
                    e.LastName.ToLower().Contains(searchText) ||
                    e.FirstName.ToLower().Contains(searchText) ||
                    e.MiddleName.ToLower().Contains(searchText) ||
                    e.TabNumber.ToLower().Contains(searchText));
            }

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

                    employeesQuery = employeesQuery.Where(e => employeeIdsInDepatment.Contains(e.Id));
                }
            }


            var employees = employeesQuery.OrderBy(e => e.Id).ToList();

            EmployeesWindow.Instance.DepartmentsCb.ItemsSource = departmentsList;
            EmployeesDg.ItemsSource = employees;
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            EmployeesWindow.Instance.SearchTb.Visibility = Visibility.Collapsed;
            EmployeesWindow.Instance.DepartmentsCb.Visibility = Visibility.Collapsed;

            EmployeesWindow.Instance.BackBtn.Visibility = Visibility.Visible;
            EmployeesWindow.Instance.StatsLoadGrid.Visibility = Visibility.Visible;

            EmployeesWindow.Instance.MainFrame.Navigate(new StatsPage());
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            NewEmployeePage newEmployeeWindow = new NewEmployeePage();
            newEmployeeWindow.EmployeeAdded += () => loadAndFilterData();

            EmployeesWindow.Instance.SearchTb.Visibility = Visibility.Collapsed;
            EmployeesWindow.Instance.DepartmentsCb.Visibility = Visibility.Collapsed;

            EmployeesWindow.Instance.BackBtn.Visibility = Visibility.Visible;
            EmployeesWindow.Instance.InfoTbk.Visibility = Visibility.Visible;

            EmployeesWindow.Instance.MainFrame.Navigate(new NewEmployeePage());

        }

        private void DeleteEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = EmployeesDg.SelectedItem as Employees;

            if (selectedEmployee.Status == RecordStatus.Закрытый)
            {
                MessageBox.Show("Сотрудник уже уволен!");
                return;
            }

            if (selectedEmployee != null)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Вы точно хотите удалить {selectedEmployee.FullName}",
                    "Подтверждение",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                );

                if (result == MessageBoxResult.Yes)
                {
                    DateTime dateTime = DateTime.Now;
                    selectedEmployee = _context.Employees.Find(selectedEmployee.Id);
                    selectedEmployee.TerminationDate = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
                    selectedEmployee.Status = RecordStatus.Закрытый;
                    _context.SaveChanges();

                    loadAndFilterData();

                    MessageBox.Show($"Cотрудник {selectedEmployee.LastName} успешно уволен!");
                }
            }
            else { MessageBox.Show("Выберите сотрудника."); }
        }
    }
}
