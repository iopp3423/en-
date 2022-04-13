using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SejongTimeTable.Controls
{
    internal class Logging
    {
        Regex IdCheck = new Regex(@"^[0-9]{8}$");
        Regex PwCheck = new Regex(@"^[0-9]{4,10}$");

        public void LoginId()
        {
            string id;           


            while (true)
            {
                Console.SetCursorPosition(Constants.ID_X_AXIS, Constants.ID_Y_AXIS);
                id = Console.ReadLine();
                if (Constants.Is_CHECK != IdCheck.IsMatch(id))
                {
                    Console.SetCursorPosition(Constants.ID_X_AXIS, Constants.ID_Y_AXIS);
                    Console.Write("다시 입력해주세요"); continue;
                }
                LoginPw(id);
                break;
            }
        }
         public void LoginPw(string id)
        {
            string pw;
            while (true)
            { 
                Console.SetCursorPosition(Constants.PW_X_AXIS, Constants.PW_Y_AXIS);
                pw = Console.ReadLine();

                if (Constants.Is_CHECK != PwCheck.IsMatch(pw))
                {
                    Console.SetCursorPosition(Constants.PW_X_AXIS, Constants.PW_Y_AXIS);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                if (id == "17013150" && pw == "99999999") Console.Write("Hello");
                break;
            }
        }
    }

    
}
