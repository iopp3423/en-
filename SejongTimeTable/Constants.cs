using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SejongTimeTable
{
    static class Constants
    {
        static public string ID_CHECK = @"^[0-9]{8}$";
        static public string PW_CHECK = @"^[0-9]{4,10}$";

        public const int CONSOLE_SIZE_WIDTH = 120;
        public const int CONSOLE_SIZE_HEIGHT = 30;
        static public bool Is_CHECK = true;
        static public int ID_X_AXIS = 70;
        static public int ID_Y_AXIS = 14;
        static public int PW_X_AXIS = 70;
        static public int PW_Y_AXIS = 15;
        static public ConsoleKeyInfo cursur;
    }
}
