using EnterpriseWPF.Commands;
using EnterpriseWPF.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EnterpriseWPF.ViewModels
{
    public class AddEditEmployeeViewModel : BaseViewModel
    {
        Repository _repository = new Repository();
        public AddEditEmployeeViewModel(EmployeeWrapper employee = null, bool employeeToDown = false) 
        {
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
            CloseCommand = new RelayCommand(Close);

            if(employee == null)
                Employee = new EmployeeWrapper();
            else
            {
                Employee = employee;
                IsUpdate = true;
            }

            if(employeeToDown)
            {
                TextBoxEnabled = false;
            }
            else
            {
                TextBoxEnabled = true;
            }
        }

        public ICommand ConfirmCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        public bool ReverseTextBoxEnabled { get { return !TextBoxEnabled; } }

        private bool _textBoxEnabled;

        public bool TextBoxEnabled 
        {
            get { return _textBoxEnabled; }
            set
            {
                _textBoxEnabled = value;
                OnPropertyChanged();
            }
        }

        private EmployeeWrapper _employee {  get; set; }

        public EmployeeWrapper Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged();
            }

        }

        private bool _isUpdate;

        public bool IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }

        private void Confirm(object obj)
        {
            if (!Employee.IsValid)
                return;
            if (!IsUpdate)
                AddStudent();
            else
                UpdateStudent();

            CloseWindow(obj as Window);

        }

        private void AddStudent()
        {
            _repository.AddEmployee(Employee);
        }

        private void UpdateStudent()
        {
            _repository.UpdateEmployee(Employee);
        }

        private bool CanConfirm(object obj)
        {
            return Employee.IsValid;
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
