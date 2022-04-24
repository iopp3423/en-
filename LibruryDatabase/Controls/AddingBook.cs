using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Views;
using LibruryDatabase.Exception;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{ 
    internal class AddingBook
    {
        Screen Menu = new Screen();
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


            bookName = InputBookName(movingInputY++);
            author = InputAuthor(movingInputY++);
            publisher = InputPublisher(movingInputY++);
            publishDay = InputPublishDay(movingInputY++);
            quantity = InputQuantity(movingInputY++);
            price = InputPrice(movingInputY);

            BookData.Get().StoreBookInformation(bookName, author, publisher, publishDay, quantity, price);
            Console.Write("도서가 등록되었습니다.");
        }




        string InputBookName(int bookNameY)
        {
            string bookName;

            while (Constants.PASS)
            {
                Console.SetCursorPosition(Constants.BOOK_NAME_X, bookNameY);
                bookName = Console.ReadLine();
                if (Constants.CHECK == Regex.IsMatch(bookName, Utility.Exception.TITLE_CHECK))
                {
                    Console.SetCursorPosition(Constants.BOOK_NAME_X, bookNameY);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return bookName;
        }
        
        string InputAuthor(int authorY)
        {
            string author;

            while (Constants.PASS)
            {
                Console.SetCursorPosition(Constants.AUTHOR_X, authorY);
                author = Console.ReadLine();
                if (Constants.CHECK == Regex.IsMatch(author, Utility.Exception.AUTHOR_CHECK))
                {
                    Console.SetCursorPosition(Constants.AUTHOR_X, authorY);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return author;
        }

        string InputPublisher(int publisherY)
        {
            string publisher;

            while (Constants.PASS)
            {
                Console.SetCursorPosition(Constants.PUBLISHER_X, publisherY);
                publisher = Console.ReadLine();
                if (Constants.CHECK == Regex.IsMatch(publisher, Utility.Exception.PUBLISH_CHECK))
                {
                    Console.SetCursorPosition(Constants.PUBLISHER_X, publisherY);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return publisher;
        }
        string InputPublishDay(int publishDayY)
        {
            string publishDay;

            while (Constants.PASS)
            {
                Console.SetCursorPosition(Constants.PUBLISH_DAY_X, publishDayY);
                publishDay = Console.ReadLine();
                if (Constants.CHECK == Regex.IsMatch(publishDay, Utility.Exception.PUBLISH_DAY))
                {                   
                    Console.SetCursorPosition(Constants.PUBLISH_DAY_X, publishDayY);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return publishDay;
        }
        string InputQuantity(int quantityY)
        {
            string quantity;

            while (Constants.PASS)
            {
                Console.SetCursorPosition(Constants.QUANTITY_X, quantityY);
                quantity = Console.ReadLine();
                if (Constants.CHECK == Regex.IsMatch(quantity, Utility.Exception.QUANTITY))
                {
                    Console.SetCursorPosition(Constants.QUANTITY_X, quantityY);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return quantity;
        }
        string InputPrice(int bookPriceY)
        {
            string bookPrice;

            while (Constants.PASS)
            {
                Console.SetCursorPosition(Constants.BOOK_PRICE_X, bookPriceY);
                bookPrice = Console.ReadLine();
                if (Constants.CHECK == Regex.IsMatch(bookPrice, Utility.Exception.PRICE))
                {
                    Console.SetCursorPosition(Constants.BOOK_PRICE_X, bookPriceY);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return bookPrice;
        }
        
    }
}
