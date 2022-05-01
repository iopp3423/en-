using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LibruryDatabase.Models;


namespace LibruryDatabase
{
    /*
    public class test
    {
        public List<NaverBookVO> Book = new List<NaverBookVO>();



        public void naver()
        {

            string parseJson;

            string query = "%EC%A3%BC%EC%8B%9D&display=10&start=1"; // 검색할 문자열

            string url = "https://openapi.naver.com/v1/search/book?query=" + query; // 결과가 JSON 포맷

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Headers.Add("X-Naver-Client-Id", "wIcEQfjn2NsKuQmIlo2S"); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", "ocXHc9Sh_7");       // 클라이언트 시크릿


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();

            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string text = reader.ReadToEnd();

                JObject obj = JObject.Parse(text);
                //string notice = obj["title"].ToString();
                //Console.WriteLine(notice);

                Console.WriteLine(obj["items"][0]["title"].ToString());
                Console.WriteLine(obj["items"][0]["author"].ToString());
                Console.WriteLine(obj["items"][0]["price"].ToString());
                Console.WriteLine(obj["items"][0]["publisher"].ToString());
                Console.WriteLine(obj["items"][0]["isbn"].ToString());
                Console.WriteLine(obj["items"][0]["description"].ToString());


                Console.WriteLine(text);



            }
            else
            {
                Console.WriteLine("Error 발생=" + status);
            }
        }
    }
    */
}
