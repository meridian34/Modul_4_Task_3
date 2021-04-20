using System.Collections.Generic;

namespace Modul_4_Task_3.Entities
{
    public class Office
    {
        public int OfficeId { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
