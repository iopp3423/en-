using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;

namespace LibruryDatabase.Models
{
    internal class LogVO
    {
        public string dateTime;
        public string name;
        public string record;
        public string log;

        public LogVO(string dateTime, string name, string record, string log)
        {
            this.dateTime = dateTime;
            this.name = name;
            this.record = record;
            this.log = log;
        }

        public LogVO()
        {

        }

        public void PrintUserData()
        {
            

            using (MySqlConnection user = new MySqlConnection(Constants.logQuery))
            {
                user.Open();

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, user);
                MySqlDataReader userInformation = Command.ExecuteReader();

                while (userInformation.Read())
                {
 
                    Console.WriteLine(userInformation["TIME"].ToString());
                    Console.WriteLine(userInformation["name"].ToString());
                    Console.WriteLine(userInformation["record"].ToString());   
                    Console.WriteLine(userInformation["log"].ToString());         
                }
                userInformation.Close();
            }
        }
    }
}
