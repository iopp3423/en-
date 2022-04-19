using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Models;
using System.Text.RegularExpressions;
using LibruryDatabase.Exception;


namespace LibruryDatabase.Controls
{
    internal class SearchingBook
    {
        Regex NAME = new Regex(Execption.CHECK);
        Regex PUBLISH = new Regex(Execption.PUBLISH_CHECK);
        Regex TITLE = new Regex(Execption.TITLE_CHECK);

        Showing Menu = new Showing();

        public void SearchBook()
        {
            Console.Clear();
            Menu.PrintSearchMenu();
            BookVO.Get().PrintBook();

          

            if (Constants.BACK == cursur()) // 마우스 함수
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintUserMenu();
                return;
            }
        }

        public bool cursur()
        {
            int Y = Constants.SEARCH_Y;

            while (Constants.ENTRANCE) // 참이면
            {
                Console.SetCursorPosition(Constants.SEARCH_X, Y);
                Constants.cursur = Console.ReadKey(true);

                switch (Constants.cursur.Key)
                {
                    // 상
                    case ConsoleKey.UpArrow:
                        {
                            Y--;
                            if (Y < Constants.NAME_SEARCH_Y) Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Y++;
                            if (Y > Constants.BOOK_Y) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == Constants.NAME_SEARCH_Y) { SearchName(); } // 도서찾기
                            if (Y == Constants.PUBLISH_Y) { SearchPublishName(); } // 도서대여
                            if (Y == Constants.BOOK_Y) { SearchBookName(); } // 도서확인                          
                            break;
                        }
                    case ConsoleKey.F5:
                        {
                            return Constants.BACK_MENU;
                        }

                    case ConsoleKey.Escape: // 종료
                        {
                            break;
                        }

                    default: break;

                }
            }
        }

        public void SearchName() // 작가명으로 찾기
        {
            string name;
            Constants.ClearCurrentLine();
            Console.Write("입력 (영어,한글 2~8자) :");

            while (Constants.ENTRANCE)
            {              
                name = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.NAME_LINE);
                if (Constants.CHECK == NAME.IsMatch(name)) // 정규식에 맞지 않으면
                {                  
                    Constants.ClearCurrentLine();                  
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;

            }
        }
        public void SearchPublishName() // 출판사로 찾기
        {
            string publish;
            Constants.ClearCurrentLine();
            Console.Write("입력 (한글 2~8자) :");

            while (Constants.ENTRANCE)
            {
                publish = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.PUBLISH_LINE);
                if (Constants.CHECK == PUBLISH.IsMatch(publish)) // 정규식에 맞지 않으면
                {
                    Constants.ClearCurrentLine();
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;

            }
        }
        public void SearchBookName() // 제목으로 찾기
        {
            string bookName;
            Constants.ClearCurrentLine();
            Console.Write("입력 (한글, 영어 2~10자) :");

            while (Constants.ENTRANCE)
            {
                bookName = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.BOOKNAME_LINE);
                if (Constants.CHECK == NAME.IsMatch(bookName)) // 정규식에 맞지 않으면
                {
                    Constants.ClearCurrentLine();
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;

            }
        }
    }
}
