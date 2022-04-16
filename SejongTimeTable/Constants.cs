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
        static public string MENU = @"^[1-4]{1}$";
        static public string SUBJECT_NAME = @"^[가-힣a-zA-Z]{2,10}$";
        static public string PROFESSOR_NAME = @"^[가-힣a-zA-Z]{2,12}$";
        static public string REMOVE_CLASS = @"^[1-9]?[0-9]?[0-9]$";// 삭제할과목
        static public string GRADE_CHECK = @"^[1-5]{1}$";

        public const int CONSOLE_SIZE_WIDTH = 180;
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
        static public int TIME_TABLE_X = 1;
        static public int TABLE_Y_UPSTRICT = 6;
        static public int TABLE_Y_DOWNSTRICT = 11;
        static public int ROW_START = 2;
        static public int ROW_END = 186;
        static public int COL_START = 0;
        static public int COL_END = 13;
        static public int ZERO = 0;
        static public bool IS_TRUE = true;
        static public int MAJOR_CURSUR_X = 21;
        static public int MAJOR_CURSUR_Y = 6;
        static public int DIVISE_CURSUR_Y = 7;
        static public int NAME_CURSUR_Y = 8;
        static public int PROFESSOR_CURSUR_Y = 9;
        static public int GRADE_CURSUR_Y = 10;
        static public int CHECK_CURSUR_Y = 11;
        static public int GRADE_Y = 10;
        static public int REFER_Y = 11;
        static public int SUBJECT_X = 43;
        static public int PROFFSOR_X = 42;
        static public int FAVORITE_MENU_X = 51;
        static public int FAVORITE_MENU_Y = 5;
        static public int FAVORITE_UP_Y = 5;
        static public int FAVORITE_DOWN_Y = 11;
        static public int FAVORITE_SEARCH_Y = 5;
        static public int FAVORITE_MY_Y = 7;
        static public int FAVORITE_TIME_Y = 9;
        static public int FAVORITE_REMOVE_Y = 11;
        static public int REMOVE_X = 135;
        static public int REMOVE_Y = 2;
        static public int ONE = 1;
        static public int PRINT_X = 0;
        static public int PRINT_Y = 17;
        static public int CHOOSE_Y = 6;
        static public int CHOOSE_X = 0;
        static public int CHOOSE_UP_Y = 5;
        static public int CHOOSE_DOWN_Y = 15;
        static public int MAJOR_Y=6;
        static public int NUMBER_Y=8;
        static public int SUBJECT_Y=10;
        static public int PROFESSOR_Y=12;
        static public int GRADE_MENU_Y=14;
        static public int SEARCH_AFTER_X = 65;
        static public int SEARCH_AFTER_Y = 4;
        static public int POSSBLE_SCORE = 24;
        static public int TWO = 2;
        static public int THREE = 3;
        static public int FOUR = 4;
        static public int APPLY_X = 52;
        static public int APPLY_Y = 5;
        static public int APPLY_UP_Y = 5;
        static public int APPLY_DOWN_Y = 11;
        static public int APPLY_SEARCH_Y = 5;
        static public int APPLY_LOG_Y = 7;
        static public int APPLY_TABLE_Y = 9;
        static public int APPLY_REMOVE_Y =11;
        static public int APPLY_MAGOR_X = 1;
        static public int APPLY_MAGOR_Y = 2;
        static public int APPLY_MAGOR_UP = 2;
        static public int APPLY_MAGOR_DOWN = 7;
        static public int APPLY_MAGOR = 2;
        static public int APPLY_DIVISE_Y = 3;
        static public int APPLY_SUBJECT_Y = 4;
        static public int APPLY_PROFESSOR_Y = 5;
        static public int APPLY_GRADE_Y = 6;
        static public int APPLY_FAVORITE_Y = 7;
        static public int APPLY_SCORE = 21;
        static public int SEARCH_X = 0;
        static public int SEARCH_Y = 23;
        static public int REMOVE_APPLY_X = 66;





        static public ConsoleKeyInfo cursur;
    }
}
