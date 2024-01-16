using EnterpriseWPF.Models.Domains;
using EnterpriseWPF.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseWPF.Models.Converters
{
    public static class EmployeeConverter
    {
        public static EmployeeWrapper ToWrapper(this Employee model)
        {
            return new EmployeeWrapper
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateToEmployee = model.DateToEmployee,
                DateToDown = model.DateToDown,
                EmployeeNumer = model.EmployeeNumer,
                Paycheck = model.Paycheck,
                Comments = model.Comments,

            };
            
        }

        public static Employee ToDao(this EmployeeWrapper model) 
        {
            return new Employee
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateToEmployee = model.DateToEmployee,
                DateToDown = model.DateToDown,
                EmployeeNumer = (int)model.EmployeeNumer,
                Paycheck = (double)model.Paycheck,
                Comments = model.Comments,
            };
        }
    }
}
