using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary3.Controls
{
    using EnLibrary3.Views;
    using EnLibrary3.Controls;
    internal class LoginAfter
    {
        Print View = new Print();
        public void BookMenu()
        {
            View.BookMenu(); // 로그인 후 화면 출력
        }
    }
}
