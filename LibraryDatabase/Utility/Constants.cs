using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibruryDatabase.Utility
{
    internal class Constants
    {
        

        static public bool SEARCH_RESULT_BOOK;
        static public ConsoleKeyInfo cursor; 

        //query문 모음
        //유저관련
        public const string Query = "Server=localhost;Database=jojunhee;Uid=root;Pwd=0000;";
        public const string SearchMemberQuery = "SELECT * FROM member";
        public const string BorrrowBookUserquery = "SELECT * FROM borrowmember";
        public const string AdminSearchQuery = "SELECT * FROM admin";
        public const string borrowUserQuery = "SELECT * FROM borrowmember WHERE id = ('{0}')";        
        public const string DeleteQuery = "DELETE FROM book WHERE number = ('{0}')";
        public const string ModifyQuantityQuery = "UPDATE book SET quantity = ('{0}') WHERE number = ('{1}')";
        public const string ModifyPriceQuery = "UPDATE book SET price = ('{0}') WHERE number = ('{1}')";
        public const string borrowIdQuery = "SELECT * FROM borrowmember WHERE id = ('{0}')";
        public const string SearchDataQuery = "SELECT name, author, publish FROM book WHERE number = ('{0}')";
        public const string borrowedIdQuery = "SELECT * FROM book WHERE number = ('{0}')";

        //책 관련
        public const string SearchBookQuery = "SELECT * FROM book";
        public const string insertUserQuery = "INSERT INTO member(id,pw,name,phone,age,address) VALUES(('{0}'),('{1}'),('{2}'),('{3}'),('{4}'),('{5}'));";
        public const string DeleteUserQuery = "DELETE FROM member WHERE id = ('{0}')";
        public const string updatePhoneQuery = "UPDATE member SET phone = ('{0}') WHERE id = ('{1}')";
        public const string updatePwQuery = "UPDATE member SET pw = ('{0}') WHERE id = ('{1}')";
        public const string updateAddressQuery = "UPDATE member SET  address = ('{0}') WHERE id = ('{1}')";
        public const string revomeReturnBook = "DELETE FROM borrowmember WHERE id = ('{0}') AND number =  ('{1}')";
        public const string RemoveBorrowmember = "DELETE FROM borrowmember WHERE id = ('{0}')";
        public const string borrowQuery = "INSERT INTO borrowmember(id, number, bookname, author, publish, borrowbook, returnbook) VALUES( ('{0}'),  ('{1}'),  ('{2}'),  ('{3}'),  ('{4}'),  ('{5}'), ('{6}'));";
        public const string minusBook = "UPDATE book SET quantity = quantity - 1 WHERE number =  ('{0}')";
        public const string plusBook = "UPDATE book SET quantity = quantity + 1 WHERE number =  ('{0}')";
         public const string addUserBookQuery = "INSERT INTO book(name,author,publish,publishDay,price,isbn,quantity) VALUES(  ('{0}'),  ('{1}'),  ('{2}'),  ('{3}'),  ('{4}'),  ('{5}'), ('{6}'));";
        public const string requestBookQuery = "INSERT INTO requestbook(name,author,publish,publishDay,price,isbn,quantity) VALUES(  ('{0}'),  ('{1}'),  ('{2}'),  ('{3}'),  ('{4}'),  ('{5}'), ('{6}'));";
        public const string RemoveBorrowBookQuery = "DELETE FROM borrowmember WHERE number = ('{0}')";
        public const string DeleteRequestQuery = "DELETE FROM requestbook WHERE number = ('{0}')";


        //로그관련
        public const string InsertlogQuery = "INSERT INTO LOG(TIME, name, record, log) VALUES(  ('{0}'),  ('{1}'), ('{2}'), ('{3}'));";
        public const string logQuery = "SELECT * FROM LOG";
        public const string LogDeleteQuery = "DELETE FROM LOG WHERE number = ('{0}')";
        public const string RemoveAllLog = "TRUNCATE LOG;";

        //네이버 아이디 비밀번호
        public const string NAVER_ID ="wIcEQfjn2NsKuQmIlo2S";
        public const string NAVER_PASSWORD = "ocXHc9Sh_7";
        public const string NaverBookQuery = "INSERT INTO naver(title,author,price,publisher,publishday,isbn,description) VALUES(  ('{0}'),  ('{1}'),  ('{2}'),  ('{3}'), ('{4}'), ('{5}'),  ('{6}'));";
        public const string RemoveAllNaverBook = "TRUNCATE naver;";
        public const string naverQuery = "SELECT * FROM naver;";
        public const string requestQuery = "INSERT INTO requestbook SELECT * FROM naver WHERE number = ('{0}')"; 
        public const string userRequestQuery = "Select * FROM requestbook";




        public const string REVISE_BOOK_QUANTITY = "1";
        public const string NONE_BOOK = "0";
        public const int ONE = 1;
        public const int RIMIT = 100;
        public const int CONSOLE_SIZE_WIDTH = 75;
        public const int CONSOLE_SIZE_HDIGHT = 40;
        public const int CURRENT_LOCATION = 0;
        public const int BEFORE_INPUT_LOCATION = 1;
        public const bool isEntrancing = true;
        public const bool isLogin = true;
        public const bool isPassing = true;
        public const bool isBack = false;
        public const bool isBackMenu = false;
        public const bool isSucess = true;
        public const bool isFail = false;
        public const bool isUserSearching = true;
        public const bool isAdminSearching = false;

        public const int FIRSTX=0;
        public const int FIRSTY=10;
        public const int LOGIN_Y = 10;
        public const int LOGIN_X = 43;
        public const int PASSWORED_Y = 11;
        public const int USER_Y = 10;
        public const int ADMIN_Y = 11;
        public const int START_UP_Y = 10;
        public const int START_DOWN_Y = 11;
        public const int Register_X = 0;
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
        public const int VERIFICATION_LOG = 14;
        public const int REQUEST_BOOK = 14;
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
        public const int RETURNDAY = 14;





        public const int ID_X = 28;
        public const int PW_X = 28;
        public const int PW_CHECK_X = 32;
        public const int NAME_X = 18;
        public const int AGE_X = 7;
        public const int NUMBER_X = 28;
        public const int ADDRESS_X = 18;

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
        public const int LOG_MANAGE = 16;
        public const int NABER_SEARCH = 17;
        public const int REQUEST = 18;

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

        public const int REQUEST_X = 30;


        //로그
        public const string ADMIN = "관리자";
        public const string REMOVE = "도서삭제";
        public const string REMOVE_USER = "회원삭제";
        public const string REVISE_QUANTITY = "수량수정";
        public const string REVISE_PRICE = "가격수정";
        public const string ADD = "도서추가";
        public const string BOOK_LIST = "도서목록";
        public const string OPEN_LIST = "열람";
        public const string LIBRARY = "도서관";
        public const string LOGIN = "로그인";
        public const string BORROW = "도서 대여";
        public const string REGISTER = "회원가입";
        public const string RETURN = "도서 반납";
        public const string SEARCH_TITLE = "책 제목 검색";
        public const string SEARCH_PUBLISHER = "출판사로 검색";
        public const string SEARCH_AUTHOR = "작가로 검색";

    }
}
