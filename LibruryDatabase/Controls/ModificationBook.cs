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
    internal class ModificationBook : SearchingBook
    {
        Screen Menu = new Screen();
        public void ModifyBook()
        {
            string number;
            string receiveInput;
            string keyInput;
            Console.Clear();
            Menu.PrintBookData(); // 책 목록 프린트
            SearchBookName(); // 책 제목 검색
            keyInput = InputBookNumber(); // 책 키값 입력받기
            number = InputNumber(); // 수정메뉴 입력
            receiveInput = modificationMenu(number); // 가격 or 수량           
            BookData.Get().ModifyBookInformation(receiveInput, number, keyInput); // 데베에서 책 수정
        }

        string InputNumber() // 수정메뉴 입력
        {
            string modificatioNumber;

            while (Constants.PASS)
            {
                Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                Console.Write("책 수량 수정 1번, 책 가격 수정 2번 입력:");
                modificatioNumber = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Constants.InputMenu_Y);
                if (Constants.CHECK == Regex.IsMatch(modificatioNumber, Utility.Exception.MODIFICATION_BOOK))
                {
                    Console.SetCursorPosition(Console.CursorLeft, 9);/////////////////////////////////////////////////////////////////////예외메시지 수정해야함
                    Console.Write("다시 입력해주세요"); Console.SetCursorPosition(Console.CursorLeft, Constants.InputMenu_Y);continue;
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

            while (Constants.PASS)
            {
                Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                Console.Write("수정할 수량을 입력해주세요 :");
                quantity = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Constants.InputMenu_Y);
                if (Constants.CHECK == Regex.IsMatch(quantity, Utility.Exception.QUANTITY))
                {

                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return quantity;
        }

        string InputPrice() // 가격입력
        {
            string bookPrice;

            while (Constants.PASS)
            {

                Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                Console.Write("수정할 가격을 입력해주세요 :");
                bookPrice = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Constants.InputMenu_Y);
                if (Constants.CHECK == Regex.IsMatch(bookPrice, Utility.Exception.PRICE))
                {                   
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return bookPrice;
        }

        string InputBookNumber()//key값 입력받기
        {
            string bookNumber;

            while (Constants.PASS)
            {

                Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                Console.Write("책 번호를 입력해주세요 :");
                bookNumber = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Constants.InputMenu_Y);
                if (Constants.CHECK == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK))
                {
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return bookNumber;
        }
    }
}
