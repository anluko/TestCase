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

namespace TestProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewEmployeePage.xaml
    /// </summary>
    public partial class NewEmployeePage : Page
    {
        public event Action EmployeeAdded;
        public static NewEmployeePage Instance { get; set; }

        private readonly AppDbContext _context;
        private int tabNumberText = 0;
        private string fullName = "";
        private string email = "";
        private string phone = "";
        private int selectedPosition = 0;
        private bool isUpdating;

        public NewEmployeePage()
        {
            InitializeComponent();

            Instance = this;
            _context = new AppDbContext();
            var positions = _context.Positions.Select(d => d.Title).ToList();
            PositionCb.ItemsSource = positions;
        }

        protected virtual void OnEmployeeAdded()
        {
            EmployeeAdded?.Invoke();
        }

        private void AddEmployeeDepartment(int employeeId)
        {
            if (employeeId != 0 && selectedPosition != 0)
            {
                int departmentId = 0;

                if (selectedPosition == 1 || selectedPosition == 2 || selectedPosition == 3 || selectedPosition == 6)
                    departmentId = 1;
                else if (selectedPosition == 5)
                    departmentId = 2;
                else if (selectedPosition == 7 || selectedPosition == 8)
                    departmentId = 3;
                else if (selectedPosition == 9)
                    departmentId = 4;

                var employeeDepartment = new EmployeeDepartment
                {
                    EmployeeId = employeeId,
                    DepartmentId = departmentId
                };

                _context.EmployeeDepartments.Add(employeeDepartment);
                _context.SaveChanges();
            }
        }

        private void TabNumberTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            tabNumberText = int.Parse(TabNumberTb.Text);
        }

        private void TabNumberTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void FullNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            fullName = FullNameTb.Text;
        }

        private void EmailTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            email = EmailTb.Text;
        }

        private void PhoneTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void PhoneTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isUpdating)
                return;

            isUpdating = true;

            int previousCaretIndex = PhoneTb.CaretIndex;
            string input = new string(PhoneTb.Text.Where(char.IsDigit).ToArray());

            if (input.StartsWith("7") || input.StartsWith("8"))
            {
                if (input.StartsWith("7"))
                    input = '8' + input.Substring(1);
            }
            else if (input.Length > 0) input = '8' + input;

            if (input.Length > 1) input = input.Insert(1, "(");
            if (input.Length > 4) input = input.Insert(5, ")");
            if (input.Length > 8) input = input.Insert(9, "-");
            if (input.Length > 11) input = input.Insert(12, "-");
            if (input.Length > 15) input = input.Substring(0, 15);

            string oldText = PhoneTb.Text;
            PhoneTb.Text = input;
            int diff = input.Length - oldText.Length;

            if (previousCaretIndex + diff >= 0 && previousCaretIndex + diff <= input.Length)
                PhoneTb.CaretIndex = previousCaretIndex + diff;
            else PhoneTb.CaretIndex = input.Length;

            isUpdating = false;
            phone = PhoneTb.Text;
        }

        private void PhoneTb_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                int caretIndex = PhoneTb.CaretIndex;
                string text = PhoneTb.Text;

                if (e.Key == Key.Back && caretIndex > 0)
                {
                    if (caretIndex > 1 && (text[caretIndex - 1] == '(' || text[caretIndex - 1] == ')' || text[caretIndex - 1] == '-'))
                    {
                        PhoneTb.Text = text.Remove(caretIndex - 1, 1);
                        PhoneTb.CaretIndex = caretIndex - 1;
                        e.Handled = true;
                    }
                    else if (caretIndex > 0 && char.IsDigit(text[caretIndex - 1]))
                    {
                        PhoneTb.Text = text.Remove(caretIndex - 1, 1);
                        PhoneTb.CaretIndex = caretIndex - 1;
                        e.Handled = true;
                    }
                }
                else if (e.Key == Key.Delete && caretIndex < text.Length)
                {
                    if (text[caretIndex] == '(' || text[caretIndex] == ')' || text[caretIndex] == '-')
                    {
                        PhoneTb.Text = text.Remove(caretIndex, 1);
                        PhoneTb.CaretIndex = caretIndex;
                        e.Handled = true;
                    }
                    else if (caretIndex < text.Length && char.IsDigit(text[caretIndex]))
                    {
                        PhoneTb.Text = text.Remove(caretIndex, 1);
                        PhoneTb.CaretIndex = caretIndex;
                        e.Handled = true;
                    }
                }
            }
        }

        private void PositionCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPosition = _context.Positions
                .Where(p => p.Title.Contains(PositionCb.SelectedItem.ToString()))
                .Select(p => p.Id)
                .FirstOrDefault();
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tabNumberText == 0 || selectedPosition == 0
                || String.IsNullOrEmpty(fullName)
                || String.IsNullOrEmpty(email)
                || String.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Пожалуйста введите все поля!");
                return;
            }

            string[] fullSplitName = fullName.Split(" ");
            string lastName = fullSplitName[0];
            string firstName = fullSplitName[1];
            string middleName = fullSplitName[2];

            DateTime dateTime = DateTime.Now;

            var newEmployee = new Employees
            {
                TabNumber = tabNumberText.ToString(),
                LastName = lastName,
                FirstName = firstName,
                MiddleName = middleName,
                Email = email,
                Phone = phone,
                HireDate = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc),
                PositionId = selectedPosition,
                Status = RecordStatus.Активный
            };

            if (newEmployee != null)
            {
                _context.Employees.Add(newEmployee);
                _context.SaveChanges();
                MessageBox.Show($"Cотрудник {lastName} успешно добавлен!");
                AddEmployeeDepartment(newEmployee.Id);

                OnEmployeeAdded();
                EmployeesWindow.Instance.BackBtn.Visibility = Visibility.Collapsed;
                EmployeesWindow.Instance.InfoTbk.Visibility = Visibility.Collapsed;
                EmployeesWindow.Instance.SearchTb.Visibility = Visibility.Visible;
                EmployeesWindow.Instance.DepartmentsCb.Visibility = Visibility.Visible;

                EmployeesWindow.Instance.MainFrame.Navigate(new EmployeesPage());
            }
        }
    }
}
