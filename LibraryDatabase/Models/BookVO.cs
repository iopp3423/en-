using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibruryDatabase.Models
{
    internal class BookVO
    {
        public string number;
        public string title;
        public string author;
        public string publisher;
        public string publishday;
        public string price;
        public string isbn;
        public string quantity;


        public BookVO()
        {

        }

        public BookVO(string number, string title, string author,  string publisher, string publishday, string price, string isbn, string quantity)
        {
            this.number = number;
            this.title = title;
            this.author = author;          
            this.publisher = publisher;
            this.publishday = publishday;
            this.price = price;
            this.isbn = isbn;
            this.quantity = quantity;
        }

    }
}
