using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class Employees
    {
        public int Id { get; set; } 
        public string TabNumber { get; set; }
        public string LastName { get; set; } 
        public string FirstName { get; set; } 
        public string MiddleName { get; set; } 
        public string Email { get; set; }
        public string Phone { get; set; } 
        public DateTime HireDate { get; set; } 
        public DateTime? TerminationDate { get; set; } 
        public int PositionId { get; set; } 
        public Positions Position { get; set; } 
        public RecordStatus Status { get; set; }

        public string FullName
        {
            get { return $"{LastName} {FirstName} {MiddleName}"; }
        }
    }
}
