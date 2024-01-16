using EnterpriseWPF.Commands;
using EnterpriseWPF.Models;
using EnterpriseWPF.Models.Domains;
using EnterpriseWPF.Models.Wrappers;
using EnterpriseWPF.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EnterpriseWPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private Repository _repository = new Repository();
        public MainViewModel()
        {
            //using (var context = new ApplicationDbContext())
            //{
            //    var employees = context.Employees.ToList();
            //}
            

            AddEmployeeCommand = new RelayCommand(AddEmployee);
            EditEmployeeCommand = new RelayCommand(EditEmployee, CanEditEmpoloyee);
            DownEmployeeCommand = new RelayCommand(DownEmployee, CanDownEmpoloyee);
            RefreshEmployeeCommand = new RelayCommand(RefreshEmployee);
            UserSettingsCommand = new RelayCommand(UserSettings);
           

            if (ConnectSqlStatus())
            {
                var loginApplicationWindow = new LoginApplicationView();
                loginApplicationWindow.ShowDialog();
                InitGroups();
                RefreshDiary();
            }
            else
                SqlConnectionError(Application.Current.MainWindow);


        }

        public ICommand AddEmployeeCommand { get; set; }
        public ICommand EditEmployeeCommand { get; set; }
        public ICommand DownEmployeeCommand { get; set; }
        public ICommand RefreshEmployeeCommand { get; set; }
        public ICommand UserSettingsCommand { get; set; }

        private ObservableCollection<EmployeeWrapper> _employees;

        public ObservableCollection<EmployeeWrapper> Employees
        {
            get
            { return _employees; }

            set
            {
                _employees = value;
                OnPropertyChanged();
            }

        }

        private EmployeeWrapper _selectedEmployee;

        public EmployeeWrapper SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        private List<string> _groups;

        public List<string> Groups 
        { 
            get { return _groups; }
            set
            { 
                _groups = value; 
                OnPropertyChanged(); 
            }
        }

        private string _selectedValueGroup;

        public string SelectedValueGroup
        {
            get { return _selectedValueGroup; }
            set 
            {
                _selectedValueGroup = value;
                OnPropertyChanged();
            }
        }

        private void AddEmployee(object obj)
        {
            var addEditWindow = new AddEditEmployeeView();
            addEditWindow.ShowDialog();
            RefreshDiary();
        }


        private void EditEmployee(object obj)
        {
            var addEditWindow = new AddEditEmployeeView(SelectedEmployee);
            addEditWindow.ShowDialog();
            RefreshDiary();
        }

        private bool CanEditEmpoloyee(object obj)
        {
            return SelectedEmployee != null && SelectedEmployee.DateToDown == null;
        }

        private void DownEmployee(object obj)
        {
            var addEditWindow = new AddEditEmployeeView(SelectedEmployee, true);
            addEditWindow.ShowDialog();
        }

        private bool CanDownEmpoloyee(object obj)
        {
            return SelectedEmployee != null && SelectedEmployee.DateToDown == null;
        }

        private void RefreshEmployee(object obj)
        {
            RefershGroups();
        }

        private void RefreshDiary()
        {
            Employees = new ObservableCollection<EmployeeWrapper>(_repository.GetEmployes());
        }

        private void UserSettings(object obj)
        {
            var userSettingWindow = new UserSettingsView();
            userSettingWindow.ShowDialog();
        }

        private bool ConnectSqlStatus()
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    context.Database.Connection.Open();
                    context.Database.Connection.Close();
                }
                catch(SqlException) 
                {
                    return false;
                }
                return true;
            }
        }

        private async void SqlConnectionError(Window window)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync("Błąd", "Błąd połączenia z bazą SQL. Czy chcesz zmienić dane logowania SQL?", MessageDialogStyle.AffirmativeAndNegative);
            if(dialog == MessageDialogResult.Affirmative)
            {
                var userSettingsWindow = new UserSettingsView();
                userSettingsWindow.ShowDialog();
            }
            else
            {
                window.Close();
            }
        }

        private void  RefershGroups()
        {
            if (SelectedValueGroup == "Wszyscy")
                RefreshDiary();
            else if(SelectedValueGroup == "Zatrudnieni")
            {
                var employees = _repository.GetEmployes();
                var employeesWD = new ObservableCollection<EmployeeWrapper>();
                foreach (var employee in employees) 
                {
                    if(employee.DateToDown == null)
                    {
                        employeesWD.Add(employee);
                    }

                }
                Employees = employeesWD;
            }
            else
            {
                var employees = _repository.GetEmployes();
                var employeesWD = new ObservableCollection<EmployeeWrapper>();
                foreach (var employee in employees)
                {
                    if (employee.DateToDown != null)
                    {
                        employeesWD.Add(employee);
                    }

                }
                Employees = employeesWD;
            }
        }
        private void InitGroups()
        {
            Groups = new List<string>()
            {
                "Wszyscy",
                "Zatrudnieni",
                "Zwolnieni"
            };

            SelectedValueGroup = "Wszyscy";
        }
    }
}
