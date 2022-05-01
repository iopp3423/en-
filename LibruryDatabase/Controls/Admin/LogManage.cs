using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Utility;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{
    internal class LogManage
    {
        public Screen Print;

        public LogManage()
        {
        }

        public LogManage(Screen Menu)
        {
            this.Print = Menu;
        }


        public void Log()
        {
            Console.Clear();
            Print.PrintMain();
            Print.PrintAdminMenu();
        }


    }
}
