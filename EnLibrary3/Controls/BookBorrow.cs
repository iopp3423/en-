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
        ListVO List = new ListVO();
        Print View = new Print();
        bool isFinished = true;
        ConsoleKeyInfo cursur;
        Regex BookCheck = new Regex(@"^[가-힣a-zA-Z0-9]{1,15}$");
        public static bool existing = false;

        public void BorrowBook()
        {
            string checking;
            bool passing;
            string book;

            Console.Clear();
            Console.WriteLine("대여할 책 제목 :\n");
            View.PrintBookList();
            Console.SetCursorPosition(17, 0);
            checking = Console.ReadLine();
            passing = BookCheck.IsMatch(checking);        

            if (passing == false) BorrowBook();
            else if (passing == true)
            {
                Console.Clear();
                foreach (BookVO list in List.BookList)
                {
                    if (list.name == checking)
                    {
                        Console.WriteLine(list);
                        Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
                        existing = true;
                    }
                }
                Console.WriteLine("책을 대여하시겠습니까?");
                NotExist();
                cursur = Console.ReadKey(true);
                if (cursur.Key == ConsoleKey.Enter) { Console.Clear(); Borrow();}
                else if (cursur.Key == ConsoleKey.Escape) return;
            }
        }      

        public void Borrow()
        {
            Console.Write("Helloworld");
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
                existing = true;
            }
        }
    }
}
