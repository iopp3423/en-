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
            int Count = 0; // 컴퓨터의 맨 처음 값을 입력하기 위한 변수


            Console.Clear();
            Console.Write("---l---l---\n");
            Console.Write(" 1 l 2 l 3\n");
            Console.Write("---l---l---\n");
            Console.Write(" 4 l 5 l 6\n");
            Console.Write("---l---l---\n");
            Console.Write(" 7 l 8 l 9\n");
            Console.Write("---l---l---\n");
            Console.Write("번호를 입력하세요:");

            while (Estimate)
            {
                Data = int.Parse(Console.ReadLine());// 플레이어 입력
                if (GameBoard.Array[Data - 1] != ' ') // 중복입력시 재입력
                {
                    Console.Clear(); // 중복해서 입력했을 때 화면 지우고
                    Game.Overlap(); // 다시 화면출력
                    Console.Write("다시 입력해주세요:"); // 입력했던 곳에 다시 입력할 때 재입력 안내
                    continue;
                }

                Game.FirstSet(Data); // 사용자의 입력값 배열에 넣기
                GameCheck.Draw++; // 입력 횟수
                Result.Judge(); // Judgement 클래스로 이동 후 행렬 체크


                for (Matrix = 1; Matrix <= 9; Matrix++)
                {
                    if (Count == 0 && GameBoard.Array[Matrix - 1] == ' ') // 컴퓨터의 제일 처음 값은 ' '가 가장 빨리 오는 곳에 값을 넣는다.
                    {
                        Count++;
                        Game.SecondSet(Matrix);
                        Game.Overlap(); // 다시 화면출력
                        GameCheck.Draw++; // 입력 횟수
                        break;
                    }
                }
                // == 'O'은 ' '끼리 같은 때 X가 입력되는 것을 방지
                if (GameBoard.Array[0] == 'O' && GameBoard.Array[1] == 'O' && GameBoard.Array[2] == ' ') { Game.SecondSet(3); }
                if (GameBoard.Array[3] == 'O' && GameBoard.Array[4] == 'O' && GameBoard.Array[5] == ' ') { Game.SecondSet(6); }
                if (GameBoard.Array[6] == 'O' && GameBoard.Array[7] == 'O' && GameBoard.Array[8] == ' ') { Game.SecondSet(9); }
                // 오른쪽 두 개 열에 O 입력 시 x로 방어
                if (GameBoard.Array[1] == 'O' && GameBoard.Array[2] == 'O' && GameBoard.Array[0] == ' ') { Game.SecondSet(1); }
                if (GameBoard.Array[4] == 'O' && GameBoard.Array[5] == 'O' && GameBoard.Array[3] == ' ') { Game.SecondSet(4); }
                if (GameBoard.Array[7] == 'O' && GameBoard.Array[8] == 'O' && GameBoard.Array[6] == ' ') { Game.SecondSet(7); }
                // 위에 두 개 행에 0 입력 시 x로 방어
                if (GameBoard.Array[0] == 'O' && GameBoard.Array[3] == 'O' && GameBoard.Array[6] == ' ') { Game.SecondSet(7); }
                if (GameBoard.Array[1] == 'O' && GameBoard.Array[4] == 'O' && GameBoard.Array[7] == ' ') { Game.SecondSet(8); }
                if (GameBoard.Array[2] == 'O' && GameBoard.Array[5] == 'O' && GameBoard.Array[8] == ' ') { Game.SecondSet(9); }
                // 아래 두 개 행에 0 입력 시 x로 방어
                if (GameBoard.Array[3] == 'O' && GameBoard.Array[6] == 'O' && GameBoard.Array[0] == ' ') { Game.SecondSet(1); }
                if (GameBoard.Array[4] == 'O' && GameBoard.Array[7] == 'O' && GameBoard.Array[1] == ' ') { Game.SecondSet(2); }
                if (GameBoard.Array[5] == 'O' && GameBoard.Array[8] == 'O' && GameBoard.Array[2] == ' ') { Game.SecondSet(3); }
                // 왼쪽에서 오른쪽 대각선 두 개 행 입력 시 x로 방어
                if (GameBoard.Array[0] == 'O' && GameBoard.Array[4] == 'O' && GameBoard.Array[8] == ' ') { Game.SecondSet(9); }
                if (GameBoard.Array[4] == 'O' && GameBoard.Array[8] == 'O' && GameBoard.Array[0] == ' ') { Game.SecondSet(1); }
                // 오른쪽에서 왼쪽 대각선 두 개 행 입력 시 x로 방어
                if (GameBoard.Array[2] == 'O' && GameBoard.Array[4] == 'O' && GameBoard.Array[6] == ' ') { Game.SecondSet(7); }
                if (GameBoard.Array[4] == 'O' && GameBoard.Array[6] == 'O' && GameBoard.Array[2] == ' ') { Game.SecondSet(3); }
                // 첫행과 세 번째 행이 같을 시
                if (GameBoard.Array[0] == 'O' && GameBoard.Array[6] == 'O' && GameBoard.Array[3] == ' ') { Game.SecondSet(4); }
                if (GameBoard.Array[1] == 'O' && GameBoard.Array[7] == 'O' && GameBoard.Array[4] == ' ') { Game.SecondSet(5); }
                if (GameBoard.Array[2] == 'O' && GameBoard.Array[8] == 'O' && GameBoard.Array[5] == ' ') { Game.SecondSet(6); }
                // 첫열과 세 번째 열이 같을 시
                if (GameBoard.Array[0] == 'O' && GameBoard.Array[2] == 'O' && GameBoard.Array[1] == ' ') { Game.SecondSet(2); }
                if (GameBoard.Array[3] == 'O' && GameBoard.Array[5] == 'O' && GameBoard.Array[4] == ' ') { Game.SecondSet(5); }
                if (GameBoard.Array[6] == 'O' && GameBoard.Array[8] == 'O' && GameBoard.Array[7] == ' ') { Game.SecondSet(8); }
                // 띄어진 대각선 원소끼리 같을 시
                if (GameBoard.Array[0] == 'O' && GameBoard.Array[8] == 'O' && GameBoard.Array[4] == ' ') { Game.SecondSet(5); }
                if (GameBoard.Array[2] == 'O' && GameBoard.Array[6] == 'O' && GameBoard.Array[4] == ' ') { Game.SecondSet(5); }

                GameCheck.Draw++; // 입력 횟수
                Result.Judge();




            }
        }
    }
}
