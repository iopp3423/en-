using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibruryDatabase.Exception
{
    internal class Constants
    {
        static public void ClearCurrentLine(int number) // 줄 지우기 함수 위치 바꾸자
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop-number);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(CURRENT_LOCATION, currentLineCursor);
        }

        static public bool SEARCH_RESULT_BOOK;
        static public ConsoleKeyInfo cursor; //커서

        public const string REVISE_BOOK_QUANTITY = "1";
        public const int ONE = 1;
        public const int CONSOLE_SIZE_WIDTH = 75;
        public const int CONSOLE_SIZE_HDIGHT = 40;
        public const int CURRENT_LOCATION = 0;
        public const int BEFORE_INPUT_LOCATION = 1;
        public const bool CHECK = false;
        public const bool ENTRANCE = true;
        public const bool LOGIN = true;
        public const bool PASS = true;
        public const bool BACK = false;
        public const bool BACK_MENU = false;
        public const bool SUCESS = true;
        public const bool FAIL = false;
        public const bool GO_USER_SEARCH = true;
        public const bool GO_ADMIN_SEARCH = false;

        public const int FIRSTX=0;
        public const int FIRSTY=10;
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
        public const int SEARCH_X = 0;
        public const int SEARCH_Y = 2;
        public const int PW_FAIL_X = 4;
        public const int PW_FAIL_Y = 8;
        public const int NAME_SEARCH_Y=2;
        public const int BOOK_Y = 4;
        public const int PUBLISH_Y=3;
        public const int NAME_LINE = 2;
        public const int PUBLISH_LINE = 3;
        public const int BOOKNAME_LINE = 4;
        public const int EXIT = 1;
    



        public const int ID_X = 28;
        public const int PW_X = 28;
        public const int PW_CHECK_X = 32;
        public const int NAME_X = 18;
        public const int AGE_X = 7;
        public const int NUMBER_X = 28;
        public const int ADDRESS_X = 7;

        public const int GOING_PHONE = 21;
        public const int GOING_PASSWORD = 22;
        public const int GOING_ADDRESS = 23;
        public const int DONE_REVISE_Y = 19;
        public const int DONE_REVISE_X = 13;


        public const int ADD_BOOK = 11;
        public const int REMOVE_BOOK = 12;
        public const int REVISE_BOOK = 13;
        public const int USER_MANAGE = 14;
        public const int CURRENT_BOOK = 15;

        //AddingBook에서 좌표 
        public const int BOOK_NAME_X = 29;
        public const int BOOK_NAME_Y = 10;
        public const int AUTHOR_X = 25;
        public const int PUBLISHER_X = 25; 
        public const int PUBLISH_DAY_X = 21;   
        public const int QUANTITY_X = 20; 
        public const int BOOK_PRICE_X = 6;


        //수량 or 가격 입력
        public const int InputMenu_Y = 7;
        public const int GO_QUANTITY = 1;
        public const int GO_PRICE = 2;

        //아이디 비밀번호 오류 메시지
        public const int ERROR_X=24;
        public const int ERROR_Y=9;

        //회원관리 이름입력 위치
        public const int INPUT_NAME_Y = 5;
        public const int INPUT_NAME_X = 20;
    }
}
