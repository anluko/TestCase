using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class EmployeeDepartment
    {
        public int Id { get; set; }
        public Employees Employee { get; set; }
        public int EmployeeId { get; set; }
        public Departments Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
