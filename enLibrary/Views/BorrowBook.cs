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
        int input;
        Print PrintCollection = new Print();
        Input Inputting = new Input();
        BookVO Book = new BookVO();
        SearchBook Search = new SearchBook(); 
        public void Borrowing()
        {
            Search.Searching();
            
        }
       
    }
}
