using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_4_Task_3.Entities
{
    class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTimeOffset StartedDate { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
