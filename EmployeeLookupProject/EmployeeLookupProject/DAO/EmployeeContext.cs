using EmployeeLookupProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EmployeeLookupProject.DAO
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=EmployeeDatabase")
        {
        }
        public EmployeeContext(DbConnection connection)
        : base(connection, true)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}