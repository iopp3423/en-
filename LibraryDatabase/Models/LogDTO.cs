using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibruryDatabase.Models
{
    public class LogDTO
    {
        public string number;
        public string dateTime;
        public string id;
        public string record;
        public string log;

        public LogDTO()
        {

        }

        public LogDTO(string number, string dateTime, string id, string record, string log)
        {
            this.number = number;
            this.dateTime = dateTime;
            this.id = id;
            this.record = record;
            this.log = log;
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public string DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Record
        {
            get { return record; }
            set { record = value; }
        }
        public string Log
        {
            get { return log; }
            set { log = value; }
        }
    }
}
