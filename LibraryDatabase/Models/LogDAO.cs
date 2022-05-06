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
    public class LogDAO
    {

        private MySqlConnection conn;

        public MySqlConnection connection()
        {
            conn = Connection.getConnection();
            return conn;
        }


        public List<LogDTO> StoreLogReturn() // 로그목록 리턴
        {
            List<LogDTO> log = new List<LogDTO>();

            conn.Open();
            //ExecuteReader를 이용하여
            //연결 모드로 데이타 가져오기
            MySqlCommand Command = new MySqlCommand(Constants.logQuery, conn);
            MySqlDataReader Data = Command.ExecuteReader();

            while (Data.Read())
            {
                log.Add(new LogDTO(Data["number"].ToString(), Data["TIME"].ToString(), Data["name"].ToString(), Data["record"].ToString(), Data["log"].ToString()));
            }
            conn.Close();
            return log;
        }

        public void StoreLog(string id, string record, string log) // 로그 추가
        {

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.InsertlogQuery, DateTime.Now, id, record, log), conn);
            Command.ExecuteNonQuery();
            conn.Close();
        }



        public void RemoveLog(string number) // 로그 제거
        {

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.LogDeleteQuery, number), conn);
            Command.ExecuteNonQuery();
            conn.Close();

        }

        public void RemoveAllLog() // 전체 로그데이터 제거
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.RemoveAllLog), conn);
            Command.ExecuteNonQuery();
            conn.Close();

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
            conn.Open();
            //ExecuteReader를 이용하여
            //연결 모드로 데이타 가져오기
            MySqlCommand Command = new MySqlCommand(Constants.logQuery, conn);
            MySqlDataReader Data = Command.ExecuteReader();

            while (Data.Read())
            {
                if (Data["number"].ToString() == Number)
                {
                    conn.Close();
                    return Constants.isPassing;
                }
            }
            conn.Close();
            return Constants.isFail;
        }

        public void close()
        {
            conn.Close();
        }

    }
    
}
