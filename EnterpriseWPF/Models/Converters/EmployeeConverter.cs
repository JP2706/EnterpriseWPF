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
                DateToEmployee = DateTime.Parse(model.DateToEmployee),
                DateToDown = TryParse(model.DateToDown),
                EmployeeNumer = model.EmployeeNumer,
                Paycheck = (decimal)model.Paycheck,
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
                DateToEmployee = model.DateToEmployee.ToString(),
                DateToDown = TryParseS(model.DateToDown),
                EmployeeNumer = model.EmployeeNumer,
                Paycheck = (double)model.Paycheck,
                Comments = model.Comments,
            };
        }

        public static DateTime? TryParse(string text)
        {
            DateTime date;
            if (DateTime.TryParse(text, out date))
            {
                return date;
            }
            else
            {
                return null;
            }
        }

        public static string TryParseS(DateTime? date)
        {
            string text;
            if (date != null)
            {
                return text = date.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
