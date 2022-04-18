﻿using System;
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
        public const int FIRSTX=28;
        public const int FIRSTY=10;
        public const int LOGIN_Y = 10;
        public const int LOGIN_X = 43;
        public const int PASSWORED_Y = 11;
        public const int USER_Y = 10;
        public const int ADMIN_Y = 11;
        public const int START_UP_Y = 10;
        public const int START_DOWN_Y = 11;
    }
}