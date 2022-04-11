using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EnLibrary3.Controls
{
    using EnLibrary3.Controls;
    using EnLibrary3.Views;
    internal class BookBorrow
    {
        BookSearch Search = new BookSearch();
        Print View = new Print();
        bool isFinished = true;
        ConsoleKeyInfo cursur;
        Regex BookCheck = new Regex(@"^[가-힣a-zA-Z0-9]{1,15}$");
        public static bool existing = false;
        string checking;
        bool passing;
        string book;

        public void BorrowBook()
        {
            Console.Clear();
            Console.WriteLine("대여할 책 제목 :");
            int x = 17, y = 0;
            Search.NameSearch(); // 책 제목으로 찾기

        }

        public void NotExist()
        {
            LoginAfter Menu = new LoginAfter();
            if (existing == false)
            {
                Console.Clear();
                View.PrintBookList();
                Console.WriteLine("찾으시는 책이 없습니다. 메뉴로 돌아가시겠습니까?");
                Console.Write("종료는 ESC를 눌러주세요");
                cursur = Console.ReadKey(true);
                if (cursur.Key == ConsoleKey.Enter) { Console.Clear(); Menu.BookMenu(); }
                else if (cursur.Key == ConsoleKey.Escape) return;
                View.PrintBookList();
                Console.ReadLine();
            }
        }
    }
}
