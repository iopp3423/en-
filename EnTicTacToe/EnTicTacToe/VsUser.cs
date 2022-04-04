using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    class VsUser
    {
        GameBoard Game = new GameBoard();
        GameCheck Win = new GameCheck();
        Judgement Result = new Judgement();
        ScoreBoard Score = new ScoreBoard();
        static public bool Winner = true;
        static private bool Error;
        string InputSearch; // 오류 검출을 위한 입력 값
        int Input; // 정수 
        public void User()
        {
            Exception Code = new Exception();
            Console.Clear();
            Score.Board();
            Console.Write("---l---l---\n");
            Console.Write(" 1 l 2 l 3\n");
            Console.Write("---l---l---\n");
            Console.Write(" 4 l 5 l 6\n");
            Console.Write("---l---l---\n");
            Console.Write(" 7 l 8 l 9\n");
            Console.Write("---l---l---\n");
            Console.Write("번호를 입력하세요:");

            while (Winner)
            {
                //////////////오류검출  및 입력코드/////////////////////
                InputSearch = Console.ReadLine();
                Error = Code.Check(InputSearch);
                if (Error == true) Input = int.Parse(InputSearch);
                else if (Error == false) { Console.Write("범위가 벗어난 값을 입력하여 게임이 종료됩니다."); break; }
                //////////////오류검출  및 입력코드/////////////////////

                if (GameBoard.Array[Input - 1] != ' ')
                {
                    Console.Clear(); // 중복해서 입력했을 때 지우고
                    Game.Overlap(); // 다시 입력
                    Console.Write("다시 입력해주세요:"); // 입력했던 곳에 다시 입력할 때 재입력 안내
                    continue;
                }

                else if (GameCheck.Draw % 2 == 0)  // 짝수면 첫 번째 플레이어
                {
                    Game.FirstSet(Input); // 입력값 배열에 넣기
                    GameCheck.Draw++; // 입력 횟수
                    Result.Judge();
                   if(Winner == true) Console.Write("X 입력할 차례입니다:");
                }

                else if (GameCheck.Draw % 2 == 1) // 홀수면 두 번째 플레이어
                {
                    Game.SecondSet(Input); // 입력값 배열에 넣기
                    GameCheck.Draw++; // 입력 횟수
                    Result.Judge();
                    if (Winner == true)  Console.Write("O 입력할 차례입니다:");
                }
            }
        }
    }
}
