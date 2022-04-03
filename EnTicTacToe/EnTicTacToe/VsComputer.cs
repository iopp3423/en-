using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    class VsComputer
    {
        GameBoard Game = new GameBoard();
        GameCheck Win = new GameCheck();
        Judgement Result = new Judgement();

        static public bool Estimate = true;
        public void Computer()
        {
            int Data;
            int Matrix;


            Console.Clear();
            Console.Write("---l---l---\n");
            Console.Write(" 1 l 2 l 3\n");
            Console.Write("---l---l---\n");
            Console.Write(" 4 l 5 l 6\n");
            Console.Write("---l---l---\n");
            Console.Write(" 7 l 8 l 9\n");
            Console.Write("---l---l---\n");
            Console.Write("번호를 입력하세요:");

            while(Estimate)
            {
                Data = int.Parse(Console.ReadLine());// 플레이어 입력
                if (GameBoard.Array[Data - 1] != ' ')
                {
                    Console.Clear(); // 중복해서 입력했을 때 화면 지우고
                    Game.Overlap(); // 다시 화면출력
                    Console.Write("다시 입력해주세요:"); // 입력했던 곳에 다시 입력할 때 재입력 안내
                    continue;
                }

                Game.FirstSet(Data); // 입력값 배열에 넣기
                GameCheck.Draw++; // 입력 횟수
                Result.Judge();

                for (Matrix = 1; Matrix <= 9; Matrix++)
                {
                    if (GameBoard.Array[Matrix-1] == ' ' && Matrix == 1) // 컴퓨터의 제일 처음 값은 ' '가 가장 빨리 오는 곳에 값을 넣는다.
                    {
                        Game.SecondSet(Matrix);
                        Game.Overlap(); // 다시 화면출력
                        GameCheck.Draw++; // 입력 횟수
                        break;
                    }
                    else if (GameBoard.Array[Matrix - 1] == ' ')
                    {
                        // 왼쪽 두 개 열에 O 입력 시 x로 방어
                        if (GameBoard.Array[0] == GameBoard.Array[1]) Game.SecondSet(3);
                        else if (GameBoard.Array[3] == GameBoard.Array[4]) Game.SecondSet(6);
                        else if (GameBoard.Array[6] == GameBoard.Array[7]) Game.SecondSet(9);
                        // 오른쪽 두 개 열에 O 입력 시 x로 방어
                        if (GameBoard.Array[1] == GameBoard.Array[2]) Game.SecondSet(1);
                        else if (GameBoard.Array[4] == GameBoard.Array[5]) Game.SecondSet(4);
                        else if (GameBoard.Array[7] == GameBoard.Array[8]) Game.SecondSet(7);
                        // 위에 두 개 행에 0 입력 시 x로 방어
                        if (GameBoard.Array[0] == GameBoard.Array[3]) Game.SecondSet(7);
                        else if (GameBoard.Array[1] == GameBoard.Array[4]) Game.SecondSet(8);
                        else if (GameBoard.Array[2] == GameBoard.Array[5]) Game.SecondSet(9);
                        // 아래 두 개 행에 0 입력 시 x로 방어
                        if (GameBoard.Array[3] == GameBoard.Array[6]) Game.SecondSet(1);
                        else if (GameBoard.Array[4] == GameBoard.Array[7]) Game.SecondSet(2);
                        else if (GameBoard.Array[5] == GameBoard.Array[8]) Game.SecondSet(3);
                        // 왼쪽에서 오른쪽 대각선 두 개 행 입력 시 x로 방어
                        if (GameBoard.Array[0] == GameBoard.Array[4]) Game.SecondSet(9);
                        else if (GameBoard.Array[4] == GameBoard.Array[8]) Game.SecondSet(1);
                        // 오른쪽에서 왼쪽 대각선 두 개 행 입력 시 x로 방어
                        if (GameBoard.Array[2] == GameBoard.Array[4]) Game.SecondSet(7);
                        else if (GameBoard.Array[4] == GameBoard.Array[6]) Game.SecondSet(3);
                    }

                }

            }
        }
    }
}
