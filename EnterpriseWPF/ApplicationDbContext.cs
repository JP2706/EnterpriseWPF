using EnterpriseWPF.Models.Domains;
using EnterpriseWPF.Models.Configurations;
using System;
using System.Data.Entity;
using System.Linq;

namespace EnterpriseWPF
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext()
            : base(ConnectionStringBuild())
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
        }


        private static string ConnectionStringBuild()
        {
            return $"Server={Properties.Settings.Default.SqlServerName};Database={Properties.Settings.Default.SqlDatabaseName};User Id={Properties.Settings.Default.SqlLogin};Password={Properties.Settings.Default.SqlPassword};";
        }

    }

  
}