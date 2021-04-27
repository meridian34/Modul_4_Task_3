using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.SqlServer;
using Modul_4_Task_3.Entities;

namespace Modul_4_Task_3.Helpers
{
    public class LazyLoading
    {
        private readonly ApplicationContext _context;

        public LazyLoading(ApplicationContext context)
        {
            _context = context;
        }

        public void FirstLINQTask()
        {
            var leftJoin = from proj in _context.Projects
                           join cl in _context.Clients on proj.ClientId equals cl.ClientId
                           into Group
                           from Cl in Group.DefaultIfEmpty()
                           join ep in _context.EmployeeProjects on proj.ProjectId equals ep.ProjectId
                           into Group2
                           from Ep in Group2.DefaultIfEmpty()
                           select new { proj, Cl , Ep};

            foreach (var i in leftJoin)
            {
                string rate = i.Ep is null ? "null" : i.Ep.Rate.ToString();
                Console.WriteLine(@$"{i.proj.Name}  {i.Cl.Name}  {rate}");              
            }
        }

        public void SecondLINQTask()
        {
            
            var diff = _context.Employees.Select(e => SqlServerDbFunctionsExtensions.DateDiffDay(null, e.HiredDate, DateTime.Now)).OrderBy(e => e);
            foreach(var i in diff)
            {
                Console.WriteLine(i);
            }
        }

        public void ThirdLINQTask()
        {
            using(var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    var leftJoin = _context.Projects
                           .Join(_context.Clients,
                                       proj => proj.ClientId,
                                       cl => cl.ClientId,
                                       (proj, cl) => new { proj, cl }
                                       );

                    foreach (var i in leftJoin)
                    {
                        if (i.proj.Name == "Roga&Kopyta_Project4")
                        {
                            i.proj.Name = "Roga&Kopyta_Project5";
                        }
                        if (i.cl.ClientId == 1)
                        {
                            i.cl.Description = "Updated5";
                        }
                    }
                    _context.SaveChanges();
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                }
            }
           

            
        }

        public void FourthLinqTask()
        {
            Employee e = new Employee() { BirthDate = null, FirstName = "test", HiredDate = DateTime.Now, LastName = "test", OfficeId = 1, TitleId = 1 };
            _context.Employees.Add(e);
            _context.SaveChanges();

            EmployeeProject ep = new EmployeeProject();
            ep.EmployeeId = _context.Employees.Where(e => (e.FirstName == "test")&&(e.LastName == "test")).FirstOrDefault().EmployeeId;           
            ep.ProjectId = _context.Projects.Where(p => p.Name == "Roga&Kopyta_Project5").FirstOrDefault().ProjectId;
            ep.Rate = 50000;
            ep.StartedDate = DateTime.Now;
            _context.EmployeeProjects.Add(ep);
            _context.SaveChanges();
        }

        public void FifthLinqTask()
        {
            var emp = _context.Employees.Where(e => (e.FirstName == "test") && (e.LastName == "test")).FirstOrDefault();
            var eps = _context.EmployeeProjects.Where(epro => epro.EmployeeId == emp.EmployeeId);
            _context.Employees.Remove(emp);
            foreach(var i in eps)
            {
                _context.EmployeeProjects.Remove(i);
            }
            _context.SaveChanges();
        }
    }
}
