using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;

namespace LibruryDatabase.Controls
{
    internal class CheckingReturnBook
    {
        Screen Menu = new Screen();
        public void ShowBorrowBook()
        {
            Console.Clear();
            Menu.PrintBorrowBookData();
        }
    }
}
