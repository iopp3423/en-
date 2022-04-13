using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SejongTimeTable.Controls
{
    internal class Logging
    {
        Regex IdCheck = new Regex(@"^[0-9]{8}$");
        Regex PwCheck = new Regex(@"^[0-9]{4,10}$");
        public void Login()
        {
            
        }


    }
}
