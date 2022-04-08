using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    using EnLibrary.Controls;
    class SearchBook
    {
        BookVO Book = new BookVO();
        Print PrintCollection = new Print();
        public void Searching()
        {
            Console.Clear();
            PrintCollection.PrintSearchMenu();
            Book.StoreBookLIst();
            //Book.BookPrint();
        }
    }
}
