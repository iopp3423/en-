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
using System.Text.RegularExpressions;

namespace LibruryDatabase.Models
{
    internal class BookDAO
    {
        private MySqlConnection conn;

        public MySqlConnection connection()
        {
            conn = Connection.getConnection();
            return conn;
        }

        public List<BookDTO> StoreBookReturn() // 도서목록 리턴
        {
            List<BookDTO> book = new List<BookDTO>();

            conn.Open();
            //ExecuteReader를 이용하여
            //연결 모드로 데이타 가져오기
            MySqlCommand Command = new MySqlCommand(Constants.SearchBookQuery, conn);
            MySqlDataReader Data = Command.ExecuteReader();

            while (Data.Read())
            {
                book.Add(new BookDTO(Data["number"].ToString(), Data["name"].ToString(), Data["author"].ToString(), Data["publish"].ToString(), Data["publishday"].ToString(), Data["price"].ToString(), Data["isbn"].ToString(), Data["quantity"].ToString()));
            }
            conn.Close();
            return book;
        }

        public List<BookDTO> StoreNaverBookReturn() // 네이버도서목록 리턴
        {
            List<BookDTO> naverBook = new List<BookDTO>();

            conn.Open();
            //ExecuteReader를 이용하여
            //연결 모드로 데이타 가져오기
            MySqlCommand Command = new MySqlCommand(Constants.naverQuery, conn);
            MySqlDataReader Data = Command.ExecuteReader();
            while (Data.Read())
            {
                naverBook.Add(new BookDTO(Data["number"].ToString(),Data["title"].ToString(), Data["author"].ToString(), Data["publisher"].ToString(), Data["publishday"].ToString(), Data["price"].ToString(), Data["isbn"].ToString(), Data["description"].ToString()));
            }
            conn.Close();
            return naverBook;         
        }

        public List<BookDTO> StoreRequestBookReturn() // 유저요청 도서목록 리턴
        {
            List<BookDTO> requestBook = new List<BookDTO>();

            conn.Open();
            //ExecuteReader를 이용하여
            //연결 모드로 데이타 가져오기
            MySqlCommand Command = new MySqlCommand(Constants.userRequestQuery, conn);
            MySqlDataReader Data = Command.ExecuteReader();
            while (Data.Read())
            {
                requestBook.Add(new BookDTO(Data["number"].ToString(), Data["name"].ToString(), Data["author"].ToString(), Data["publish"].ToString(), Data["publishday"].ToString(), Data["price"].ToString(), Data["isbn"].ToString(), Data["quantity"].ToString()));
            }
            conn.Close();
            return requestBook;
        }

