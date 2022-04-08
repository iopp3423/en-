using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    using EnLibrary.Controls;
    internal class BorrowBook
    {
        Print PrintCollection = new Print();
        BookVO Book = new BookVO();
        public void Borrowing()
        {
            Console.Clear();
            PrintCollection.PrintSearchMenu();
        }
    }
}
