using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using SejongTimeTable.Views;
using SejongTimeTable.Controls;
using SejongTimeTable.Models;

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
        }
    }
}
