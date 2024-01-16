using EnterpriseWPF.Models.Converters;
using EnterpriseWPF.Models.Domains;
using EnterpriseWPF.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseWPF
{
    public class Repository
    {

        public List<EmployeeWrapper> GetEmployes() 
        {
            using (var context = new ApplicationDbContext())
            {
                var employes = context.Employees.AsQueryable();
                
                return employes.ToList().Select(x => x.ToWrapper()).ToList();
            }
        }

        public void AddEmployee(EmployeeWrapper emplyeeWrapper)
        {
            var empoloy = emplyeeWrapper.ToDao();
            using(var context = new ApplicationDbContext())
            {
                var dbEmployee = context.Employees.Add(empoloy);
                context.SaveChanges();
            }
        }

        public void UpdateEmployee(EmployeeWrapper emplyeeWrapper)
        {
            var employee = emplyeeWrapper.ToDao();

            using (var context = new ApplicationDbContext())
            {
                UpdateEmployeeProperties(context, employee);
                context.SaveChanges();
            }
        }

        private void UpdateEmployeeProperties(ApplicationDbContext context, Employee employee)
        {
            var employToUpdate = context.Employees.Find(employee.Id);
            employToUpdate.FirstName = employee.FirstName;
            employToUpdate.LastName = employee.LastName;
            employToUpdate.DateToEmployee = employee.DateToEmployee;
            employToUpdate.DateToDown = employee.DateToDown;
            employToUpdate.EmployeeNumer = employee.EmployeeNumer;
            employToUpdate.Paycheck = employee.Paycheck;
            employToUpdate.Comments = employee.Comments;
        }

        private void DeleteEmployee(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var employeeToDelete = context.Employees.Find(id);
                context.Employees.Remove(employeeToDelete);
                context.SaveChanges();
            }
        }

       
    }
}
