using System.Collections.Generic;

namespace Modul_4_Task_3.Entities
{
    public class Client
    {
        public int ClientId { get; set; }

        public string CompanyName { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public string Description { get; set; }

        public List<Project> Projects { get; set; }
    }
}
