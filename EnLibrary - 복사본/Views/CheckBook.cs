using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    using EnLibrary.Controls;
    internal class CheckBook
    {
        BookInformation Book = new BookInformation();
        Print PrintCollection = new Print();
        public void Checking()
        {

            Console.Clear();
            PrintCollection.PrintCheckBook();
            Console.Clear();
            Book.StoreBookLIst();
            Book.Print();
        }
    }
}
