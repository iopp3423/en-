using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary3.Models
{

    public class ListVO
    {
        public List<BookVO> BookList = new List<BookVO>();
        public List<UserVO> UserList = new List<UserVO>();

        public ListVO()
        {
            BookList.Add(new BookVO("1", "자료구조", "세종대학교", "국형준", "20000원", "2"));
            BookList.Add(new BookVO("2", "Do it! 알고리즘 코딩 테스트 : 자바 편 ", "이지스퍼블리싱", "김종관", "28,800원", "4"));
            BookList.Add(new BookVO("3", " 생활코딩! 아마존 웹 서비스", "위키북스", "이고잉", "22,500원", "3"));
            BookList.Add(new BookVO("4", "생활코딩! 자바 프로그래밍 입문", "위키북스", "이고잉", "24,300원", "3"));
            BookList.Add(new BookVO("5", " Do it! 알고리즘 코딩 테스트 — 자바 편 ", "이지스퍼블리싱", "김종관", "22000원", "4"));


            UserList.Add(new UserVO("iopp1234", "cho1234", "조준희", "24", "010-4050-3135", "천안시 동남구 신부동"));
            UserList.Add(new UserVO("iopp1233", "cho1231", "조준희희", "21", "010-4050-3135", "천안시 동남구 두정동"));
            UserList.Add(new UserVO("iopp1232", "cho1232", "조준", "22", "010-4050-3135", "천안시 동남구 유량동"));
            UserList.Add(new UserVO("iopp1231", "cho1233", "조준희조", "23", "010-4050-3135", "서울특별시 광진구 군자동"));
            UserList.Add(new UserVO("iopp1230", "cho1235", "조준희준", "24", "010-4050-3135", "천안시 서북구 불당동"));
        }
              
    }    
}
