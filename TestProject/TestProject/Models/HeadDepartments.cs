using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class HeadDepartments
    {
        public int Id { get; set; }
        public Departments Department { get; set; }
        public int DepartmentId { get; set; }
        public Departments HeadDepartment { get; set; }
        public int? HeadDepartmentId { get; set; }
        public Employees Manager { get; set; }
        public int? ManagerId { get; set; }
    }
}
