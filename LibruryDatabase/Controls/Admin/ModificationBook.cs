using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Utility;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{
    internal class ModificationBook : SearchingBook
    {
        Screen Menu = new Screen();
        public void GoBackMenu() //이전 메뉴로 돌아가기
        {
            while (Constants.ENTRANCE)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            Menu.PrintMain();
                            Menu.PrintAdminMenu();
                            return;
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
        public void ModifyBook()
        {
            string number;
            string receiveInput;
            string keyInput;
            Console.Clear();
            Menu.PrintSearchBookName();
            Menu.PrintBookData(); // 책 목록 프린트

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("책 수정 : Enter                                          뒤로가기 : ESC");
            Console.ResetColor();
            if (Menu.EntranceAfterReturnMenu() == Constants.BACK_MENU) return;// 입장 후 뒤로가기 메뉴

            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.BOOK_Y);
            SearchBookName(); // 책 제목 검색

            keyInput = InputBookNumber(); // 책 번호 입력받기
            number = InputNumber(); // 수정메뉴 입력
            receiveInput = modificationMenu(number); // 가격 or 수량           
            BookData.Get().ModifyBookInformation(receiveInput, number, keyInput); // 데베에서 책 수정
            Console.Write("수정이 완료되었습니다.  뒤로가기 : ESC                 프로그램 종료 : F5");
            GoBackMenu();
        }

        string InputNumber() // 수정메뉴 입력
        {
            string modificatioNumber;

            Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("책 수량 수정 1번, 책 가격 수정 2번 입력:");

            while (Constants.PASS)
            {
                modificatioNumber = Console.ReadLine();

                if (Constants.CHECK == Regex.IsMatch(modificatioNumber, Utility.Exception.MODIFICATION_BOOK))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop-Constants.BEFORE_INPUT_LOCATION);
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요 : "); continue;
                }
                break;
            }
            return modificatioNumber;
        }

        
        string modificationMenu(string number)//메뉴
        {
            string Input = number; // 초기화
            if (int.Parse(number) == Constants.GO_QUANTITY) Input = InputQuantity(); // 수량입력받기
            else if (int.Parse(number) == Constants.GO_PRICE) Input = InputPrice(); // 가격입력받기
            return Input;
        }
        
        string InputQuantity() // 수량입력
        {
            string quantity;

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
            Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("수정할 수량을 입력해주세요(숫자만) :");
            while (Constants.PASS)
            {
                quantity = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);

                if (Constants.CHECK == Regex.IsMatch(quantity, Utility.Exception.QUANTITY))
                {
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return quantity;
        }

        string InputPrice() // 가격입력
        {
            string bookPrice;

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
            Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("수정할 가격을 입력해주세요(숫자만) :");

            while (Constants.PASS)
            {            
                bookPrice = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                if (Constants.CHECK == Regex.IsMatch(bookPrice, Utility.Exception.PRICE))

                {
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return bookPrice;
        }

        string InputBookNumber()//책 번호 입력받기
        {
            string bookNumber;

            Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("책 번호를 입력해주세요 :");

            while (Constants.PASS)
            {
                bookNumber = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                if (Constants.CHECK == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK))
                {
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return bookNumber;
        }
    }
}
