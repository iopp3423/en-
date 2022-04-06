using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    class Print
    {
        public void LibraryPrint()
        {
            Console.WriteLine(string.Format("{0,42}", "★          ★★★   ★★★★     ★★★★   ★★★★   ★★★★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★    ★     ★    ★   ★    ★   ★    ★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★  ★★     ★    ★   ★    ★   ★    ★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★★★       ★★★★   ★★★★   ★★★★      ★ "));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★  ★★     ★   ★    ★    ★   ★   ★       ★ "));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★    ★     ★    ★   ★    ★   ★     ★     ★ "));
            Console.WriteLine(string.Format("{0,42}", "★★★★★  ★★★   ★★★★     ★    ★   ★    ★   ★     ★     ★ "));
            Console.Write("\n");
        }
        public void MenuPrint()
        {
            Console.WriteLine(string.Format("{0,42}", "회원모드를 시작하려면 0번을 눌러주세요."));
            Console.WriteLine(string.Format("{0,42}", "관리자모드를 시작하려면 1번을 눌러주세요."));
            Console.WriteLine(string.Format("{0,42}", "도서관 프로그램을 종료하려면 2번을 눌러주세요."));
        }

        public void JoinOrLogin()
        {
            Console.WriteLine(string.Format("{0,42}", "회원가입은 0번을 눌러주세요"));
            Console.WriteLine(string.Format("{0,42}", "로그인은 1번을 눌러주세요."));
            Console.WriteLine(string.Format("{0,42}", "도서관 프로그램을 종료하려면 2번을 눌러주세요."));
        }
    }
}
