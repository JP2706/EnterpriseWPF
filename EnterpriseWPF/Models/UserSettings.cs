using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseWPF.Models
{
    
    public class UserSettings
    {
        public UserSettings()
        {
           SqlServerName = Properties.Settings.Default.SqlServerName;
           SqlDatabaseName = Properties.Settings.Default.SqlDatabaseName;
           SqlLogin = Properties.Settings.Default.SqlLogin;
           SqlPassword = Properties.Settings.Default.SqlPassword;
        }
            //private bool _isSqlServerNameValid;
            //private bool _isSqlDatabaseNameValid;
            //private bool _isSqlLoginValid;
            //private bool _isSqlPasswordValid;

            public string SqlServerName { get; set; }
            public string SqlDatabaseName { get; set; }
            public string SqlLogin { get; set; }
            public string SqlPassword { get; set; }

            public void AddToSettings(UserSettings uS)
            {
                Properties.Settings.Default.SqlServerName = uS.SqlServerName;
                Properties.Settings.Default.SqlDatabaseName = uS.SqlDatabaseName;
                Properties.Settings.Default.SqlLogin = uS.SqlLogin;
                Properties.Settings.Default.SqlPassword = uS.SqlPassword;
                Properties.Settings.Default.Save();
            }


            
    }
}

