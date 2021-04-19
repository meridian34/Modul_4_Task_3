using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_4_Task_3.Entities
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset HiredDate { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public int TitleId { get; set; }
        public Title Title { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
