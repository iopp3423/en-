using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibruryDatabase.Models
{
    internal class BorrowBookDTO
    {
        public string id;
        public string number;
        public string title;
        public string author;
        public string publish;
        public string borrowbook;
        public string returnbook;

        public BorrowBookDTO()
        {

        }

        public BorrowBookDTO(string id, string number, string title, string author, string publish, string borrowbook, string returnbook)
        {
            this.id = id;
            this.number = number;
            this.title = title;
            this.author = author;
            this.publish = publish;
            this.borrowbook = borrowbook;
            this.returnbook = returnbook;
        }


        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Publish
        {
            get { return publish; }
            set { publish = value; }
        }
        public string Borrowbook
        {
            get { return borrowbook; }
            set { borrowbook = value; }
        }
        public string Returnbook
        {
            get { return returnbook; }
            set { returnbook = value; }
        }
    }
}
