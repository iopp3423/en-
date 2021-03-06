using System;
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
    internal class BookEdition
    {
        private Screen Menu;
        private MessageScreen Message;
        private LogDAO logDao;
        private LogDTO logDto;
        private BookDAO bookDao;
        private BookDTO bookDto;

        public BookEdition()
        {
        }

        public BookEdition(Screen Menu, MessageScreen message, LogDAO LogDao, LogDTO LogDto, BookDAO BookDao, BookDTO BookDto)
        {
            this.Menu = Menu;
            this.Message = message;
            this.logDao = LogDao;
            this.logDto = LogDto;
            this.bookDto = BookDto;
            this.bookDao = BookDao;
        }


        public void SelectMenu() //이전 메뉴로 돌아가기
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
                    default: continue;
                }

            }
        }

        public void AddBook()
        {            
            int movingInputY = Constants.BOOK_NAME_Y;

            logDao.connection(); // db연결
            bookDao.connection(); // db연결

            Console.Clear();
            Menu.PrintMain();                
            Menu.PrintAddBook();

            Message.GreenColor(Message.PrintInputOrBackMessage());
            if (IsGoingBackMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴

            bookDto.Title = InputBookName(movingInputY++);
            bookDto.Author = InputAuthor(movingInputY++);
            bookDto.Publisher = InputPublisher(movingInputY++);
            bookDto.Publishday = InputPublishDay(movingInputY++);
            bookDto.Quantity = InputQuantity(movingInputY++);
            bookDto.Price = InputPrice(movingInputY++);
            bookDto.Isbn = InputISBN(movingInputY);

            
            bookDao.StoreReviseBook(bookDto.Title, bookDto.Author, bookDto.Publisher, bookDto.Publishday, bookDto.Price, bookDto.Isbn, bookDto.Quantity); // book db에 정보 저장
            logDto.Log = bookDto.Title;
            logDao.StoreLog(Constants.ADMIN, Constants.ADD, logDto.Log); // db에 로그 내역 저장

            Console.SetCursorPosition(Console.CursorLeft, Constants.ERROR_Y);
            Message.GreenColor(Message.PrintDoneBookRegister());

            SelectMenu(); 
        }

        public string InputBookName(int bookNameY)//책이름입력
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

                    Message.PrintBookTitle();
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return bookName;         
        }

        public string InputAuthor(int authorY)//작가입력
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

                    Message.PrintAuthorInputMessage();
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return author;
        }


        public string InputPublisher(int publisherY)//출판사입력
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

                    Message.PrintPublisherInputMessage();
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return publisher;
        }


        public string InputPublishDay(int publishDayY)//출판일자입력
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

                    Message.PrintPublishDayInput();
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return publishDay;
        }


        public string InputQuantity(int quantityY)//수량입력
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

                    Message.PrintQuantityInputMessage();
                    Menu.PrintLoginErrorMessage(); continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return quantity;
        }


        public string InputPrice(int bookPriceY)//가격입력
        {
            string price;

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

        public string InputISBN(int ISBNY)//isbn입력
        {

            string isbn;

            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.BOOK_PRICE_X, ISBNY);
                isbn = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(isbn, Utility.Exception.ISBN))
                {
                    Console.SetCursorPosition(Constants.PUBLISH_DAY_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Message.PrintIsbnMessage();
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

        public bool IsGoingBackMenu()
        {
            while (Constants.isPassing) // 메뉴 입장한 후 뒤로가기
            {
                Constants.cursor = Console.ReadKey(true);
                if (Constants.cursor.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Menu.PrintMain();
                    Menu.PrintAdminMenu();
                    Console.SetCursorPosition(Constants.FIRSTX, Constants.BOOK_NAME_Y);
                    return Constants.isBackMenu;
                }
                else if (Constants.cursor.Key == ConsoleKey.Enter) { ClearCurrentLine(Constants.CURRENT_LOCATION); break; }
            }
            return Constants.isPassing;
        }
    }
}
