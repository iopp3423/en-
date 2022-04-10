using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary3.Controls
{
    using EnLibrary3.Views;
    using EnLibrary3.Controls;
    internal class LoginAfter
    {
        Print View = new Print();
        ListVO List = new ListVO();
        BookBorrow Borrow = new BookBorrow();
        BookCheck Check = new BookCheck();
        BookSearch Search = new BookSearch();
        UserRevise Revise = new UserRevise();

        ConsoleKeyInfo cursur;
        public void BookMenu()
        {       
            View.PrintBookMenu(); // 로그인 후 화면 출력
           
            // Console 창에 보여질 커서의 x 좌표와 y 좌표
            int x = 32, y = 10;

            // 커서의 이동을 표현하는 것이 목적이므로 무한 루프를통해 커서표현을 반복
            for (; ; )
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
                            if (y == 10) Search.SearchBook();
                            if (y == 11) Borrow.BorrowBook();
                            if (y == 12) Check.CheckBook();
                            if (y == 13) Revise.ReviseUser();
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
}

/*
foreach (UserVO list in List.UserList)
{
    Console.WriteLine(list);
    Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
}
*/