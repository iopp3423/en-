using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary3.Controls
{
    using EnLibrary3.Controls;
    using EnLibrary3.Views;
    internal class BookSearch
    {
        ListVO List = new ListVO();
        Print View = new Print();
        public void SearchBook()
        {
            Console.Clear();
            foreach (BookVO list in List.BookList)
            {
                Console.WriteLine(list);
                Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            }
        }
    }
}
