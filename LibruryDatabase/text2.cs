using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;
using LibruryDatabase.Models;

namespace LibruryDatabase
{
    internal class text2
    {
        public List<LogVO> Log = new List<LogVO>();
        string time;
        string name;
        string record;
        string log;

        public void storelog()
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

                    time = userInformation["TIME"].ToString();
                    name = userInformation["name"].ToString();
                    record = userInformation["record"].ToString();
                    log = userInformation["log"].ToString();

                    Log.Add(new LogVO(time, name, record, log));
                }
                userInformation.Close();
            }
            

            foreach (LogVO x in Log)
            {
                Console.Write(x.dateTime+ "  ");
                Console.Write(x.name + "  ");
                Console.Write(x.record + "  ");
                Console.WriteLine(x.log);
            }
            
        }

        public void PrintUserData()
        {



            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, user);
                MySqlDataReader userInformation = Command.ExecuteReader();

                while (userInformation.Read())
                {
                    Console.Write("아이디 :");
                    Console.WriteLine(userInformation["id"].ToString());
                    Console.Write("비밀번호 :");
                    Console.WriteLine(userInformation["pw"].ToString());
                    Console.Write("이름 :");
                    Console.WriteLine(userInformation["name"].ToString());
                    Console.Write("전화번호 :");
                    Console.WriteLine(userInformation["phone"].ToString());
                    Console.Write("나이 :");
                    Console.WriteLine(userInformation["age"].ToString());
                    Console.Write("주소 :");
                    Console.WriteLine(userInformation["address"].ToString());
                    Console.WriteLine("=======================================================================");
                }
                userInformation.Close();
            }
        }
    }
}
