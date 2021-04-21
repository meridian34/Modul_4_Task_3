using System.IO;
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
            builder.AddJsonFile("appconfig.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuider = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuider
                .UseSqlServer(connectionString)
                .Options;

            using var db = new ApplicationContext(options);
        }
    }
}
