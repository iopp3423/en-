﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    public class StartMenu
    {
        VsUser UserCase = new VsUser();
        VsComputer ComputerCase = new VsComputer();
        Exception Code = new Exception();
        ScoreBoard Score = new ScoreBoard();
        public static int MenuNumber; // 입력받을 메뉴 번호
        static private bool Error;
        string InputSearch; // 오류 검출을 위한 입력 값
        static public int Index=0; // 게임을 다시 시작할 때 구별하기 위한 값

        public void Menu()
        {
            Score.Board();
            Console.Write("      Tic Tac Toe 게임을 시작합니다!\n\n");
            Console.Write(" -----------------메뉴--------------------\n");
            Console.Write("ㅣ게임을 종료하시려면 0번을 입력주세요.  ㅣ\n");
            Console.Write("ㅣ유저끼리 대결하시려면 1번을 입력주세요.ㅣ\n");
            Console.Write("ㅣ컴퓨터와 대결하시려면 2번을 입력주세요.ㅣ\n");
            Console.Write(" -----------------------------------------\n");
            Console.Write("모드 선택 : ");

            //////////////오류검출  및 입력코드/////////////////////
            InputSearch = Console.ReadLine();
            Error = Code.Check(InputSearch);
            if (Error == true) MenuNumber = int.Parse(InputSearch);
            else if (Error == false) { Console.Write("범위가 벗어난 값을 입력하여 게임이 종료됩니다.");}
            //////////////오류검출  및 입력코드/////////////////////

            while (MenuNumber != 0)
            { 
                Console.Clear();
                if (MenuNumber == 1) // 1번 입력받으면 VS유저로 이동 후 종료
                {
                    UserCase.User();
                    Index++;
                    break;
                }
                else if (MenuNumber == 2) // 2번 입력받으면 VS컴퓨터로 이동 후 종료
                {
                    ComputerCase.Computer();
                    break;
                }
                else // 그 외 입력받으면 다시 입력
                {
                    Console.Write("      Tic Tac Toe 게임을 시작합니다!\n\n");
                    Console.Write(" -----------------메뉴--------------------\n");
                    Console.Write("ㅣ게임을 종료하시려면 0번을 입력주세요.  ㅣ\n");
                    Console.Write("ㅣ유저끼리 대결하시려면 1번을 입력주세요.ㅣ\n");
                    Console.Write("ㅣ컴퓨터와 대결하시려면 2번을 입력주세요.ㅣ\n");
                    Console.Write(" -----------------------------------------\n");
                    Console.Write("잘못 입력하셨습니다. 모드를 다시 입력해주세요.\n");
                    Console.Write("모드 선택 : ");
                    MenuNumber = int.Parse(Console.ReadLine()); // 모드 선택을 위한 메뉴넘버 입력
                }              
            }
        }
    }
}