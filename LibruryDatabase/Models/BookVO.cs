using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibruryDatabase.Models
{
    class BookVO
    {
        private static BookVO BookData = null;

        public static BookVO Get()
        {
            if (BookData == null)
                BookData = new BookVO();

            return BookData;
        }
    }
}