        public void StoreNaverBook(string keyword, string display)
        {
            conn.Open();
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
                    string publishday = ParseJson["items"][index]["pubdate"].ToString();
                    string description = ParseJson["items"][index]["description"].ToString();
                    description = description.Replace("&quot;", "\""); //HTML 태그 변경

                    MySqlCommand Command = new MySqlCommand(String.Format(Constants.NaverBookQuery, RemoveSpecialCharacterFromString(title), author, price, publisher, publishday, isbn, RemoveSpecialCharacterFromString(description)), conn);               
                    Command.ExecuteNonQuery();                   
                }
            }
            else
            {
                Console.WriteLine("Error 발생=" + status);
            }
            conn.Close();
        }

        public string RemoveSpecialCharacterFromString(string description) // 책 설명 특수문자 제거
        {
           return  Regex.Replace(description, @"[^a-zA-Z0-9가-힣]", "", RegexOptions.Singleline);
        }

        public bool CheckNaverBookNumber(string bookNumber) // true면 검색 후 입력한 네이버 도서번호가 있음
        {
            conn.Open();
            //ExecuteReader를 이용하여
            //연결 모드로 데이타 가져오기
            MySqlCommand Command = new MySqlCommand(Constants.naverQuery, conn);
            MySqlDataReader Data = Command.ExecuteReader();
            while (Data.Read())
            {
                if(Data["number"].ToString() == bookNumber)
                {
                    conn.Close();
                    return Constants.isPassing;
                }
            }
            conn.Close();
            return Constants.isFail;
        }

        public void RemoveAllNaverBook() // naver db 초기화
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.RemoveAllNaverBook), conn);
            Command.ExecuteNonQuery();
            conn.Close();
        }

        public void InsertRequestBook(string bookNumber) // request db에 책 추가
        {
            List<BookDTO> requestBook = new List<BookDTO>();

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.naverQuery, bookNumber), conn);
            MySqlDataReader Data = Command.ExecuteReader();
            while (Data.Read())
            {//리스트에 임시저장
                if (Data["number"].ToString() == bookNumber)
                {
                    requestBook.Add(new BookDTO(Data["number"].ToString(), Data["title"].ToString(), Data["author"].ToString(), Data["publisher"].ToString(), Data["publishday"].ToString(), Data["price"].ToString(), Data["isbn"].ToString(), Data["description"].ToString()));
                }
            }
            conn.Close();

            // requestbook db에 저장
            conn.Open();
            MySqlCommand Request = new MySqlCommand(String.Format(Constants.requestBookQuery, requestBook[0].Title, requestBook[0].Author, requestBook[0].Publisher, requestBook[0].Publishday, requestBook[0].Price, requestBook[0].Isbn, requestBook[0].Quantity), conn);
            Request.ExecuteNonQuery();
            conn.Close();
        }
        public void PlusBook(string bookNumber) // 책 반납시 해당 책 갯수 1 증가
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.plusBook, bookNumber), conn);
            Command.ExecuteNonQuery();
            conn.Close();
        }

        public string BringBookname(string bookNumber) // 이름가져오기
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowedIdQuery, bookNumber), conn);
            MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

            while (bookData.Read())
            {
                if (bookData["number"].ToString() == bookNumber)
                {                  
                    return bookData["name"].ToString();
                }
            }
            conn.Close();
            return bookData["name"].ToString();
        }

        public string BringSearchResult(string name) // 데베에 책 있는지 체크
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.SearchBookQuery), conn);
            MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

            while (bookData.Read())
            {
                if (bookData["author"].ToString().Contains(name)) { return bookData["author"].ToString(); }
                else if (bookData["publish"].ToString().Contains(name)) { return bookData["publish"].ToString(); }
                else if (bookData["name"].ToString().Contains(name)) { return bookData["name"].ToString(); }
            }
            conn.Close();
            return name;
        }

        public bool IsCheckongBookQuantity(string bookNumber) // 책 수량 체크
        {

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowedIdQuery, bookNumber), conn);
            MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

            while (bookData.Read())
            {
                if (bookData["quantity"].ToString() == Constants.NONE_BOOK)
                {
                    conn.Close();
                    return Constants.isFail;
                }
            }
            conn.Close();
            return Constants.isPassing;

        }

        public void MinusBook(string bookNumber) // 책 대여시 해당 책 갯수 1 감소
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.minusBook, bookNumber), conn);
            Command.ExecuteNonQuery();
            conn.Close();
        }

        public bool IsCheckingBookExistence(string bookNumber) // 데베에 책 있는지 체크
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowedIdQuery, bookNumber), conn);
            MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

            while (bookData.Read())
            {
                if (bookData["number"].ToString() == bookNumber)
                {
                    conn.Close();
                    return Constants.isSucess;
                }
            }
            conn.Close();
            return Constants.isFail;
        }


        public void RemoveBookInformation(string bookNumber) // 책 제거
        {

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.DeleteQuery, bookNumber), conn);
            Command.ExecuteNonQuery();
            conn.Close();

        }

        public bool CheckBookNumber(string bookNumber) // 책번호 존재여부
        {
            conn.Open();
            //ExecuteReader를 이용하여
            //연결 모드로 데이타 가져오기
            MySqlCommand Command = new MySqlCommand(Constants.SearchBookQuery, conn);
            MySqlDataReader Data = Command.ExecuteReader();

            while (Data.Read())
            {
                if(Data["number"].ToString() == bookNumber)
                {
                    conn.Close();
                    return Constants.isPassing;
                }
            }
            conn.Close();
            return Constants.isFail;
        }

        public void StoreReviseBook(string bookName, string author, string publish, string publishDay, string price, string isbn, string quantity) // 책 저장
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.addUserBookQuery, bookName, author, publish, publishDay, price, isbn, quantity), conn);
            Command.ExecuteNonQuery();
            conn.Close();
        }

        public void ModifyBookInformation(string bookInformation, string menu, string bookNumber) // 책 수정
        {

            if (menu == Constants.REVISE_BOOK_QUANTITY)
            {
                conn.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.ModifyQuantityQuery, bookInformation, bookNumber), conn);
                Command.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                conn.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.ModifyPriceQuery, bookInformation, bookNumber), conn);
                Command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public bool isCheckingRequestBookNumber(string bookNumber) // 유저요청 책 책 번호 존재여부
        {
            conn.Open();
            //ExecuteReader를 이용하여
            //연결 모드로 데이타 가져오기
            MySqlCommand Command = new MySqlCommand(Constants.userRequestQuery, conn);
            MySqlDataReader Data = Command.ExecuteReader();

            while (Data.Read())
            {
                if (Data["number"].ToString() == bookNumber)
                {
                    conn.Close();
                    return Constants.isPassing;
                }
            }
            conn.Close();
            return Constants.isFail;
        }

        public void StoreRequestBook(string bookNumber, string quantity) // 유저가 입력한 책 데이터 book db저장
        {
            List<BookDTO> requestBook = new List<BookDTO>();

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.userRequestQuery, bookNumber), conn);
            MySqlDataReader Data = Command.ExecuteReader();
            while (Data.Read())
            {//리스트에 임시저장
                if (Data["number"].ToString() == bookNumber)
                {
                    requestBook.Add(new BookDTO(Data["number"].ToString(), Data["name"].ToString(), Data["author"].ToString(), Data["publish"].ToString(), Data["publishday"].ToString(), Data["price"].ToString(), Data["isbn"].ToString(), quantity));
                }
            }
            conn.Close();

            // book db에 저장
            conn.Open();
            MySqlCommand Request = new MySqlCommand(String.Format(Constants.addUserBookQuery, requestBook[0].Title, requestBook[0].Author, requestBook[0].Publisher, requestBook[0].Publishday, requestBook[0].Price, requestBook[0].Isbn, quantity), conn);
            Request.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteRequestStoreBook(string bookNumber)
        {
            // 유저 요청 도서 추가 후 제거
            conn.Open();
            MySqlCommand remove = new MySqlCommand(String.Format(Constants.DeleteRequestQuery, bookNumber), conn);
            remove.ExecuteNonQuery();
            conn.Close();
        }

        public bool isCheckingNaverBookNumber(string bookNumber) // 유저요청 책 책 번호 존재여부
        {
            conn.Open();
            //ExecuteReader를 이용하여
            //연결 모드로 데이타 가져오기
            MySqlCommand Command = new MySqlCommand(Constants.naverQuery, conn);
            MySqlDataReader Data = Command.ExecuteReader();

            while (Data.Read())
            {
                if (Data["number"].ToString() == bookNumber)
                {
                    conn.Close();
                    return Constants.isPassing;
                }
            }
            conn.Close();
            return Constants.isFail;
        }

        public void StoreNaverBookTobook(string bookNumber, string quantity) // 네이버 검색한 책 데이터 book db저장
        {
            List<BookDTO> naverBook = new List<BookDTO>();

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.naverQuery, bookNumber), conn);
            MySqlDataReader Data = Command.ExecuteReader();
            while (Data.Read())
            {//리스트에 임시저장
                if (Data["number"].ToString() == bookNumber)
                {
                    naverBook.Add(new BookDTO(Data["number"].ToString(), Data["title"].ToString(), Data["author"].ToString(), Data["publisher"].ToString(), Data["publishday"].ToString(), Data["price"].ToString(), Data["isbn"].ToString(), quantity));
                }
            }
            conn.Close();

            // book db에 저장
            conn.Open();
            MySqlCommand Request = new MySqlCommand(String.Format(Constants.addUserBookQuery, naverBook[0].Title, naverBook[0].Author, naverBook[0].Publisher, naverBook[0].Publishday, naverBook[0].Price, naverBook[0].Isbn, quantity), conn);
            Request.ExecuteNonQuery();
            conn.Close();
        }

        public void close()
        {
            conn.Close();
        }
    }
}
