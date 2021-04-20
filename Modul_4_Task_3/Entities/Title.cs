using System.Collections.Generic;

namespace Modul_4_Task_3.Entities
{
    public class Title
    {
        public int TitleId { get; set; }

        public string Name { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
