using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibruryDatabase.Models
{
    internal class BorrowUserVO
    {
        public string id;
        public string number;
        public string title;
        public string author;
        public string publish;
        public string borrowbook;
        public string returnbook;


        public BorrowUserVO(string id, string number, string title, string author, string publish, string borrowbook, string returnbook)
        {
            this.id = id;
            this.number = number;
            this.title = title;
            this.author = author;
            this.publish = publish;
            this.borrowbook = borrowbook;
            this.returnbook = returnbook;
        }

        public BorrowUserVO()
        {

        }

        

    }
}
