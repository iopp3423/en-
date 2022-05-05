using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;
using System.IO;


namespace LibruryDatabase.Models
{
    internal class LogDAO
    {

        private MySqlConnection conn;

        public MySqlConnection connection()
        {
            conn = Connection.getConnection();
            return conn;
        }

        
        public void StoreLog(string id, string record, string log) // 로그 추가
        {

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.InsertlogQuery, DateTime.Now, id, record, log), conn);
            Command.ExecuteNonQuery();
            conn.Close();
        }





        public void close()
        {
            conn.Close();
        }

    }
    
}
