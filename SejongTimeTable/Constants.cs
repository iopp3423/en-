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
        static public string MENU = @"^[1-8]{1}$";

        public const int CONSOLE_SIZE_WIDTH = 120;
        public const int CONSOLE_SIZE_HEIGHT = 30;
        static public bool Is_CHECK = true;
        static public int ID_X_AXIS = 70;
        static public int ID_Y_AXIS = 14;
        static public int PW_X_AXIS = 70;
        static public int PW_Y_AXIS = 15;
        static public int MENU_X = 45;
        static public int MENU_Y = 6;
        static public int MENU_Y_UPSTRICT = 6;
        static public int MENU_Y_DOWNSTRICT = 9;
        static public int TABLE_Y = 6;
        static public int FAVORITE_Y = 7;
        static public int APPLICATION_Y = 8;
        static public int MYCLASS_Y = 9;
        static public int TIME_TABLE_Y = 6;
        static public int TIME_TABLE_X = 45;
        static public int TABLE_Y_UPSTRICT = 6;
        static public int TABLE_Y_DOWNSTRICT = 11;
        static public int ROW_START = 2;
        static public int ROW_END = 186;
        static public int COL_START = 0;
        static public int COL_END = 13;
        static public int ZERO = 0;
        static public bool IS_TRUE = true;
        static public ConsoleKeyInfo cursur;
    }
}
