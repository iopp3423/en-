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
            BookVO DataStructure = new BookVO ("1","자료구조","세종대학교","국형준", "20000원", "2개");
            BookVO Algorithm = new BookVO ("2", "Do it! 알고리즘 코딩 테스트 : 자바 편 ", "이지스퍼블리싱","김종관", "28,800원", "4개" );
            BookVO Amagon = new BookVO("3"," 생활코딩! 아마존 웹 서비스", "위키북스", "이고잉", "22,500원", "3개" );
            BookVO Java = new BookVO("4","생활코딩! 자바 프로그래밍 입문",  "위키북스",  "이고잉", "24,300원",  "3개" );
            BookVO Test = new BookVO("5", " Do it! 알고리즘 코딩 테스트 — 자바 편 ", "이지스퍼블리싱",  "김종관", "22000원",  "4개" );
            BookVo.Add(DataStructure);
            BookVo.Add(Algorithm);
            BookVo.Add(Amagon);
            BookVo.Add(Java);
            BookVo.Add(Test);
            /*
            BookVO Book = new BookVO(); /// 문제 있으면 이거임 아마
            BookVO DataStructure = new BookVO("1", "자료구조 및 실습", "세종대학교", "국형준", "20000원", "23333");
            BookVO Book2 = new BookVO();
            
            Book2.bookNumber = "13333";
            Book2.name = "자료구조 및 실습3333";
            Book2.publisher = "세종대학교3333";
            Book2.author = "국형준3333";
            Book2.price = "20000원3333";
            Book2.quantity = "23333";
            
            BookVo.Add(DataStructure);
            BookVo.Add(Book2);*/

            print();
        }
        public void print()
        {
            foreach (BookVO Book in BookVo)
            {
                Console.WriteLine(Book);
                Console.WriteLine("────────────────────────────────────────────────────────────");
            }
            Console.SetCursorPosition(30, 0);
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
            return "책번호 : " + bookNumber + "\n책이름 : " + name + "\n출판사 : " + publisher + "\n저자 : " + author + "\n가격: " + price + "\n수량: " + quantity;
        }

        public void BookPrint()
        {
            BookVO DataStructure = new BookVO { BookNumber = "1\n", Name = "자료구조\n", publisher = "세종대학교\n", author = "국형준\n", price = "20000원\n", Quantity = "2개\n" };
            BookVO Algorithm = new BookVO { BookNumber = "2\n", Name = "Do it! 알고리즘 코딩 테스트 : 자바 편 \n", publisher = "이지스퍼블리싱\n", author = "김종관\n", price = "28,800원\n", Quantity = "4개\n" };
            BookVO Amagon = new BookVO { BookNumber = "3\n", Name = " 생활코딩! 아마존 웹 서비스\n", publisher = "위키북스\n", author = "이고잉\n", price = "22,500원\n", Quantity = "3개\n" };
            BookVO Java= new BookVO { BookNumber = "4\n", Name = "생활코딩! 자바 프로그래밍 입문\n", publisher = "위키북스\n", author = "이고잉\n", price = "24,300원\n", Quantity = "3개\n" };
            BookVO Test = new BookVO { BookNumber = "5\n", Name = " Do it! 알고리즘 코딩 테스트 — 자바 편 \n", publisher = "이지스퍼블리싱\n", author = "김종관\n", price = "22000원\n", Quantity = "4개\n" };     
            Console.WriteLine(DataStructure);
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine(Algorithm);
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine(Amagon);
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine(Java);
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine(Test);
        }
    }
}
