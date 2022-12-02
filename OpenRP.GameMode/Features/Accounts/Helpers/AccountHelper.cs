using MySql.Data.MySqlClient;
using OpenRP.GameMode.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Features.Accounts.Helpers
{
    public class AccountHelper
    {
        public static bool DoesAccountExist(string username)
        {
            MySqlConnection sqlConnecton = new MySqlConnection(ConfigManager.Instance.Data.ConnectionString);
            sqlConnecton.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS AccountsFound FROM accounts WHERE accounts.Username = @name", sqlConnecton);
            cmd.Parameters.AddWithValue("@name", username);
            cmd.Prepare();
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            int accounts_found = dr.GetInt32("AccountsFound");

            sqlConnecton.Close();

            if (accounts_found > 0)
            {
                return true;
            }
            return false;
        }
    }
}
