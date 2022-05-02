using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibruryDatabase.Models
{
    internal class BookVO
    {
        public string title;
        public string author;
        public string price;
        public string publisher;
        public string publishday;
        public string isbn;
        public string quantity;


        public BookVO(string title, string author, string price, string publisher, string publishday, string isbn, string quantity)
        {
            this.title = title;
            this.author = author;
            this.price = price;
            this.publisher = publisher;
            this.publishday = publishday;
            this.isbn = isbn;
            this.quantity = quantity;
        }

        public BookVO()
        {

        }

    }
}
