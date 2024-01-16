using Avalonia.Controls.Notifications;
using EnterpriseWPF.Commands;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EnterpriseWPF.ViewModels
{
    public class LoginApplicationViewModel : BaseViewModel
    {
        public LoginApplicationViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm);
            CloseCommand = new RelayCommand(Close);
        }

        public ICommand ConfirmCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        private string _login;

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private void Confirm(object obj)
        {
            if (Login == "admin" && Password == "1234")
                CloseWindow(obj as Window);
            else
            {
                ProgresBarMessage(obj as Window);
            }
                
            
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
            Application.Current.Shutdown();
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }

        private async void ProgresBarMessage(Window window)
        {
            var progresBarrMessage = window as MetroWindow;
            var controller = await progresBarrMessage.ShowMessageAsync("Błąd", "Logowanie nie powiodło się, Sprubój ponownie!");
        }

    }
}
