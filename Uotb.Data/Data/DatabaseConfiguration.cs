using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Uotb.Data.Data
{
    public class DatabaseConfiguration : ConfigurationBase
    {
        private readonly string DBConnectionKey = "SQL-Server";
        public string GetDataConnectionString()
        {
            return "Server=.\\SQLEXPRESS;Initial Catalog=Uotb;Integrated Security=True;MultipleActiveResultSets=True";
            // TODO: change when connecting to real project
            //return GetConfiguration().GetConnectionString(DBConnectionKey);
        }
    }
}
