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
            Console.Clear();
            Menu.PrintBookData(); // 책 목록 프린트
            SearchBookName(); // 책 제목 검색
            number = InputNumber(); // 수정메뉴 입력
            receiveInput = modificationMenu(number);
        }

        string InputNumber() // 수정메뉴 입력
        {
            string modificatioNumber;

            while (Constants.PASS)
            {
                Constants.ClearCurrentLine();
                Console.Write("책 가격 수정 1번, 책 수량 수정 2번 입력:");
                modificatioNumber = Console.ReadLine();
                if (Constants.CHECK == Regex.IsMatch(modificatioNumber, Utility.Exception.MODIFICATION_BOOK))
                {           
                    Console.Write("다시 입력해주세요"); continue;
                }
                break;
            }
            return modificatioNumber;
        }

        /*
        string modificationMenu(string number)
        {
            switch(int.Parse(number))
            {
                case 1: return InputQuantity();
                case 2: return InputPrice();
                default:break;
            }
        }
        */
        string InputQuantity()
        {
            string quantity;

            while (Constants.PASS)
            {

                quantity = Console.ReadLine();
                if (Constants.CHECK == Regex.IsMatch(quantity, Utility.Exception.QUANTITY))
                {

                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return quantity;
        }
        string InputPrice()
        {
            string bookPrice;

            while (Constants.PASS)
            {

                bookPrice = Console.ReadLine();
                if (Constants.CHECK == Regex.IsMatch(bookPrice, Utility.Exception.PRICE))
                {
                    //Console.SetCursorPosition(Constants.BOOK_PRICE_X, bookPriceY);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return bookPrice;
        }

    }
}
