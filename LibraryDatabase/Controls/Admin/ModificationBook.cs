﻿using System;
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
        public Screen Print;
        public MessageScreen Message;

        public ModificationBook()
        {
        }

        public ModificationBook(Screen Menu, MessageScreen message) : base(Menu, message)
        {
            this.Message = message;
            this.Print = Menu;
        }


        public void GoBackMenu() //이전 메뉴로 돌아가기
        {
            while (Constants.isEntrancing)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            Print.PrintMain();
                            Print.PrintAdminMenu();
                            return;
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
            string bookName;

            Console.Clear();
            Print.PrintSearchBookName();
            Print.PrintBookData(); // 책 목록 프린트



            Message.GreenColor(Message.PrintReviseBookInput());
            if (Print.IsGoingBackMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴

            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.BOOK_Y);
            SearchBookName(Constants.isFail, Constants.ADMIN); // 책 제목 검색


            keyInput = InputBookNumber(); // 책 번호 입력받기
            number = InputNumber(); // 수정메뉴 입력
            receiveInput = modificationMenu(number); // 가격 or 수량           


            BookData.Get().ModifyBookInformation(receiveInput, number, keyInput); // 데베에서 책 수정
            RemoveAndStore(); // 리스트 다시 저장


            bookName = BookData.Get().BringBookname(keyInput);// 해당 책 정보가져오기
            if (number == Constants.REVISE_BOOK_QUANTITY) LogData.Get().StoreLog(Constants.ADMIN, Constants.REVISE_QUANTITY, bookName); // 로그에 저장
            else LogData.Get().StoreLog(Constants.ADMIN, Constants.REVISE_PRICE, bookName); // 로그에 저장

            Message.GreenColor(Message.PrintReviseAfterMessage());
            GoBackMenu();
        }

        public string InputNumber() // 수정메뉴 입력
        {
            string modificatioNumber;

            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Message.PrintChooseReviseInput();

            while (Constants.isPassing)
            {
                modificatioNumber = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(modificatioNumber, Utility.Exception.MODIFICATION_BOOK))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop-Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Message.PrintReEnterMessage(); continue;
                }
                break;
            }
            return modificatioNumber;
        }


        public string modificationMenu(string number)//메뉴
        {
            string Input = number; // 초기화
            if (int.Parse(number) == Constants.GO_QUANTITY) Input = InputQuantity(); // 수량입력받기
            else if (int.Parse(number) == Constants.GO_PRICE) Input = InputPrice(); // 가격입력받기
            return Input;
        }

        public string InputQuantity() // 수량입력
        {
            string quantity;

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Message.PrintInputQuantity();
            while (Constants.isPassing)
            {
                quantity = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);

                if (Constants.isFail == Regex.IsMatch(quantity, Utility.Exception.QUANTITY))
                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Message.PrintReEnterMessage(); continue;
                }
                break;
            }
            return quantity;
        }

        public string InputPrice() // 가격입력
        {
            string bookPrice;

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
           ClearCurrentLine(Constants.CURRENT_LOCATION);
            Message.PrintInputPrice();

            while (Constants.isPassing)
            {            
                bookPrice = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                if (Constants.isFail == Regex.IsMatch(bookPrice, Utility.Exception.PRICE))

                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Message.PrintReEnterMessage(); continue;
                }
                break;
            }
            return bookPrice;
        }

        public string InputBookNumber()//책 번호 입력받기
        {
            string bookNumber;

            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Message.PrintInputBookNumber();

            while (Constants.isPassing)
            {
                bookNumber = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                if (Constants.isFail == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK))
                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Message.PrintReEnterMessage(); continue;
                }
                break;
            }
            return bookNumber;
        }


        public void RemoveAndStore()
        {
            BookData.Get().bookData.Clear(); // 리스트 초기화
            BookData.Get().StoreBookData(); // 리스트에 북 데이터 저장
        }
    }
}