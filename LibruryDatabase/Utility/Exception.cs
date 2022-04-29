using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibruryDatabase.Utility
{
    internal class Exception
    {
        public const string ID_CHECK = @"^[0-9a-zA-Z]{8,10}$"; // 아이디
        public const string NUMBER_CHECK = @"^01[0-9]-[0-9]{4}-[0-9]{4}$"; // 전화번호
        public const string PW_CHECK = @"^[0-9a-zA-Z]{4,10}$";// 비밀번호
        public const string NAME_CHECK = @"^[가-힣]{2,5}$"; // 이름
        public const string AGE_CHECK = @"^[1-9]{1}1?[0-9]?[0-9]?"; // 나이
        public const string ADDRESS_CHECK = @"^(([가-힣]+(d|d(,|.)d|)+(읍|면|동|가|리))(^구|)((d(~|-)d|d)(가|리|)|))([ ](산(d(~|-)d|d))|)|(([가-힣]|(d(~|-)d)|d)+(로|길))$"; // 주소
        public const string AUTHOR_CHECK = @"^[a-zA-Z가-힣]{2,8}$"; //작가
        public const string PUBLISH_CHECK = @"^[가-힣]{2,8}$"; // 출판사
        public const string TITLE_CHECK = @"^[가-힣a-zA-Z]{2,10}$"; //제목
        public const string BOOKNUMBER_CHECK = @"^[1-9]?[0-9]?[0-9]$"; //책번호
        public const string PUBLISH_DAY = @"^[0-9]{4}/[0-9]{2}/[0-9]{2}$"; // 출시일
        public const string QUANTITY = @"^[1-9]{1}1?[0-9]?[0-9]?"; // 수량
        public const string PRICE = @"^[1-9]{1}[0-9]{3,6}$"; // 가격 
        public const string MODIFICATION_BOOK = @"^[1-2]{1}$"; 
    }
}
