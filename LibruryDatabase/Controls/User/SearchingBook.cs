using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Models;
using System.Text.RegularExpressions;
using LibruryDatabase.Utility;
using MySql.Data.MySqlClient;




namespace LibruryDatabase.Controls
{
    internal class SearchingBook
    {
        string nameResult;
        string name;

        public Screen Menu;
        public MessageScreen message;

        public SearchingBook()
        {
        }

        public SearchingBook(Screen Menu, MessageScreen message)
        {
            this.Menu = Menu;
            this.message = message;
        }

        

        public bool IsGoingReturnMenu() //이전 메뉴로 돌아가기
        {
            while (Constants.isEntrancing)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            return Constants.isBackMenu;
                        }
                    case ConsoleKey.F5: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
                        }
                    default: continue;
                }

            }
        }

        public void SearchBook(bool goingUserOrAdmin, string id)
        {
            Console.Clear();
            Menu.PrintSearchMenu();
            Menu.PrintBookData();

            if (Constants.isBackMenu == IsSelectingMenu(id, Constants.isPassing) && Constants.isUserSearching == goingUserOrAdmin) // 유저모드용 책찾기
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintUserMenu();
                return;
            }
            else if (Constants.isBackMenu == IsSelectingMenu(id, Constants.isFail) && Constants.isAdminSearching == goingUserOrAdmin) // 관리자모드용 책찾기
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintAdminMenu();
                return;
            }
        }

        public bool IsSelectingMenu(string id, bool UserOrAdminSearch)
        {
            int Y = Constants.SEARCH_Y;

            while (Constants.isEntrancing) // 참이면
            {
                Console.SetCursorPosition(Constants.SEARCH_X, Y); 
                Constants.cursor = Console.ReadKey(true);

                switch (Constants.cursor.Key)
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
                            if (Y == Constants.NAME_SEARCH_Y) { SearchName(UserOrAdminSearch, id);  } // 작가로찾기
                            if (Y == Constants.PUBLISH_Y) { SearchPublishName(UserOrAdminSearch, id);} // 출판사로찾기
                            if (Y == Constants.BOOK_Y) { SearchBookName(UserOrAdminSearch, id);} // 책이름으로찾기
                            
                            return IsGoingReturnMenu();
                        }
                     case ConsoleKey.Escape:
                        {                           
                            return Constants.isBackMenu;
                        }

                    case ConsoleKey.F5: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
                        }

                    default: break;

                }
            }
        }

        public void BookExistenceCheck()
        {
            if (Constants.SEARCH_RESULT_BOOK == Constants.isFail) // 책 정보 없으면
            {
                message.RedColor(message.PrintNoBookMessage());
            }
            else message.PrintBack();
        }


        public void SearchName(bool goingUserOrAdmin, string id) // 작가로 찾기
        {
            //string name;
            Constants.SEARCH_RESULT_BOOK = Constants.isFail;
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            message.PrintAuthorInput();

            while (Constants.isEntrancing) // 책 예외처리
            {
                name = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.NAME_LINE);
                
                if (Constants.isFail == Regex.IsMatch(name, Utility.Exception.AUTHOR_CHECK)) // 정규식에 맞지 않으면
                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    message.PrintReEnterMessage(); continue;
                }
                break;
            }



            Console.Clear();
            Menu.PrintSearchAuthor(name); // 출력
            BookExistenceCheck();

            if (goingUserOrAdmin == Constants.isPassing)
            {
                nameResult = BookData.Get().BringSearchResult(name);// 해당 책 이름가져오기
                name = UserData.Get().Bringname(id);// 해당 id 이름 가져오기
                LogData.Get().StoreLog(name, Constants.SEARCH_AUTHOR, nameResult); // 로그에 저장
            }
            else
            {
                nameResult = BookData.Get().BringSearchResult(name);// 해당 책 이름가져오기
                LogData.Get().StoreLog(name, Constants.ADMIN + Constants.SEARCH_AUTHOR, nameResult); // 로그에 저장
            }

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            
        }
       

        public void SearchPublishName(bool goingUserOrAdmin, string id) // 출판사로 찾기
        {
            string publish;
            Constants.SEARCH_RESULT_BOOK = Constants.isFail;
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            message.PrintpublishInput();

            while (Constants.isEntrancing)
            {
                publish = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.PUBLISH_LINE);
                if (Constants.isFail == Regex.IsMatch(publish, Utility.Exception.PUBLISH_CHECK))// 정규식에 맞지 않으면
                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    message.PrintReEnterMessage(); continue;
                }
                break;
            }

            Console.Clear();

            Menu.PrintSearchPublish(publish);//출력          
            BookExistenceCheck();

            if (goingUserOrAdmin == Constants.isPassing)
            {
                nameResult = BookData.Get().BringSearchResult(publish);// 해당 책 이름가져오기
                name = UserData.Get().Bringname(id);// 해당 id 이름 가져오기
                LogData.Get().StoreLog(name, Constants.SEARCH_PUBLISHER, nameResult); // 로그에 저장
            }
            else
            {
                nameResult = BookData.Get().BringSearchResult(publish);// 해당 책 이름가져오기
                LogData.Get().StoreLog(name, Constants.ADMIN + Constants.SEARCH_PUBLISHER, nameResult); // 로그에 저장
            }

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
        }


        public void SearchBookName(bool goingUserOrAdmin, string id) // 책제목으로 찾기
        {
            string bookName;
            Constants.SEARCH_RESULT_BOOK = Constants.isFail;
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            message.PrintBookTitle();

            while (Constants.isEntrancing)
            {
                bookName = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.BOOKNAME_LINE);

                if (Constants.isFail == Regex.IsMatch(bookName, Utility.Exception.TITLE_CHECK))// 정규식에 맞지 않으면
                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    message.PrintReEnterMessage(); continue;
                }
                break;
            }
            Console.Clear();

            Menu.PrintSearchBookName(bookName);// 출력            
            BookExistenceCheck();

            if (goingUserOrAdmin == Constants.isPassing)
            {
                nameResult = BookData.Get().BringSearchResult(bookName);// 해당 책 이름가져오기
                name = UserData.Get().Bringname(id);// 해당 id 이름 가져오기
                LogData.Get().StoreLog(name, Constants.SEARCH_TITLE, nameResult); // 로그에 저장
            }
            else
            {
                nameResult = BookData.Get().BringSearchResult(bookName);// 해당 책 이름가져오기
                LogData.Get().StoreLog(name, Constants.ADMIN + Constants.SEARCH_TITLE, nameResult); // 로그에 저장
            }
            


            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);           
        }

        public void ClearCurrentLine(int number) // 줄 지우기
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Console.CursorTop - number);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, currentLineCursor);
        }

    }
}
