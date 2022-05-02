using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;
using LibruryDatabase.Models;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;

namespace LibruryDatabase
{

    internal class text2
    {
        public List<NaverBookVO> NaverBook = new List<NaverBookVO>();

        public string title;
        public string author;
        public string price;
        public string publisher;
        public string isbn;
        public string description;

        public void naver()
        {
            string keyword = "자료구조";
            string display = "20";


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




        //string url = "https://openapi.naver.com/v1/search/book.json?query=%EC%A3%BC%EC%8B%9D&" + startquery;



        //string url = "https://openapi.naver.com/v1/search/book.json?query=%EC%A3%BC%EC%8B%9D&" + query;

        //string query = "%EC%A3%BC%EC%8B%9D&display=10&start=1"; // 검색할 문자열
        //string url = "https://openapi.naver.com/v1/search/book?query=" + query; // 결과가 JSON 포맷

        /*
        JObject obj = JObject.Parse(text);
        Console.WriteLine(obj["items"][0]["title"].ToString());
        Console.WriteLine(obj["items"][0]["author"].ToString());
        Console.WriteLine(obj["items"][0]["price"].ToString());
        Console.WriteLine(obj["items"][0]["publisher"].ToString());
        Console.WriteLine(obj["items"][0]["isbn"].ToString());
        Console.WriteLine(obj["items"][0]["description"].ToString());
        //Console.WriteLine(text);
        */




        /* 리스트에 저장
        title = obj["items"][0]["title"].ToString();
        author = obj["items"][0]["author"].ToString();
        price = obj["items"][0]["price"].ToString();
        publisher = obj["items"][0]["publisher"].ToString();
        isbn = obj["items"][0]["isbn"].ToString();
        description = obj["items"][0]["description"].ToString();


        Book.Add(new NaverBookVO(title, author, price, publisher, isbn, description));

        foreach (NaverBookVO x in Book)
        {
            Console.WriteLine(x.title);
            Console.WriteLine(x.author);
            Console.WriteLine(x.price);
            Console.WriteLine(x.publisher);
            Console.WriteLine(x.isbn);
            Console.WriteLine(x.description);
        }
        */

        /*
        public List<LogVO> Log = new List<LogVO>();

        private string time;
        private string name;
        private string record;
        private string log;

        public void storelog()
        {
           
            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(Constants.logQuery, user);
                MySqlDataReader userInformation = Command.ExecuteReader();

                while (userInformation.Read())
                {

                    time = userInformation["TIME"].ToString();
                    name = userInformation["name"].ToString();
                    record = userInformation["record"].ToString();
                    log = userInformation["log"].ToString();

                    //Log.Add(new LogVO(time, name, record, log));
                }
                userInformation.Close();
            }
            

            foreach (LogVO x in Log)
            {
                Console.Write(x.dateTime+ "  ");
                Console.Write(x.name + "  ");
                Console.Write(x.record + "  ");
                Console.WriteLine(x.log);
            }
            
        }

        public void PrintUserData()
        {



            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, user);
                MySqlDataReader userInformation = Command.ExecuteReader();

                while (userInformation.Read())
                {
                    Console.Write("아이디 :");
                    Console.WriteLine(userInformation["id"].ToString());
                    Console.Write("비밀번호 :");
                    Console.WriteLine(userInformation["pw"].ToString());
                    Console.Write("이름 :");
                    Console.WriteLine(userInformation["name"].ToString());
                    Console.Write("전화번호 :");
                    Console.WriteLine(userInformation["phone"].ToString());
                    Console.Write("나이 :");
                    Console.WriteLine(userInformation["age"].ToString());
                    Console.Write("주소 :");
                    Console.WriteLine(userInformation["address"].ToString());
                    Console.WriteLine("=======================================================================");
                }
                userInformation.Close();
            }
        }
        */


    }
}
