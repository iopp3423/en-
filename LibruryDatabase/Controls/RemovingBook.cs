using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Exception;

namespace LibruryDatabase.Controls
{
    internal class RemovingBook : SearchingBook
    {

        public void RemoveBook()
        {
            SearchBook(Constants.GO_ADMIN_SEARCH);
            Console.ReadLine();
            Console.WriteLine("HelloWord");
        }

    }
}
