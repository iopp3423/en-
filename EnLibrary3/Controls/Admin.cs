using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnLibrary3.Views;
using EnLibrary3.Models;
using System.Text.RegularExpressions;

namespace EnLibrary3.Controls
{

    public class Admin : InputKey
    {
        Regex NameCheck = new Regex(@"^[가-힣]{2,5}$");
        Regex BookCheck = new Regex(@"^[가-힣a-zA-Z0-9]{1,15}$");
        Print View = new Print();
        BookSearch Search = new BookSearch();
        ListVO List = new ListVO();
        public static bool existing;

        ConsoleKeyInfo cursur;
        public void DoAdmin()
        {
            bool isFinished = true;
            {
                Console.Clear();
                View.PrintLoginInformation();

                ConsoleKeyInfo cursur;
                // Console 창에 보여질 커서의 x 좌표와 y 좌표
                int x = 48, y = 6;
                while (isFinished)
                {
                    // x 와 y 좌표에 커서를 표시하기위한 메서드
                    Console.SetCursorPosition(x, y);

                    cursur = Console.ReadKey(true);
                    // 저장된 키의 정보에 대해 검색
                    if (y == 6) { y++; adminLogin(); }
                    if (y == 7) { y++; adminPw(); isFinished = false; }
                    switch (cursur.Key)
                    {
                        // 상
                        case ConsoleKey.UpArrow:
                            {
                                y--;
                                if (y < 6) y++; // 선택 외의 화면으로 커서 못나감
                                break;
                            }
                        // 하
                        case ConsoleKey.DownArrow:
                            {
                                y++;
                                if (y > 7) y--; // 선택 외의 화면으로 커서 못나감
                                break;
                            }
                        case ConsoleKey.Enter:
                            {

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
        }


        public void AdminMenu()
        {
            View.PrintAdminMenu();//////////////메뉴이동 넣자
            bool isFinished = true;
            

                // Console 창에 보여질 커서의 x 좌표와 y 좌표
                int x = 32, y = 10;
                while (isFinished)
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
                                if (y < 10) y++; // 선택 외의 화면으로 커서 못나감
                                break;
                            }
                        // 하
                        case ConsoleKey.DownArrow:
                            {
                                y++;
                                if (y > 13) y--; // 선택 외의 화면으로 커서 못나감
                                break;
                            }
                        case ConsoleKey.Enter:
                            {
                                switch (y)
                                {
                                        case 10: { SearchBook(); isFinished = false; break; }
                                        case 11: {AddBook(); isFinished = false; break; }
                                        case 12: { RemoveBook(); isFinished = false; break; }
                                        case 13: { AdminUser(); isFinished = false; break; }
                                }
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


        public void SearchBook()
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
                if (cursur.Key == ConsoleKey.F5) { Console.Clear(); AdminMenu(); }

                checking = Console.ReadLine();
                passing = BookCheck.IsMatch(checking);

                if (passing == false) SearchBook();
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

    public void AddBook()
        {
            string input;
           
            Console.Clear();
            View.PrintAddBook();
            
            
            Console.Write("아직 구현하지 못해서 Enter누르면 메뉴로 돌아갑니다..");
            cursur = Console.ReadKey(true);
            if (cursur.Key == ConsoleKey.Enter) { Console.Clear(); AdminMenu(); }
            else if (cursur.Key == ConsoleKey.Escape) return;
        }
        public void RemoveBook()
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
            if (cursur.Key == ConsoleKey.F5) { Console.Clear(); AdminMenu(); }

            checking = Console.ReadLine();
            passing = BookCheck.IsMatch(checking);

            if (passing == false) SearchBook();
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
            }
            Console.Write("아직 구현하지 못해서 Enter누르면 메뉴로 돌아갑니다..");
            cursur = Console.ReadKey(true);
            if (cursur.Key == ConsoleKey.Enter) { Console.Clear(); AdminMenu(); }
            else if (cursur.Key == ConsoleKey.Escape) return;
        }

        public void AdminUser()
        {
            Console.Clear();
            foreach (UserVO list in List.UserList)
            {
                Console.WriteLine(list);
                Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
                existing = true;

            }
            Console.Write("아직 구현하지 못해서 Enter누르면 메뉴로 돌아갑니다..");
            cursur = Console.ReadKey(true);
            if (cursur.Key == ConsoleKey.Enter) { Console.Clear(); AdminMenu(); }
            else if (cursur.Key == ConsoleKey.Escape) return;
           


        }



        public void SearchBookAfter()
        {
            LoginAfter Menu = new LoginAfter();
            Console.WriteLine("메뉴로 돌아가시겠습니까?");
            Console.WriteLine("종료는 ESC를 눌러주세요");
            cursur = Console.ReadKey(true);
            if (cursur.Key == ConsoleKey.Enter) { Console.Clear(); AdminMenu();  }
            else if (cursur.Key == ConsoleKey.Escape) return;
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
                if (cursur.Key == ConsoleKey.Enter) { Console.Clear(); AdminMenu(); }
                else if (cursur.Key == ConsoleKey.Escape) return;
                View.PrintBookList();
                Console.ReadLine();
                existing = true;
            }
        }
    }
}

