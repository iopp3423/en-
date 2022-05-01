using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;

namespace LibruryDatabase.Models
{
    internal class LogData
    {
        private static LogData Log;

        public static LogData Get()
        {
            if (Log == null)
                Log = new LogData();
            return Log;
        }

        public void StoreLog(string name, string record, string log) // 로그 추가
        {

            using (MySqlConnection logRecord = new MySqlConnection(Constants.getQuery))
            {
                logRecord.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.logQuery, DateTime.Now, name, record, log), logRecord);
                Command.ExecuteNonQuery();
            }
        }

    }
}
