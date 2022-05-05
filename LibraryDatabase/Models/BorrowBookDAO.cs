using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;


namespace LibruryDatabase.Models
{
    public class BorrowBookDAO
    {
        private MySqlConnection conn;

        public MySqlConnection connection()
        {
            conn = Connection.getConnection();
            return conn;
        }

        public List<BorrowBookDTO> StoreBorrowBookmemberReturn() // 도서대여한 회원정보 리턴
        {
            List<BorrowBookDTO> member = new List<BorrowBookDTO>();

            conn.Open();
            //ExecuteReader를 이용하여
            //연결 모드로 데이타 가져오기
            MySqlCommand Command = new MySqlCommand(Constants.BorrrowBookUserquery, conn);
            MySqlDataReader Data = Command.ExecuteReader();

            while (Data.Read())
            {
                member.Add(new BorrowBookDTO(Data["id"].ToString(), Data["number"].ToString(), Data["bookname"].ToString(), Data["author"].ToString(), Data["publish"].ToString(), Data["borrowbook"].ToString(), Data["returnbook"].ToString()));
            }
            conn.Close();
            return member;           
        }

        public void RemoveBorrowmember(string id) // 대여목록에 있는 아이디 db에서 제거
        {

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.RemoveBorrowmember, id), conn);
            Command.ExecuteNonQuery();
            conn.Close();
        }

        public bool IsCheckingBorrowedBook(string id) // 대여한 책이 있으면 False, 없으면 true
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(Constants.BorrrowBookUserquery, conn);
            MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

            while (userData.Read())
            {
                if (userData["id"].ToString() == id)
                {
                    conn.Close();
                    return Constants.isFail; // 아이디가 있으면 반납 안함
                }
            }
            conn.Close();
            return Constants.isSucess; // 반납함
        }

        public bool IsCheckingAlreadyBorrowBook(string id, string bookNumber) // db에서 검사 후 true면 대여한 책 있는 유저
        {

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowUserQuery, id), conn);
            MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

            while (userData.Read())
            {
                if (userData["number"].ToString() == bookNumber)
                {
                    conn.Close();
                    return Constants.isSucess;
                }
            }
            conn.Close();
            return Constants.isFail;
        }

        public void RemoveRetuenBookInformation(string id, string bookNumber) // 해당 아이디에서 반납한 책 제거 
        {

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.revomeReturnBook, id, bookNumber), conn);
            Command.ExecuteNonQuery();
            conn.Close();

        }

        public bool IsCheckingBookOverlap(string id, string bookNumber) // 데베에서 책 대여했는지 체크 true면 대여목록에 책 있음
        {

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowIdQuery, id), conn);
            MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

            while (userData.Read())
            {
                if (userData["number"].ToString() == bookNumber)
                {
                    conn.Close();
                    return Constants.isSucess;// 대여함
                }
            }
            conn.Close();
            return Constants.isFail;
        }

        public void BorrowBook(string id, string number) // 로그인한 유저 아이디값, 책 번호 전달받음
        {

            string bookName = " ";
            string author = " ";
            string publish = " ";

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.SearchDataQuery, number), conn);
            MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

            while (bookData.Read())
            {
                bookName = (bookData["name"].ToString());
                author = (bookData["author"].ToString());
                publish = (bookData["publish"].ToString());
            }
            conn.Close();


            AddBorrowBook(id, number, bookName, author, publish); // 책 대여 함수에 데이터 전송
        }



        public void AddBorrowBook(string id, string number, string bookName, string author, string publish) // 로그인한 유저 책 대여
        {
            string borrowDay = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            string returnDay = DateTime.Today.AddDays(Constants.RETURNDAY).ToString("yyyy/MM/dd");

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowQuery, id, number, bookName, author, publish, borrowDay, returnDay), conn);
            Command.ExecuteNonQuery();
            conn.Close();
        }



        public void close()
        {
            conn.Close();
        }

    }
}
