using System;
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
        
        int menuSelect;
        int resetZero = 0;
        int drawNumber = 9;
        int reGame = 2;
        int goMenu = 1;
        static private bool error;
        string inputSearch; // 오류 검출을 위한 입력 값
   
        public void ReGame()
        {
            Exception Code = new Exception();
            StartMenu Screen = new StartMenu();
            VersusUser UserCase = new VersusUser();
            VersusComputer ComputerCase = new VersusComputer();
            VersusUser.winner = false; // VsUser 클래스의 while문 종료
            VersusComputer.estimate = false; //Vscomputer 클래스의 while문 종료

            //////////////오류검출  및 입력코드/////////////////////
            inputSearch = Console.ReadLine();
            error = Code.Check(inputSearch);
            if (error == true) menuSelect = int.Parse(inputSearch);
            else if (error == false)
            {
                while (error != true)
                {
                    Console.Clear();
                    Game.Overlap(); // 다시 입력                
                    SelectPrint();
                    Console.Write("숫자 의외의 값입니다. 다시 입력해주세요 : ");
                    inputSearch = Console.ReadLine();
                    error = Code.Check(inputSearch);
                }
                menuSelect = int.Parse(inputSearch);
            }
            //////////////오류검출  및 입력코드/////////////////////
            Console.Clear();


            if (menuSelect == goMenu)
            {
                Reset(); // 리셋
                ScoreBoard.XPlayer = resetZero;
                ScoreBoard.YPlayer = resetZero;
                Screen.Menu(); // 메뉴 이동
            }
            
            else if (menuSelect == reGame && StartMenu.index > resetZero) // 0보다 크면 유저모드
            {
                StartMenu.index++;
                
                Reset();// 리셋
                UserCase.User(); // 유저랑 대결   
            }
            else if(menuSelect == reGame && StartMenu.index == resetZero) // 0이랑 같으면 컴퓨터
            {
                Reset();// 리셋
                ComputerCase.Computer(); // 컴퓨터랑 대결
            }        
        }
        public void Judge()
        {
            Win.Check(); // 행, 열, 대각선이 완성되는 것을 체크            
            if (GameCheck.winCheck == 1 && GameCheck.draw % 2 == 0) // 첫 번째 플레이어면서 행, 열, 대각선 중 하나가 완성됐을 때
            {
                ScoreBoard.XPlayer++;
                WinPlayer();
                Console.WriteLine("-----------------------X 승리-----------------------");
                SelectPrint();
                ReGame();
            }

            if (GameCheck.winCheck == 1 && GameCheck.draw % 2 == 1) // 두 번째 플레이어면서 행, 열 대각선 중 하나가 완성됐을 때
            {
                ScoreBoard.YPlayer++;
                WinPlayer();
                Console.WriteLine("-----------------------O 승리------------------------");
                SelectPrint();
                ReGame();
            }
            else if (GameCheck.draw == drawNumber) // 첫 번째 플레이어면서 무승부 일 때    
            {
                Console.Clear();
                Score.Board();
                Game.Overlap();
                Console.WriteLine("-----------------------무승부------------------------");
                SelectPrint();
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
            VersusUser.winner = true; // while 문 true로 재설정
            VersusComputer.estimate = true; // while 문 true로 재설정
            GameCheck.draw = 0;
            GameCheck.winCheck = 0;
            StartMenu.index = 0;
        }
        void SelectPrint()
        {
            Console.WriteLine("-------------------게임 종료는 0번-------------------");
            Console.WriteLine("-------------------메뉴 이동은 1번-------------------");
            Console.WriteLine("-----------------다시 시작하기는 2번-----------------");
        }
    }
}
