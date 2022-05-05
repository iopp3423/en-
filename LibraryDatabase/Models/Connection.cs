using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;

namespace LibruryDatabase.Models
{
    internal class Connection
    {
        private static MySqlConnection dbconn;

        public static MySqlConnection getConnection()
        {
            if(dbconn == null)
            {
                dbconn = new MySqlConnection(Constants.getQuery);
            }
            return dbconn;
        }

        public static MySqlConnection getConnection(string getQuery)
        {
            if(dbconn == null)
            {
                MySqlConnection dbconn = new MySqlConnection(getQuery);
            }
            return dbconn;
        }
    }
}
