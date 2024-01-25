using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace EnterpriseWPF.Models.Wrappers
{
    public class EmployeeWrapper : IDataErrorInfo 
    {
        public EmployeeWrapper() 
        {
            //EmployeeNumer = null;
            //Paycheck = null;
            DateToEmployee = DateTime.Now;
            //DateToDown = null;
        }
        

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateToEmployee { get; set; }
        public DateTime? DateToDown {  get; set; }
        public int EmployeeNumer {  get; set; }
        public decimal Paycheck { get; set; }
        public string Comments { get; set; }


        

        private bool _isFirstNameValid;
        private bool _isLastNameValid;
        //private bool _isDateToEmployeeValid;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case (nameof(FirstName)):
                        if (string.IsNullOrWhiteSpace(FirstName))
                        {
                            Error = "Pole Imię jest wymagane";
                            _isFirstNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isFirstNameValid = true;
                        }
                        break;
                    case (nameof(LastName)):
                        if (string.IsNullOrWhiteSpace(LastName))
                        {
                            Error = "Pole Nazwisko jest wymagane";
                            _isLastNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isLastNameValid = true;
                        }
                        break;
                    //case (nameof(DateToEmployee)):
                    //    if (DateToEmployee == null)
                    //    { 
                    //        Error = "Pole Data Zatrudenia jest wymagane";
                    //        _isDateToEmployeeValid = false;
                    //    }
                    //    else
                    //    {
                    //        Error = string.Empty;
                    //        _isDateToEmployeeValid = true;
                    //    }
                    //    break;
                    default:
                        break;
                }

                return Error;
            }
        }

        public string Error {  get; set; }

        public bool IsValid
        {
            get
            {
                return _isFirstNameValid & _isLastNameValid; //& _isDateToEmployeeValid;
            }

        }
    }
}
