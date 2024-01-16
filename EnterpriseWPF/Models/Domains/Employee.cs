using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseWPF.Models.Domains
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateToEmployee { get; set; }
        public string DateToDown { get; set; }
        public int EmployeeNumer { get; set; }
        public double Paycheck { get; set; }
        public string Comments { get; set; }

    }
}
