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
        ListVO List = new ListVO();
        Print View = new Print();
        bool isFinished = true;
        Regex BookCheck = new Regex(@"^[0-9a-zA-Z]{4,10}$");
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
                            if (y == 0) { NameSearch(); isFinished = false; }
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
            string checking;
            bool passing;

            Console.Clear();
            View.PrintBookName();
            View.PrintBookList();
            Console.SetCursorPosition(20, 0);
            checking = Console.ReadLine();
            passing = BookCheck.IsMatch(checking); // 유저아이디 정규화로 양식 맞는지 확인
            Console.Clear();
            Console.WriteLine(checking);

            foreach (BookVO list in List.BookList)
            {
                if (List.BookList.Any(x => x.name.Contains(checking)))
                {
                    Console.WriteLine(list);
                    Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                    break;
                }
            
            } 

            /*
            if (List.BookList.Any(x => x.name.Contains(checking)))
            {
            }
            else continue;
            */



        }
    }
}
