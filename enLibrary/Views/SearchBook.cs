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
        Input Inputting = new Input();
        Print PrintCollection = new Print();
        static private int inputData;

        public void Searching()
        {
            Console.Clear();
            PrintCollection.PrintSearchMenu();
            Book.StoreBookLIst();
            Book.print();
            inputData = Inputting.UserDoInput(); //사용자 입력
        }
    }
}
