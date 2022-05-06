using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibruryDatabase.Models
{

    public class BookDTO
    {
        public string number;
        public string title;
        public string author;
        public string publisher;
        public string publishday;
        public string price;
        public string isbn;
        public string quantity;
        public string description;


        public BookDTO()
        {

        }

        public BookDTO(string number, string title, string author, string publisher, string publishday, string price, string isbn, string quantity)
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
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public string Publishday
        {
            get { return publishday; }
            set { publishday = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
