using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using SejongTimeTable.Views;
using SejongTimeTable.Controls;
using SejongTimeTable.Models;
using System.Text.RegularExpressions;

namespace SejongTimeTable//Example Example 왜 있지
{
    class Start
    {
       
        static void Main(string[] args)
        {
            
            Console.SetWindowSize(Constants.CONSOLE_SIZE_WIDTH, Constants.CONSOLE_SIZE_HEIGHT);// 콘솔크기 지정
              Logging Login = new Logging();
              Login.LoginId();
              //id : 17013150 pw : 99999999
/*
            List<int> start = new List<int>();
            List<int> end = new List<int>();
            List<string> Day = new List<string>();

     
                string A = "금 18:00~19:00";
                string B = "수 16:30~18:30, 금 09:00~11:00";
                string C = "월 수 16:00~18:00";

                string pattern = @"[^월|화|수|목|금]";
                string replaced = Regex.Replace(A, pattern, "금");

                Console.Write(replaced);
            */


            /*
             var text = “C# 공부한 내용을 쪼끔씩 정리하자.”;
                var pattern = @”쪼금씩|쪼끔씩|쬐끔씩”;
                var replaced = Regex.Replace(text, pattern, “조금씩”);
                Console.WriteLine(replaced);
             */
        }
    }
}
