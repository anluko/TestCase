using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;
using OfficeOpenXml;
using TestProject.Windows;
using System.Windows;

namespace TestProject.Classes
{
    public class ImportData
    {
        private readonly AppDbContext _context;

        public ImportData(AppDbContext context)
        {
            _context = context;
        }

        public void ImportFromExcel(string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var positionsSheet = package.Workbook.Worksheets["Positions"];
                var employeesSheet = package.Workbook.Worksheets["Employees"];
                var departmentsSheet = package.Workbook.Worksheets["Departments"];
                var headDepartmentsSheet = package.Workbook.Worksheets["HeadDepartment"];
                var employeeDepartmentsSheet = package.Workbook.Worksheets["EmployeeDepartment"];

                if (employeesSheet == null || departmentsSheet == null || positionsSheet == null)
                {
                    throw new Exception("Один или несколько листов не найдены в файле Excel.");
                }

                ImportPositions(positionsSheet);
                ImportEmployees(employeesSheet);
                ImportDepartments(departmentsSheet);
                ImportEmployeeDepartments(employeeDepartmentsSheet);
                ImportHeadDepartments(headDepartmentsSheet);
            }
        }

        private void ImportEmployees(ExcelWorksheet sheet)
        {
            var rows = sheet.Dimension.Rows;

            try
            {
                for (int i = 2; i <= rows; i++)
                {
                    if (!string.IsNullOrEmpty(sheet.Cells[i, 2].Text))
                    {
                        var hireDate = DateTime.Parse(sheet.Cells[i, 8].Text);
                        var terminationDateString = sheet.Cells[i, 9].Text;
                        var terminationDate = string.IsNullOrEmpty(terminationDateString) ? (DateTime?)null : DateTime.Parse(terminationDateString);

                        var employee = new Employees
                        {
                            TabNumber = sheet.Cells[i, 2].Text,
                            LastName = sheet.Cells[i, 3].Text,
                            FirstName = sheet.Cells[i, 4].Text,
                            MiddleName = sheet.Cells[i, 5].Text,
                            Email = sheet.Cells[i, 6].Text,
                            Phone = sheet.Cells[i, 7].Text,
                            HireDate = DateTime.SpecifyKind(hireDate, DateTimeKind.Utc),
                            TerminationDate = terminationDate.HasValue ? DateTime.SpecifyKind(terminationDate.Value, DateTimeKind.Utc) : (DateTime?)null,
                            PositionId = int.Parse(sheet.Cells[i, 10].Text),
                            Status = Enum.Parse<RecordStatus>(sheet.Cells[i, 11].Text)
                        };

                        _context.Employees.Add(employee);
                    }
                }

                _context.SaveChanges();
            } catch (Exception ex) {
                MessageBox.Show("При добавлении Employee: " + ex.InnerException);
            }
        }

        private void ImportDepartments(ExcelWorksheet sheet)
        {
            var rows = sheet.Dimension.Rows;

            try
            {
                for (int i = 2; i <= rows; i++) 
                {
                    if (!string.IsNullOrEmpty(sheet.Cells[i, 2].Text))
                    {
                        var department = new Departments
                        {
                            Name = sheet.Cells[i, 2].Text,
                            Status = Enum.Parse<RecordStatus>(sheet.Cells[i, 3].Text)
                        };

                        _context.Departments.Add(department);
                    }
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При добавлении Department: " + ex.Message);
            }
        }

        private void ImportEmployeeDepartments(ExcelWorksheet sheet)
        {
            var rows = sheet.Dimension.Rows;

            try
            {
                for (int i = 2; i <= rows; i++)
                {
                    if (!string.IsNullOrEmpty(sheet.Cells[i, 2].Text))
                    {
                        var employeeDepartment = new EmployeeDepartment
                        {
                            EmployeeId = int.Parse(sheet.Cells[i, 2].Text),
                            DepartmentId = int.Parse(sheet.Cells[i, 3].Text)
                        };

                        _context.EmployeeDepartments.Add(employeeDepartment);
                    }
                }

                _context.SaveChanges();
            } catch (Exception ex) {
                MessageBox.Show("При добавлении EmployeeDepartment: " + ex.Message);
            }
        }

        private void ImportHeadDepartments(ExcelWorksheet sheet)
        {
            var rows = sheet.Dimension.Rows;

            try
            {
                for (int i = 2; i <= rows; i++)
                {
                    if (!string.IsNullOrEmpty(sheet.Cells[i, 2].Text))
                    {
                        var headDepartment = new HeadDepartments
                        {
                            DepartmentId = int.Parse(sheet.Cells[i, 2].Text),
                            HeadDepartmentId = string.IsNullOrEmpty(sheet.Cells[i, 3].Text) ? (int?)null : int.Parse(sheet.Cells[i, 3].Text),
                            ManagerId = int.Parse(sheet.Cells[i, 4].Text),
                        };

                        _context.HeadDepartments.Add(headDepartment);
                    }
                }
                
                _context.SaveChanges();
            } catch (Exception ex) {
                MessageBox.Show("При добавлении HeadDepartment: " + ex.Message);
            }
        }

        private void ImportPositions(ExcelWorksheet sheet)
        {
            var rows = sheet.Dimension.Rows;

            try
            {
                for (int i = 2; i <= rows; i++)
                {
                    if (!string.IsNullOrEmpty(sheet.Cells[i, 2].Text))
                    {
                        var position = new Positions
                        {
                            Title = sheet.Cells[i, 2].Text
                        };

                        _context.Positions.Add(position);
                    }
                }

                _context.SaveChanges();
            } catch (Exception ex) {
                MessageBox.Show("При добавлении Position: " + ex.Message);
            }
        }
    }
}
