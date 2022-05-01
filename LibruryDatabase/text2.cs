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
        public List<NaverBookVO> Book = new List<NaverBookVO>();

        public string title;
        public string author;
        public string price;
        public string publisher;
        public string isbn;
        public string description;

        public void naver()
        {

            string parseJson;

            string keyword = "컴퓨터";
            string display = "100";
            string sort = "경제";

            

            string query = string.Format("?query={0}&display={1}sort={2}", keyword, display, sort); //쿼리 만들기

            string startquery = string.Format("&display={0}&start=1&sort={1}", display,sort); //쿼리 만들기

            string sortquery = string.Format("&sort={0}", "컴퓨터"); //쿼리 만들기



            string url = "https://openapi.naver.com/v1/search/book.json?query=%EC%A3%BC%EC%8B%9D" + startquery;

            //string url = "https://openapi.naver.com/v1/search/book.json?query=%EC%A3%BC%EC%8B%9D&" + startquery;



            //string url = "https://openapi.naver.com/v1/search/book.json?query=%EC%A3%BC%EC%8B%9D&" + query;

            //string query = "%EC%A3%BC%EC%8B%9D&display=10&start=1"; // 검색할 문자열
            //string url = "https://openapi.naver.com/v1/search/book?query=" + query; // 결과가 JSON 포맷

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + query);

            request.Headers.Add("X-Naver-Client-Id", "wIcEQfjn2NsKuQmIlo2S"); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", "ocXHc9Sh_7");       // 클라이언트 시크릿


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
                
                //var countsOfDisplay = Convert.ToInt32(ParseJson["display"]);



                for (int i = 0; i < int.Parse(display); i++)
                {
                    
                    string title = ParseJson["items"][i]["title"].ToString();
                    title = title.Replace("&quot;", "\""); //HTML 태그 변경

                    string description = ParseJson["items"][i]["description"].ToString();
                    description = description.Replace("&quot;", "\""); //HTML 태그 변경

                    string price = ParseJson["items"][i]["price"].ToString();

                    //뉴스 제목, 본문, 링크를 리스트 뷰에 추가
                    Console.Write("제목 : ");
                    Console.WriteLine(title);
                    Console.Write("설명 : ");
                    Console.WriteLine(description);
                    Console.Write("가격 : ");
                    Console.WriteLine(price);
                    Console.WriteLine("=====================================================");

                }


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

            }
            else
            {
                Console.WriteLine("Error 발생=" + status);
            }
        }


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
