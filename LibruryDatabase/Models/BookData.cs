using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;

namespace LibruryDatabase.Models
{
    internal class BookData
    {

        public List<NaverBookVO> NaverBook = new List<NaverBookVO>();


        private static BookData Book;
        public static BookData Get()
        {
            if (Book == null)
                Book = new BookData();

            return Book;
        }
        



        public void StoreBookInformation(string bookName, string author, string publish, string publishDay, string quantity, string price) // 책 추가
        {
           
            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.addingBookQuery,bookName, author, publish, publishDay, price, quantity), book);
                Command.ExecuteNonQuery();
            }
        }

        public void RemoveBookInformation(string bookNumber) // 책 제거
        {

            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.DeleteQuery, bookNumber), book);
                Command.ExecuteNonQuery();
            }
        }


        public void ModifyBookInformation(string bookInformation, string menu, string bookNumber) // 책 수정
        {
     
            if (menu == Constants.REVISE_BOOK_QUANTITY)
            {
                using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
                {
                    book.Open();
                    MySqlCommand Command = new MySqlCommand(String.Format(Constants.ModifyQuantityQuery,bookInformation, bookNumber), book);
                    Command.ExecuteNonQuery();
                }
            }
            else
            {
                using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
                {
                    book.Open();
                    MySqlCommand Command = new MySqlCommand(String.Format(Constants.ModifyPriceQuery, bookInformation, bookNumber), book);
                    Command.ExecuteNonQuery();
                }
            }
        }

 
        public bool IsCheckingBookOverlap(string id, string bookNumber) // 데베에서 책 대여했는지 체크
        {

            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();

                MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowIdQuery,id), user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["number"].ToString() == bookNumber && userData["borrowbook"].ToString() != " " && userData["returnbook"].ToString() != " ") return Constants.isSucess;// 대여하고 반납함
                    else if (userData["number"].ToString() == bookNumber && userData["borrowbook"].ToString() != " " && userData["returnbook"].ToString() == " ") return Constants.isFail; // 대여하고 반납안함
                }
                user.Close();
            }
            return Constants.isSucess;

        }

        public bool IsCheckReturnBook(string id, string bookNumber) // 데베에서 책 대여했는지 체크
        {

            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();

                MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowIdQuery, id), user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["number"].ToString() == bookNumber && userData["borrowbook"].ToString() != " " && userData["returnbook"].ToString() != " ") return Constants.isSucess;// 대여하고 반납함
                }
                user.Close();
            }
            return Constants.isFail;

        }

        public void RemoveRetuenBookInformation(string id, string bookNumber) // 반납한 책 제거
        {

            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.revomeReturnBook,id,bookNumber), book);
                Command.ExecuteNonQuery();
            }
        }





        public void SearchBook(string id, string number) // 로그인한 유저 아이디값, 책 번호 전달받음
        {

            string bookName = " ";
            string author = " ";
            string publish = " ";


            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.SearchDataQuery, number), book);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    bookName = (bookData["name"].ToString());
                    author = (bookData["author"].ToString());
                    publish = (bookData["publish"].ToString());
                }
                bookData.Close();
            }

            AddBorrowBook(id, number, bookName, author, publish); // 책 대여 함수에 데이터 전송
        }



        public void AddBorrowBook(string id, string number, string bookName, string author, string publish) // 로그인한 유저 책 대여
        {
            string borrowDay = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;

            
            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowQuery,id,number,bookName,author,publish,borrowDay,' '), book);
                Command.ExecuteNonQuery();
            }           
        }
 

        public void MinusBook(string bookNumber) // 책 대여시 해당 책 갯수 1 감소
        {


            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.minusBook, bookNumber), book);
                Command.ExecuteNonQuery();
            }
        }

        public void PlusBook(string bookNumber) // 책 대여시 해당 책 갯수 1 감소
        {


            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.plusBook, bookNumber), book);
                Command.ExecuteNonQuery();
            }
        }


        public bool IsCheckongBookQuantity(string bookNumber) // 책 수량 체크
        {


            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowedIdQuery, bookNumber), book);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기
                while (bookData.Read())
                {
                    if (bookData["quantity"].ToString() == Constants.NONE_BOOK) return Constants.isFail;
                }
                bookData.Close();
                return Constants.isPassing;
            }
        }

        public bool IsCheckingAlreadyBorrowBook(string id, string bookNumber) // 대여한 책인지 체크
        {

            
            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowUserQuery,id), user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["number"].ToString() == bookNumber) return Constants.isSucess;

                }
                user.Close();
            }
            return Constants.isFail;
        }


        public bool IsCheckingUserBorrowedBook(string id, string bookNumber) // 데베에서 책 이미반납했는지 체크
        {

            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowUserQuery, id), user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["number"].ToString() == bookNumber && userData["returnbook"].ToString() != " ") return Constants.isSucess; // 해당 번호 책 반납했는지 체크                                     
                }
                user.Close();
            }
            return Constants.isFail;

        }

        public void ReturnBook(string bookNumber) // 로그인한 유저 책 반납
        {
            string returnDay = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;


            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {

                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.returnBookQuery,returnDay,bookNumber), book);
                Command.ExecuteNonQuery();
                
            }

        }

        public bool IsCheckingBookExistence(string bookNumber) // 데베에 책 있는지 체크
        {
            

            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();             
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowedIdQuery,bookNumber), user);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    if (bookData["number"].ToString() == bookNumber) return Constants.isSucess;
                }
                user.Close();
            }
            return Constants.isFail;
        }

        public bool IsCheckingUserBorrowedBook(string id) // 유저가 대여한 책이 있는지 체크
        {
            bool isCheckingBook = Constants.isPassing;
           
            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowUserQuery, id), user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["returnbook"].ToString() == " ") isCheckingBook = Constants.isFail; // 책을 대여했는데 한 권이라도 반납하지 않는 책이 있는경우
                }
                user.Close();
                return isCheckingBook;
            }
        }

        public string BringBookname(string bookNumber) // 데베에 책 있는지 체크
        {


            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowedIdQuery, bookNumber), user);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    if (bookData["number"].ToString() == bookNumber) return bookData["name"].ToString();
                }
                user.Close();
            }
            return bookNumber;
        }

        public string BringSearchResult(string name) // 데베에 책 있는지 체크
        {


            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.SearchBookQuery), user);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    if (bookData["author"].ToString().Contains(name)) { return bookData["author"].ToString(); }
                    else if (bookData["publish"].ToString().Contains(name)) { return bookData["publish"].ToString(); }
                    else if (bookData["name"].ToString().Contains(name)) { return bookData["name"].ToString(); }
                }
                user.Close();
            }
            return name;
        }



        public void StoreNaverBookToList(string keyword, string display)
        {
            //string keyword = "자료구조";
            //string display = "20";

            string query = string.Format("{0}&display={1}", keyword, display); //쿼리 만들기
            string url = "https://openapi.naver.com/v1/search/book.json?query=";


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + query);

            request.Headers.Add("X-Naver-Client-Id", Constants.NAVER_ID); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", Constants.NAVER_PASSWORD);// 클라이언트 시크릿


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();

            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string text = reader.ReadToEnd();

                text = text.Replace("<b>", "");
                text = text.Replace("</b>", "");
                text = text.Replace("&lt;", "<");
                text = text.Replace("&gt;", ">");

                JObject ParseJson = JObject.Parse(text);

                for (int index = Constants.CURRENT_LOCATION; index < int.Parse(display); index++)
                {
                    string title = ParseJson["items"][index]["title"].ToString();
                    title = title.Replace("&quot;", "\""); //HTML 태그 변경              
                    string price = ParseJson["items"][index]["price"].ToString();
                    string author = ParseJson["items"][index]["author"].ToString();
                    string publisher = ParseJson["items"][index]["publisher"].ToString();
                    string isbn = ParseJson["items"][index]["isbn"].ToString();
                    string description = ParseJson["items"][index]["description"].ToString();
                    description = description.Replace("&quot;", "\""); //HTML 태그 변경

                    NaverBook.Add(new NaverBookVO(title, author, price, publisher, isbn, description));
                }
            }
            else
            {
                Console.WriteLine("Error 발생=" + status);
            }
        }
    }
}
