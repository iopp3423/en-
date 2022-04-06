using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.View
{
    class Print
    {
        public void PrintTitle()
        {
            Console.WriteLine("---------------------------------------------Libraury------------------------------------");
            string s = "Hello|World";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
        }

        public void PrintMenu()
        {
            Console.WriteLine("------------회원모드-------------");
            Console.WriteLine("-----------관리자모드-----------");
        }

        public void PrintLoginOrJoin()
        {
            Console.WriteLine("------------1. 회원가입----------");
            Console.WriteLine("------------2. 로그인  ----------");
        }

    }
}
