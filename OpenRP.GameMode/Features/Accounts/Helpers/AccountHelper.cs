using Dapper;
using MySql.Data.MySqlClient;
using OpenRP.GameMode.Configuration;
using OpenRP.GameMode.Data.Models;
using OpenRP.GameMode.Features.Accounts.Components;
using SampSharp.Entities.SAMP;
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

        public static Account LoadMainAccount(string username)
        {
            MySqlConnection sqlConnection = new MySqlConnection(ConfigManager.Instance.Data.ConnectionString);
            sqlConnection.Open();

            Account mainAccount = sqlConnection.QuerySingle<Account>("SELECT * FROM accounts WHERE Username = @username", new { username });

            sqlConnection.Close();

            return mainAccount;
        }

        public static bool CheckPassword(string username, string password)
        {
            try
            {

                MySqlConnection sqlConnection = new MySqlConnection(ConfigManager.Instance.Data.ConnectionString);
                sqlConnection.Open();

                Account account = sqlConnection.QuerySingle<Account>("SELECT Password FROM accounts WHERE Username = @username", new { username });

                sqlConnection.Close();

                if (account != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                    {
                        return true;
                    }
                }
            }
            catch (InvalidOperationException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public static bool TryToLoginPlayer(Player player, string username, string password)
        {
            AccountComponent accountComponent = player.GetComponent<AccountComponent>();

            if (CheckPassword(username, password))
            {
                accountComponent.Account = AccountHelper.LoadMainAccount(username);
                player.SendClientMessage("Logged in");
                //player.main_account.characters = CharacterHelper.LoadCharacters(username);

                //CharacterDialogs.OpenCharacterListDialog(player);
                return true;
            }
            player.SendClientMessage("Not logged in");
            return false;
        }
    }
}
