﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SejongTimeTable.Views;
using SejongTimeTable.Models;

namespace SejongTimeTable.Controls
{
    internal class FavoriteClass 
    {
        Printing MenuView = new Printing();
        List<ClassVO> MySubject = new List<ClassVO>(); // 관심과목 담는 리스트

        public ClassVO Favorite; // 엑셀값 저장

        public FavoriteClass()
        {

        }
        public FavoriteClass(ClassVO Favorite)
        {
            this.Favorite = Favorite;
        }

        public void Menu()
        {
            Constants.Is_CHECK = true; // 초기화
            Console.Clear();
            MenuView.PrintFavoriteClass();
            MySubject.Add(Favorite.Data[1]);
            /*
            foreach (ClassVO list in Favorite.Data)
            {
                Console.WriteLine(list);
            }
            */

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
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_SEARCH_Y) { Constants.Is_CHECK = false; Console.Write("Hello"); break; }
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_MY_Y) { Constants.Is_CHECK = false; MyClass(); break;}
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_TIME_Y) { Constants.Is_CHECK = false; Table(); Console.Write("Hello"); break; }
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

        public void Search()
        {
            Constants.Is_CHECK = true;//초기화
        }
        public void MyClass()
        {
            Console.Clear();
            MenuView.PrintMyClass();
            Constants.cursur = Console.ReadKey(true);
            if (Constants.cursur.Key == ConsoleKey.F5) Menu(); // 뒤로가기
            Console.Write(MySubject[0]);



            Constants.Is_CHECK = true;//초기화
        }
        public void Table()
        {
            Console.Clear();
            MenuView.PrintMyTable();
            Constants.cursur = Console.ReadKey(true);
            if (Constants.cursur.Key == ConsoleKey.F5) Menu(); // 뒤로가기


            Constants.Is_CHECK = true;//초기화
        }
        public void Remove()
        {
            Console.Clear();
            MenuView.PrintMyTable();
            Constants.cursur = Console.ReadKey(true);
            if (Constants.cursur.Key == ConsoleKey.F5) Menu(); // 뒤로가기



            Constants.Is_CHECK = true;//초기화

        }

    }
}
