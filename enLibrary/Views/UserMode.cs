﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    class UserMode
    {
        Print PrintCollection = new Print();

        public void Print()
        {
             PrintCollection.LibraryPrint();
        }
       
    }
}
