using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Exception;

namespace LibruryDatabase.Models
{
    internal class BookData
    {
        private static BookData Book = null;
        public static BookData Get()
        {
            if (Book == null)
                Book = new BookData();

            return Book;
        }

        public void StoreBookInformation(string bookName, string author, string publish, string publishDay, string quantity, string price) // 데이터베이스에 책 추가
        {
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string insertQuery = "INSERT INTO book(name,author,publish,publishDay,price,quantity) VALUES('" + bookName + "','" + author + "','" + publish + "','" + publishDay + "','" + price + "','" + quantity + "');";

                MySqlCommand Command = new MySqlCommand(insertQuery, book);
                Command.ExecuteNonQuery();
            }
        }

        public void RemoveBookInformation(string bookNunmber) // 
        {
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string DeleteQuery = "DELETE FROM book WHERE number = '" + bookNunmber + " ';";
                MySqlCommand Command = new MySqlCommand(DeleteQuery, book);
                Command.ExecuteNonQuery();
            }
        }
    }
}
