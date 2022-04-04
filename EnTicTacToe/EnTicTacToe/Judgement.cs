﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    class Judgement
    {
        GameCheck Win = new GameCheck();
        GameBoard Game = new GameBoard();
        ScoreBoard Score = new ScoreBoard();
        
        int MenuSelect;
        static private bool Error;
        string InputSearch; // 오류 검출을 위한 입력 값
        public void ReGame()
        {
            Exception Code = new Exception();
            StartMenu Screen = new StartMenu();
            VsUser UserCase = new VsUser();
            VsComputer ComputerCase = new VsComputer();

            VsUser.Winner = false; // VsUser 클래스의 while문 종료
            VsComputer.Estimate = false; //Vscomputer 클래스의 while문 종료

            //////////////오류검출  및 입력코드/////////////////////
            InputSearch = Console.ReadLine();
            Error = Code.Check(InputSearch);
            if (Error == true) MenuSelect = int.Parse(InputSearch);
            else if (Error == false) { Console.Write("범위가 벗어난 값을 입력하여 게임이 종료됩니다.");}
            //////////////오류검출  및 입력코드/////////////////////
            Console.Clear();


            if (MenuSelect == 1)
            {
                Reset(); // 리셋
                ScoreBoard.XPlayer = 0;
                ScoreBoard.YPlayer = 0;
                Screen.Menu(); // 메뉴 이동
            }
            
            else if (MenuSelect == 2 && StartMenu.Index > 0) // 0보다 크면 유저모드
            {
                Reset();// 리셋
                UserCase.User(); // 유저랑 대결
               
            }
            else if(MenuSelect == 2 && StartMenu.Index == 0) // 0이랑 같으면 컴퓨터
            {
                Reset();// 리셋
                ComputerCase.Computer(); // 컴퓨터랑 대결
            }        
        }
        public void Judge()
        {
            Win.Check(); // 행, 열, 대각선이 완성되는 것을 체크
            if (GameCheck.Draw == 9) // 첫 번째 플레이어면서 무승부 일 때    
            {
                Console.Clear();
                Score.Board();
                Game.Overlap();
                Console.WriteLine("-----------------------무승부------------------------");
                Console.WriteLine("-------------------게임 종료는 0번-------------------");
                Console.WriteLine("-------------------메뉴 이동은 1번-------------------");
                Console.WriteLine("-----------------다시 시작하기는 2번-----------------");
                ReGame();
               
            }
            else if (GameCheck.WinCheck == 1 && GameCheck.Draw % 2 == 0) // 첫 번째 플레이어면서 행, 열, 대각선 중 하나가 완성됐을 때
            {
                ScoreBoard.XPlayer++;
                WinPlayer();
                Console.WriteLine("-----------------------무승부------------------------");
                Console.WriteLine("-------------------게임 종료는 0번-------------------");
                Console.WriteLine("-------------------메뉴 이동은 1번-------------------");
                Console.WriteLine("-----------------다시 시작하기는 2번-----------------");
                ReGame();
            }

            else if (GameCheck.WinCheck == 1 && GameCheck.Draw % 2 == 1) // 두 번째 플레이어면서 행, 열 대각선 중 하나가 완성됐을 때
            {
                ScoreBoard.YPlayer++;
                WinPlayer();
                Console.WriteLine("-----------------------무승부------------------------");
                Console.WriteLine("-------------------게임 종료는 0번-------------------");
                Console.WriteLine("-------------------메뉴 이동은 1번-------------------");
                Console.WriteLine("-----------------다시 시작하기는 2번-----------------");
                ReGame();
            }
        }
        public void WinPlayer()
        {
            Console.Clear();
            Score.Board();
            Game.Overlap();
        }
        public void Reset()
        {
            Game.Set();// 입력했던 값 초기화
            VsUser.Winner = true; // while 문 true로 재설정
            VsComputer.Estimate = true; // while 문 true로 재설정
            GameCheck.Draw = 0;
            GameCheck.WinCheck = 0;
        }
    }
}
