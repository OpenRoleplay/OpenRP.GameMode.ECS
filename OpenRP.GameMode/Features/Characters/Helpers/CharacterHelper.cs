using Dapper;
using MySql.Data.MySqlClient;
using OpenRP.GameMode.Configuration;
using OpenRP.GameMode.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpenRP.GameMode.Features.Characters.Helpers
{
    public static class CharacterHelper
    {
        public static List<Character> LoadCharacters(string username)
        {
            MySqlConnection sqlConnection = new MySqlConnection(ConfigManager.Instance.Data.ConnectionString);
            sqlConnection.Open();

            List<Character> characters = sqlConnection.Query<Character>("SELECT * FROM characters AS c JOIN accounts AS a ON a.Id = c.AccountId WHERE a.Username = @username", new { username }).ToList();

            sqlConnection.Close();

            return characters;
        }
    }
}
