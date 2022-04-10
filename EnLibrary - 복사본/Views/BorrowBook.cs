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
        static public string input;
        int i;
        BookInformation Book = new BookInformation();
        Print PrintCollection = new Print();
        Input Inputting = new Input();
        SearchBook Search = new SearchBook();
        
        public void Borrowing()
        {
            Search.Searching();
            Console.Write("원하시는 도서 번호를 입력해주세요 : ");
            //Inputting.InputString();
            //Book.SearchingQuantity();
            //Book.Print();
            //Console.Write("이게맞나 : ");

        }
    }
}
