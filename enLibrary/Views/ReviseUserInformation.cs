using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    using EnLibrary.Controls;
    internal class ReviseUserInformation
    {
        Print PrintCollection = new Print();
        UserVO Information = new UserVO();
        
        public void Revising()
        {
            Information.Print();
            Console.WriteLine("────────────────────────────────────────────────────────────");
            Console.Write("\n\n");
        }
    }
}
