using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SejongTimeTable.Views;
using SejongTimeTable.Models;
using System.Text.RegularExpressions;

namespace SejongTimeTable.Controls
{
    internal class FavoriteClass 
    {
        Printing MenuView = new Printing();
        List<ClassVO> MySubject = new List<ClassVO>();//???????????????????????뭐지 이거
        Regex RemoveData = new Regex(Constants.REMOVE_CLASS);

        public ClassVO Favorite; // 엑셀값 저장
        public ClassVO UserData;

        public FavoriteClass()
        {

        }
        public FavoriteClass(ClassVO Favorite, ClassVO UserData)
        {
            this.Favorite = Favorite;
            this.UserData = UserData;
        }
        

        public void Menu()
        {
            Constants.Is_CHECK = true; // 초기화
            Console.Clear();
            MenuView.PrintFavoriteClass();          

                

            while (Constants.Is_CHECK)
            {
                Console.SetCursorPosition(Constants.FAVORITE_MENU_X, Constants.FAVORITE_MENU_Y);
                Constants.cursur = Console.ReadKey(true);
                switch (Constants.cursur.Key)
                {

                    case ConsoleKey.UpArrow:
                        {
                            Constants.FAVORITE_MENU_Y -= 2;
                            if (Constants.FAVORITE_MENU_Y < Constants.FAVORITE_UP_Y) Constants.FAVORITE_MENU_Y += 2; // 선택 외의 화면으로 커서 못나감
                            break;
                        }

                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Constants.FAVORITE_MENU_Y += 2;
                            if (Constants.FAVORITE_MENU_Y > Constants.FAVORITE_DOWN_Y) Constants.FAVORITE_MENU_Y -= 2; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.F5:
                        {
                            //LoginId();  ///////////////////////////얘도 한 번 봐야함
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_SEARCH_Y) { Constants.Is_CHECK = false;  break; }
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_MY_Y) { Constants.Is_CHECK = false; MyClass(); break;}
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_TIME_Y) { Constants.Is_CHECK = false; Table(); break; }
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_REMOVE_Y) { Constants.Is_CHECK = false; Remove(); break;}
                            break;
                        }
                    case ConsoleKey.Escape: // 종료
                        {
                            return;
                        }

                    default: break;
                }
            }
        }

        public void Search() // 관심과목 검색
        {
            Constants.Is_CHECK = true;//초기화
        }
        public void MyClass()
        {
            Console.Clear();
            MenuView.PrintMyClass();
            foreach (ClassVO list in UserData.Data)
            {
                Console.WriteLine(list);
            }
            while (true)
            {
                Constants.cursur = Console.ReadKey(true);
                if (Constants.cursur.Key == ConsoleKey.F5) { Menu(); break; }// 뒤로가기
                else continue;
            }



            Constants.Is_CHECK = true;//초기화
        }

        public void Table() // 시간표
        {
            int row, col;
            Console.Clear();
            MenuView.PrintMyTable();
            MenuView.PrintTimeTable();
            Constants.cursur = Console.ReadKey(true);
            if (Constants.cursur.Key == ConsoleKey.F5) Menu(); // 뒤로가기


            Console.WriteLine(UserData.day);
            Console.Write("Helloworld");


            /*
            for (row = 0; row <20;row++)
            {
                for(col=0;col<5;col++)
                {
                    if (UserData.day.Contains("수")) Console.Write(UserData);
                    else Console.Write("          ");
                }
                Console.Write("\n\n");
            }
            */



            Constants.Is_CHECK = true;//초기화
        }




        public void Remove() // 관심과목 삭제
        {
            string removeNumber;
            int number;
            int sum = Constants.ZERO;
            foreach(ClassVO list in UserData.Data)
            {
                sum += int.Parse(list.score);
            }
            bool check = false;
            Console.Clear();
            Console.WriteLine("\n");
            Console.Write(string.Format("                                                                                                      신청 학점 : {0}  삭제할 과목 NO : ", sum));// 이거 고쳐야함
            
            MenuView.PrintMyClass();

            
            foreach (ClassVO list in UserData.Data)
            {
                Console.WriteLine(list);
            }

            while (true)
            {
                Console.SetCursorPosition(Constants.REMOVE_X, Constants.REMOVE_Y); //위치 설정
                removeNumber = Console.ReadLine();

                if (false == RemoveData.IsMatch(removeNumber))
                {
                    Console.SetCursorPosition(Constants.REMOVE_X, Constants.REMOVE_Y);
                    Console.Write("다시 입력해주세요"); continue;
                }
                break;
            }

            number = int.Parse(removeNumber);
            number -= Constants.ONE;


            foreach (ClassVO list in UserData.Data)
            {
                if (int.Parse(list.number) == int.Parse(removeNumber))
                {
                    check = true; // 번호가 존재
                    UserData.Data.RemoveAt(number); // 번호 삭제
                    Console.Write("강의를 지웠습니다. F5를 누르면 돌아갑니다.");
                    break;
                }
            }

            if(check == false) // 존재안하면 다시 
            {
                Console.Write("입력한 번호가 없습니다.");
                Remove();
            }



            while (true)
            {
                Console.SetCursorPosition(Constants.REMOVE_X, Constants.REMOVE_Y);
                Constants.cursur = Console.ReadKey(true);
                if (Constants.cursur.Key == ConsoleKey.F5) { Menu(); break; }// 뒤로가기
                else continue;


            }
            Constants.Is_CHECK = true;//초기화

        }

    }
}
