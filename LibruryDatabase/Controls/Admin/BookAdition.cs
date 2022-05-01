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
        Screen Menu = new Screen();

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
            string bookName;
            string author;
            string publisher;
            string publishDay;
            string quantity;
            string price;
            int movingInputY = Constants.BOOK_NAME_Y;

            Console.Clear();
            Menu.PrintMain();                
            Menu.PrintAddBook();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("책 정보 입력 : Enter                                      뒤로가기 : ESC");
            Console.ResetColor();
            if (Menu.IsGoingBackMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴

            bookName = InputBookName(movingInputY++);
            author = InputAuthor(movingInputY++);
            publisher = InputPublisher(movingInputY++);
            publishDay = InputPublishDay(movingInputY++);
            quantity = InputQuantity(movingInputY++);
            price = InputPrice(movingInputY);

            BookData.Get().StoreBookInformation(bookName, author, publisher, publishDay, quantity, price); // 책 데베 추가

            Console.SetCursorPosition(Console.CursorLeft, Constants.ERROR_Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("도서가 등록되었습니다. 뒤로가기 : ESC   종료 : F5");
            Console.ResetColor();

            IsSelectingMenu(); 
        }

        string InputBookName(int bookNameY)
        {
            string bookName;

            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.BOOK_NAME_X, bookNameY);
                bookName = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(bookName, Utility.Exception.TITLE_CHECK))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.WriteLine("책 제목(영어, 한글 2~10자) :");
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return bookName;

           
        }
        
        string InputAuthor(int authorY)
        {
            string author;

            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.AUTHOR_X, authorY);
                author = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(author, Utility.Exception.AUTHOR_CHECK))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.WriteLine("작가(영어, 한글 2~8자) :");
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return author;
        }


        string InputPublisher(int publisherY)
        {
            string publisher;

            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.PUBLISHER_X, publisherY);
                publisher = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(publisher, Utility.Exception.PUBLISH_CHECK))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.WriteLine("출판사(영어 한글 2~8자):");
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return publisher;
        }


        string InputPublishDay(int publishDayY)
        {
            string publishDay;

            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.PUBLISH_DAY_X, publishDayY);
                publishDay = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(publishDay, Utility.Exception.PUBLISH_DAY))
                {
                    Console.SetCursorPosition(Constants.PUBLISH_DAY_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.WriteLine("출시일(YYYY/MM/DD) :");
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return publishDay;
        }


        string InputQuantity(int quantityY)
        {
            string quantity;

            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.QUANTITY_X, quantityY);
                quantity = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(quantity, Utility.Exception.QUANTITY))
                {
                    Console.SetCursorPosition(Constants.PUBLISH_DAY_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.WriteLine("수량(1~3자리 숫자):");
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return quantity;
        }


        string InputPrice(int bookPriceY)
        {
            string bookPrice;

            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.BOOK_PRICE_X, bookPriceY);
                bookPrice = Console.ReadLine();
                if (Constants.isFail == Regex.IsMatch(bookPrice, Utility.Exception.PRICE))
                {
                    Console.SetCursorPosition(Constants.PUBLISH_DAY_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.WriteLine("가격 :");
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            return bookPrice;
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