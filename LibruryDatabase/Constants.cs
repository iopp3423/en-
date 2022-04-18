using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibruryDatabase
{
    internal class Constants
    {
        public const string ID_CHECK = @"^[0-9a-zA-Z]{8,10}$";
        public const string NUMBER_CHECK = @"^01[0-9]-[0-9]{4}-[0-9]{4}$";
        public const string PW_CHECK = @"^[0-9a-zA-Z]{4,10}$";
        public const string NAME_CHECK = @"^[가-힣]{2,5}$";
        public const string AGE_CHECK = @"^[0-9]{1,2}1?[0-9]?[0-9]$";


        static public ConsoleKeyInfo cursur;
        public const int ONE = 1;
        public const int CONSOLE_SIZE_WIDTH = 75;
        public const int CONSOLE_SIZE_HDIGHT = 40;
        public const bool CHECK = false;
        public const bool ENTRANCE = true;
        public const bool LOGIN = true;
        public const int FIRSTX=0;
        public const int FIRSTY=11;
        public const int LOGIN_Y = 10;
        public const int LOGIN_X = 43;
        public const int PASSWORED_Y = 11;
        public const int USER_Y = 10;
        public const int ADMIN_Y = 11;
        public const int START_UP_Y = 10;
        public const int START_DOWN_Y = 11;
        public const int JOIN_X = 0;
        public const int ID_Y = 10;
        public const int PW_Y = 11;
        public const int PW_CHECK_Y = 12;
        public const int NAME_Y = 13;
        public const int AGE_Y = 14;
        public const int NUMBER_Y = 15;
        public const int ADDRESS_Y = 16;
        public const int SEARCH_BOOK = 10;
        public const int BORROW_BOOK = 11;
        public const int CHECK_BOOK = 12;
        public const int RIVISE_USER = 13;
    



        public const int ID_X = 33;
        public const int PW_X = 33;
        public const int PW_CHECK_X = 38;
        public const int NAME_X = 18;
        public const int AGE_X = 7;
        public const int NUMBER_X = 28;
        public const int ADDRESS_X = 7;

        public const bool BACK = false;
        public const bool BACK_MENU = false;
        
    }
}
