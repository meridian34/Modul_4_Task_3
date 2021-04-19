using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Modul_4_Task_3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Modul_4_Task_3.Helpers
{
    public class Starter
    {
        public void Start()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuider = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuider
                .UseSqlServer(connectionString)
                .Options;


        }
    }
}
