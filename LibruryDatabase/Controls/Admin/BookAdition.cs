﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Views;
using LibruryDatabase.Utility;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{ 
    internal class BookAdition
    {
        public Screen Menu;
        public MessageScreen Message;

        public BookAdition()
        {
        }

        public BookAdition(Screen Menu, MessageScreen message)
        {
            this.Menu = Menu;
            this.Message = message;
        }

        string bookName;
        string author;
        string publisher;
        string publishDay;
        string quantity;
        string bookprice;
        string price;
        string isbn;


        public void IsSelectingMenu() //이전 메뉴로 돌아가기
        {
            while (Constants.isEntrancing)
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

        public void AddBook()
        {
            
            int movingInputY = Constants.BOOK_NAME_Y;

            Console.Clear();
            Menu.PrintMain();                
            Menu.PrintAddBook();

            Message.GreenColor(Message.PrintInputOrBackMessage());
            if (Menu.IsGoingBackMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴

            bookName = InputBookName(movingInputY++);
            author = InputAuthor(movingInputY++);
            publisher = InputPublisher(movingInputY++);
            publishDay = InputPublishDay(movingInputY++);
            quantity = InputQuantity(movingInputY++);
            bookprice = InputPrice(movingInputY++);
            isbn = InputISBN(movingInputY);

            BookData.Get().StoreBookInformation(bookName, author, publisher, publishDay, quantity, bookprice); // 책 데베 추가
            LogData.Get().StoreLog("관리자", "도서추가", bookName); // 로그에 저장

            Console.SetCursorPosition(Console.CursorLeft, Constants.ERROR_Y);
            Message.GreenColor(Message.PrintDoneBookRegister());

            IsSelectingMenu(); 
        }

        string InputBookName(int bookNameY)//책이름입력
        {
    

            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.BOOK_NAME_X, bookNameY);
                bookName = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(bookName, Utility.Exception.TITLE_CHECK))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Message.PrintBookTitle();
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return bookName;         
        }
        
        string InputAuthor(int authorY)//작가입력
        {
         

            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.AUTHOR_X, authorY);
                author = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(author, Utility.Exception.AUTHOR_CHECK))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Message.PrintAuthorInputMessage();
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return author;
        }


        string InputPublisher(int publisherY)//출판사입력
        {
         

            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.PUBLISHER_X, publisherY);
                publisher = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(publisher, Utility.Exception.PUBLISH_CHECK))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Message.PrintPublisherInputMessage();
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return publisher;
        }


        string InputPublishDay(int publishDayY)//출판일자입력
        {
  

            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.PUBLISH_DAY_X, publishDayY);
                publishDay = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(publishDay, Utility.Exception.PUBLISH_DAY))
                {
                    Console.SetCursorPosition(Constants.PUBLISH_DAY_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Message.PrintPublishDayInput();
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return publishDay;
        }


        string InputQuantity(int quantityY)//수량입력
        {
  

            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.QUANTITY_X, quantityY);
                quantity = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(quantity, Utility.Exception.QUANTITY))
                {
                    Console.SetCursorPosition(Constants.PUBLISH_DAY_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Message.PrintQuantityInputMessage();
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return quantity;
        }


        string InputPrice(int bookPriceY)//가격입력
        {
     

            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.BOOK_PRICE_X, bookPriceY);
                price = Console.ReadLine();
                if (Constants.isFail == Regex.IsMatch(price, Utility.Exception.PRICE))
                {
                    Console.SetCursorPosition(Constants.PUBLISH_DAY_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Message.PrintPriceInputMessage();
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            return price;
        }

        string InputISBN(int ISBNY)//isbn입력
        {
            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.BOOK_PRICE_X, ISBNY);
                isbn = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(isbn, Utility.Exception.ISBN))
                {
                    Console.SetCursorPosition(Constants.PUBLISH_DAY_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Message.PrintAddisbn();
                    Menu.PrintLoginErrorMessage(); 
                    continue;
                }
                break;
            }
            return isbn;
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
