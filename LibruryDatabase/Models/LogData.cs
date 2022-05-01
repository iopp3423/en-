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
        private string number;
        private string time;
        private string name;
        private string record;
        private string log;

        public List<LogVO> PrintLog = new List<LogVO>(); // Log리스트 생성

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
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.InsertlogQuery, DateTime.Now, name, record, log), logRecord);
                Command.ExecuteNonQuery();
            }
        }

        public void Storelog()
        {

            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(Constants.logQuery, user);
                MySqlDataReader userInformation = Command.ExecuteReader();

                while (userInformation.Read())
                {
                    number = userInformation["number"].ToString();
                    time = userInformation["TIME"].ToString();
                    name = userInformation["name"].ToString();
                    record = userInformation["record"].ToString();
                    log = userInformation["log"].ToString();

                    PrintLog.Add(new LogVO(number, time, name, record, log));
                }
                userInformation.Close();
            }          

        }

        public void RemoveLog(string number) // 로그 제거
        {

            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.LogDeleteQuery, number), book);
                Command.ExecuteNonQuery();
            }
        }

    }
}
