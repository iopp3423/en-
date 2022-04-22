using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LibruryDatabase.Views
{
    internal class Screen
    {
       public void PrintMain()
        {
            Console.WriteLine(string.Format("{0,42}", "★          ★★★   ★★★★     ★★★★   ★★★★   ★★★★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★    ★     ★    ★   ★    ★   ★    ★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★  ★★     ★    ★   ★    ★   ★    ★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★★★       ★★★★   ★★★★   ★★★★      ★ "));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★  ★★     ★   ★    ★    ★   ★   ★       ★ "));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★    ★     ★    ★   ★    ★   ★     ★     ★ "));
            Console.WriteLine(string.Format("{0,42}", "★★★★★  ★★★   ★★★★     ★    ★   ★    ★   ★     ★     ★ "));
            Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
            Console.WriteLine(string.Format("{0,40}", "입력 : Enter                                              뒤로가기 : F5"));
            Console.Write("\n");
          
        }
        public void PrintUserOrAdmin()
        {
            Console.WriteLine(string.Format("  》:회원모드"));
            Console.WriteLine(string.Format("  》:관리자모드"));
        }
        
        public void PrintLogin()
        {

            Console.WriteLine("유저 ID(영어, 숫자 포함(8~10자) :");
            Console.WriteLine("유저 PW(영어, 숫자 포함(4~10자) :");
            //Console.SetCursorPosition((Console.WindowWidth - "로그인 :".Length) / 2, Console.CursorTop);
            //Console.SetCursorPosition((Console.WindowWidth - "회원가입:".Length) / 2, Console.CursorTop);

        }

        public void PrintJoinMember()
        {
            Console.WriteLine("유저 ID(영어, 숫자 포함(8~10자) :");
            Console.WriteLine("유저 PW(영어, 숫자 포함(4~10자) :");
            Console.WriteLine("유저 PW확인(영어, 숫자 포함(4~10자) :");
            Console.WriteLine("유저 이름(2~5자) :");
            Console.WriteLine("나이 :");
            Console.WriteLine("핸드폰 번호(01x-xxxx-xxxx) :");
            Console.WriteLine("주소 :");  
        }

        public void JoinPrint()
        {
            Console.WriteLine(string.Format("{0,35}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,41}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,41}", "★                          회   원   가   입                       ★"));
            Console.WriteLine(string.Format("{0,34}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,34}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,35}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────\n\n\n"));
        }
        public void PrintBack()
        {
            Console.WriteLine(string.Format("{0,40}", "입력 : Enter                                              뒤로가기 : F5"));
            Console.WriteLine("\n");
        }

        public void JoinOrLogin()
        {
            Console.WriteLine(string.Format("  》회원가입"));
            Console.WriteLine(string.Format("  》로그인"));
        }

        public void PrintUserMenu()
        {
            Console.WriteLine("  》:도서찾기");
            Console.WriteLine("  》:도서대여");
            Console.WriteLine("  》:도서확인");
            Console.WriteLine("  》:회원정보수정");

        }

        public void PrintSearchMenu()
        {
            Console.Write("원하시는 검색 메뉴 -> Enter -> 검색                       뒤로가기 : F5");
            Console.WriteLine("\n");
            Console.WriteLine("  》작가명으로찾기 ");
            Console.WriteLine("  》출판사로찾기 ");
            Console.WriteLine("  》제목으로찾기 ");
            Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
        }


        public void PrintUserData() // 
        {

            string getUser = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection user = new MySqlConnection(getUser))
            {
                user.Open();
                string sql = "SELECT * FROM member";

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(sql, user);
                MySqlDataReader userInformation = Command.ExecuteReader();

                while (userInformation.Read())
                {
                    Console.WriteLine(userInformation["id"].ToString());
                    Console.WriteLine(userInformation["pw"].ToString());
                    Console.WriteLine(userInformation["name"].ToString());
                    Console.WriteLine(userInformation["phone"].ToString());
                    Console.WriteLine(userInformation["age"].ToString());
                    Console.WriteLine(userInformation["address"].ToString());
                    Console.WriteLine("===============================================================");
                }
                userInformation.Close();
            }
        }
    }
}
