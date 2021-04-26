using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_4_Task_3.Entities
{
    public class Client
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public List<Project> Projects { get; set; }
    }
}
