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

            MySqlConnection logRecord = new MySqlConnection(Constants.getQuery);
            
            logRecord.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.InsertlogQuery, DateTime.Now, name, record, log), logRecord);
            Command.ExecuteNonQuery();
            
        }

        public void Storelog()
        {

            MySqlConnection user = new MySqlConnection(Constants.getQuery);
            
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

        public void RemoveLog(string number) // 로그 제거
        {

            MySqlConnection book = new MySqlConnection(Constants.getQuery);
            
                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.LogDeleteQuery, number), book);
                Command.ExecuteNonQuery();
            
        }

        public void RemoveAllLog() // 전체 로그데이터 제거
        {
            MySqlConnection book = new MySqlConnection(Constants.getQuery);
            
                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.RemoveAllLog), book);
                Command.ExecuteNonQuery();
            
        }

        public void RemoveDesktopFile()//데스크탑 파일 제거
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Log";
            Directory.Delete(desktopPath, recursive: Constants.isPassing);          
        }



        public void LogWrite() //바탕화면에 로그 저장
        {
            string DirectotyPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Log";
            string FilePath = DirectotyPath + "\\Log_" + DateTime.Today.ToString("MMdd") + ".log";
            string temp;

            DirectoryInfo directory = new DirectoryInfo(DirectotyPath);
            FileInfo file = new FileInfo(FilePath);


            if (!directory.Exists) Directory.CreateDirectory(DirectotyPath);

            if (!file.Exists)
            {
                StreamWriter writer = new StreamWriter(FilePath);
                
                foreach (LogVO x in LogData.Get().PrintLog)
                {
                    temp = string.Format("{0} {1} {2} {3} {4}", x.number, x.dateTime, x.name, x.record, x.log);
                    writer.WriteLine(temp);

                }
                writer.Close();
                
            }
            else
            {
                StreamWriter writer = File.AppendText(FilePath);
                
                foreach (LogVO x in LogData.Get().PrintLog)
                {
                    temp = string.Format("{0} {1} {2} {3} {4}", x.number, x.dateTime, x.name, x.record, x.log);
                    writer.WriteLine(temp);

                }
                writer.Close();
                
            }
        }

        public bool VerifyLogExistence(string Number) // 로그존재확인
        {
            foreach (LogVO x in LogData.Get().PrintLog)
            {
                if (x.number == Number) return Constants.isPassing;
            }
            return Constants.isFail;
        }

    }
}
