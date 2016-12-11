using EmployeeLookupProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeLookupProject.DAO
{
    public class EmployeeInitializer : DropCreateDatabaseIfModelChanges<EmployeeContext>
    {

        //public override void InitializeDatabase(EmployeeContext context)
        //{
        //    context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
        //        , string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

        //    base.InitializeDatabase(context);
        //}


        protected override void Seed(EmployeeContext context)
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Will", LastName = "Smith", Address="700 E 400 S, Salt Lake City, Utah", Age= 45, Hobbies="Acting"},
                new Employee {FirstName = "Johnny", LastName = "Depp", Address="400 E 500 S, Salt Lake City, Utah", Age= 40, Hobbies="music"},
                new Employee {FirstName = "Leonardo", LastName = "DiCaprio", Address="1400 N 1300 S, Salt Lake City, Utah", Age= 55, Hobbies="Playing Football, acting"},
                new Employee {FirstName = "Robert", LastName = "Downey", Address="1300 E 1400 S, Salt Lake City, Utah", Age= 47, Hobbies="Listening music"},
                new Employee {FirstName = "Tom", LastName = "Cruise", Address="200 S 800 E, Salt Lake City, Utah", Age= 59, Hobbies="Acting"},
                new Employee {FirstName = "Brad", LastName = "Pitt", Address="1400 S 600 E, Salt Lake City, Utah", Age= 40, Hobbies="Reading"},
                new Employee {FirstName = "Bradley", LastName = "Cooper", Address="500 S 600 E, Salt Lake City, Utah", Age= 45, Hobbies="Singing"},
                new Employee {FirstName = "Jennifer", LastName = "Lawrence", Address="1500 S 1600 E, Salt Lake City, Utah", Age= 25, Hobbies="Reading"}

            };

            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();
        }
    }
}