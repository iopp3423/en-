using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Exception;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{
    internal class RemovingBook : SearchingBook
    {
        Screen Menu = new Screen();
        public void RemoveBook()
        {
            string bookNumber;
            Console.Clear();
            Menu.PrintBookData(); // 책 목록 프린트
            SearchBookName(); // 책 제목 검색
           
            bookNumber = InputBookNumber();
            //BookData.Get().RemoveBookInformation(bookNumber);
            Console.Write("책이 삭제되었습니다.");
        }

        string InputBookNumber()
        {
            string bookNumber;
            Console.Write("  삭제할 책 번호 :");

            while (Constants.PASS)
            {
                //Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);               
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                bookNumber = Console.ReadLine();

                if (Constants.CHECK == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.Write("다시 입력해주세요 :"); continue;
                }
                break;
            }
            return bookNumber;

            
        }

    }
}
