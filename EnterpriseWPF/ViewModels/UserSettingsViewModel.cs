using EnterpriseWPF.Commands;
using EnterpriseWPF.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EnterpriseWPF.ViewModels
{
    public class UserSettingsViewModel : BaseViewModel
    {
        public UserSettingsViewModel() 
        {
            ConfirmCommand = new AsyncRelayCommand(Confirm);
            CloseCommand = new RelayCommand(Close);
            UserSettings = new UserSettings();
        }

        public ICommand ConfirmCommand {  get; set; }
        public ICommand CloseCommand { get; set; }

        private UserSettings _userSettings;
        public UserSettings UserSettings 
        {
            get { return _userSettings; } 
            set
            {
                _userSettings = value;
                OnPropertyChanged();
            }
        }

        private async Task Confirm(object obj)
        {
            await AsyncUpadateUserSettings();
            CloseWindow(obj as Window);
            RestartAplication();
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }

        private async Task AsyncUpadateUserSettings()
        {
            await Task.Run(() => { _userSettings.AddToSettings(_userSettings); });
        }

        private void RestartAplication()
        {
            Application.Current.Shutdown();
            Process.Start(Application.ResourceAssembly.Location);
        }
    }
}
