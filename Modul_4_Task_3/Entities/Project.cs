using System;
using System.Collections.Generic;

namespace Modul_4_Task_3.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime StartedDate { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public List<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
