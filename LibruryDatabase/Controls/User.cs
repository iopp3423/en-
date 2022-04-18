using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;

namespace LibruryDatabase.Controls
{
    internal class User
    {
        Showing Menu = new Showing(); // 뷰 클래스 객체생성
        public void JoinMember()
        {
            Console.Clear();
            Menu.JoinPrint();
            Menu.PrintJoinMember();
        }
        
    }
}
