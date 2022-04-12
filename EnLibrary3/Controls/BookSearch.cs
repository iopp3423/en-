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
    internal class BookSearch
    {
       
        Print View = new Print();
        bool isFinished = true;
        Regex BookCheck = new Regex(@"^[가-힣a-zA-Z0-9]{1,15}$");
        Regex AuthorCheck = new Regex(@"^[가-힣a-zA-Z]{1,10}$");
        Regex PublishCheck = new Regex(@"^[가-힣a-zA-Z]{1,8}$");
        ListVO List = new ListVO();

        public static bool existing = false;

        ConsoleKeyInfo cursur;

        public void SearchBook()
        {
            Console.Clear();
            View.PrintSearchMenu();
            int x = 30, y = 0;
            View.PrintBookList();
            // 커서의 이동을 표현하는 것이 목적이므로 무한 루프를통해 커서표현을 반복
            while(isFinished)
            {
                // x 와 y 좌표에 커서를 표시하기위한 메서드
                Console.SetCursorPosition(x, y);

                cursur = Console.ReadKey(true);
                // 저장된 키의 정보에 대해 검색

                switch (cursur.Key)
                {
                    // 상
                    case ConsoleKey.UpArrow:
                        {
                            y--;
                            if (y < 0) y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            y++;
                            if (y > 2) y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            isFinished = true; 
                            if (y == 0) { Console.SetCursorPosition(20, 0); NameSearch(); isFinished = false; }
                            if (y == 1) { Console.SetCursorPosition(20, 1); AuthorSearch();isFinished = false; }
                            if (y == 2) { Console.SetCursorPosition(20, 2); PublishSearch();isFinished = false; }
                            break;
                        }

                    case ConsoleKey.Escape: // 종료
                        {
                            return;
                        }

                    default: break;

                }

            }
            
        }



        public void NameSearch()
        {
            LoginAfter Menu = new LoginAfter();
            string checking;
            bool passing;           
            string book;

            Console.Clear();
            View.PrintBookName();
            View.PrintBookList();
            Console.SetCursorPosition(20, 0);
            cursur = Console.ReadKey(true);
            if (cursur.Key == ConsoleKey.F5) { Console.Clear(); Menu.BookMenu(); }

            checking = Console.ReadLine();
            passing = BookCheck.IsMatch(checking);

            if (passing == false) NameSearch();
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
                NotExist();
                SearchBookAfter();
            }
            
        }
        public void AuthorSearch()
        {
            LoginAfter Menu = new LoginAfter();
            string checking;
            bool passing;
            string book;

            Console.Clear();
            View.PrintBookName();
            View.PrintBookList();
            Console.SetCursorPosition(20, 0);
            cursur = Console.ReadKey(true);
            if (cursur.Key == ConsoleKey.F5) { Console.Clear(); Menu.BookMenu(); }
            Console.SetCursorPosition(20, 0);
            checking = Console.ReadLine();
            passing = AuthorCheck.IsMatch(checking); // 유저아이디 정규화로 양식 맞는지 확인         
            if (passing == false) AuthorSearch();
            else
            {
                foreach (BookVO list in List.BookList)
                {
                    if (list.author == checking)
                    {
                        Console.WriteLine(list);
                        Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
                        existing = true;
                    }
                }
                Console.Write(existing);
                NotExist();
                SearchBookAfter();
            }
 
        }
        public void PublishSearch()
        {
            LoginAfter Menu = new LoginAfter();
            string checking;
            bool passing;
            string book;

            Console.Clear();
            View.PrintBookName();
            View.PrintBookList();
            Console.SetCursorPosition(20, 0);
            cursur = Console.ReadKey(true);
            if (cursur.Key == ConsoleKey.F5) { Console.Clear(); Menu.BookMenu(); }
            Console.SetCursorPosition(20, 0);
            checking = Console.ReadLine();
            passing = PublishCheck.IsMatch(checking); // 유저아이디 정규화로 양식 맞는지 확인         
            if (passing == false) PublishSearch();
            else
            {
                foreach (BookVO list in List.BookList)
                {
                    if (list.publisher == checking)
                    {
                        Console.WriteLine(list);
                        Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
                        existing = true;
                    }
                }
                NotExist();
                SearchBookAfter();
            }
           
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
        public void SearchBookAfter()
        {
            LoginAfter Menu = new LoginAfter();
            Console.WriteLine("메뉴로 돌아가시겠습니까?");
            Console.WriteLine("종료는 ESC를 눌러주세요");
            cursur = Console.ReadKey(true);
            if (cursur.Key == ConsoleKey.Enter) { Console.Clear(); Menu.BookMenu(); }
            else if (cursur.Key == ConsoleKey.Escape) return;
        }
    }
}
