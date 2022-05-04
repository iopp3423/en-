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
        public string number;
        public string dateTime;
        public string name;
        public string record;
        public string log;

        public LogVO(string number, string dateTime, string name, string record, string log)
        {
            this.number = number;
            this.dateTime = dateTime;
            this.name = name;
            this.record = record;
            this.log = log;
        }

        public LogVO()
        {

        }
       
    }
}
