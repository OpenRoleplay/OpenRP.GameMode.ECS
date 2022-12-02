using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRP.GameMode.Configuration
{
    public class Config
    {
        public string ConnectionString { get; set; }

        public Config()
        {
            ConnectionString = "server=localhost;user=root;password=;database=openrp";
        }
    }
}
