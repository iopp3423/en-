using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary3.Models
{
    public class BookVO
    {
        private string bookNumber;
        public string name;
        public string publisher;
        public string author;
        private string price;
        private string quantity;
        public int number;

        public BookVO()
        {
            // 생성자
        }

        public BookVO(string bookNumber, string name, string publisher, string author, string price, string quantity)
        {
            this.bookNumber = bookNumber;
            this.name = name;
            this.publisher = publisher;
            this.author = author;
            this.price = price;
            this.quantity = quantity;
        }

        public string BookNumber
        {
            get { return bookNumber; }
            set { bookNumber = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public override string ToString()
        {
            return "책번호 : " + bookNumber + "\n책이름 : " + name + "\n출판사 : " + publisher + "\n저자   : " + author + "\n가격   : " + price + "\n수량   : " + quantity;
        }
    }
}
