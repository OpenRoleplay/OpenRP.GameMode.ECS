using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenRP.GameMode.Features.Inventories.Helpers
{
    public class ItemAdditionalData
    {
        // Properties
        private string custom_data { get; set; }
        private Dictionary<string, string> custom_data_dictionary { get; set; }

        // Constructor
        private ItemAdditionalData(string custom_data)
        {
            this.custom_data = custom_data;
            this.custom_data_dictionary = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(this.custom_data))
            {
                string[] custom_data_array;
                if (custom_data.Contains(";"))
                {
                    custom_data_array = custom_data.Split(";");
                }
                else
                {
                    custom_data_array = new[] { this.custom_data };
                }

                foreach (string data in custom_data_array)
                {
                    string[] seperate_values = custom_data.Split("=");

                    this.custom_data_dictionary.Add(seperate_values[0], seperate_values[1]);
                }
            }
        }

        // Functions
        public void SetBoolean(string key, bool value)
        {
            if (value)
            {
                this.custom_data_dictionary[key] = "1";
            }
            else
            {
                this.custom_data_dictionary.Remove(key);
            }
        }

        public void SetString(string key, string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                this.custom_data_dictionary[key] = value;
            }
            else
            {
                this.custom_data_dictionary.Remove(key);
            }
        }

        public string GetString(string key)
        {
            if (this.custom_data_dictionary.TryGetValue(key, out string value))
            {
                return value;
            }
            return null;
        }

        public int? GetInt(string key)
        {
            if (int.TryParse(this.GetString(key), out int value))
            {
                return value;
            }
            return null;
        }

        public bool? GetBoolean(string key)
        {
            try
            {
                return Convert.ToBoolean(this.GetInt(key));
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        // Static Functions
        public static ItemAdditionalData Parse(string custom_data)
        {
            ItemAdditionalData parser = new ItemAdditionalData(custom_data);
            return parser;
        }

        public override string ToString()
        {
            bool firstValue = true;
            StringBuilder newCustomDataString = new StringBuilder();

            this.custom_data_dictionary = this.custom_data_dictionary.OrderBy(i => i.Key).ToDictionary(i => i.Key, i => i.Value);

            foreach (KeyValuePair<string, string> key_value in this.custom_data_dictionary)
            {
                if (!firstValue)
                {
                    newCustomDataString.Append(";");
                }
                newCustomDataString.Append(string.Format("{0}={1}", key_value.Key, key_value.Value));
            }

            this.custom_data = newCustomDataString.ToString();

            return this.custom_data;
        }
    }
}
