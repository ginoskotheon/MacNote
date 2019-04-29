using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacNote.DataSource
{
    public static class DBConnection
    {
        const string APP_SETTING_CON_NAME = "ActiveConnection";
        private static string _connectionString = null;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                    LoadConnectionString();
                return _connectionString;
            }
            set { _connectionString = value; }
        }

       
        private static void LoadConnectionString()
        {
            string conName;
            ConnectionStringSettings cs;
            conName = ConfigurationManager.AppSettings[APP_SETTING_CON_NAME];
            if (string.IsNullOrWhiteSpace(conName))
                throw new ApplicationException("Cound not find app setting value " + APP_SETTING_CON_NAME + "in config file");

            cs = ConfigurationManager.ConnectionStrings[conName];
            if (cs == null)
                throw new ApplicationException("Could not retrieve connetion string " + conName);

            if (string.IsNullOrWhiteSpace(cs.ConnectionString))
                throw new ApplicationException("specify connection string attribute for " + conName);

            _connectionString = cs.ConnectionString;

        }
    }
}
