using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Controls
{
    using Views;
    class BookVO
    {
        public List<BookVO> BookVo = new List<BookVO> ();
        BookVO Book = new BookVO(); /// 문제 있으면 이거임 아마
       
        private string bookNumber;
        private string name;
        private string publisher;
        private string author;
        private string price;
        private string quantity;

        public void NewBookStore()
        {

        }
        public void StoreBookLIst()
        {
            Book.bookNumber = "1";
            Book.name = "자료구조 및 실습";
            Book.publisher = "세종대학교";
            Book.author = "국형준";
            Book.price = "20000원";
            Book.quantity = "2";
            BookVo.Add(Book);
        }

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
        public  string Publisher
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
            return "Bookid : " + bookNumber + "Name : " + name + "Publisher : " + publisher + "Author" + author + "Price" + price + "Quantity" + quantity;
        }
    }
}
