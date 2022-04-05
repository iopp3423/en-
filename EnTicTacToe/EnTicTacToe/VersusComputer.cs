namespace EnTicTacToe
{
    class VersusComputer
    {
        GameBoard Game = new GameBoard();
        GameCheck Win = new GameCheck();
        Judgement Result = new Judgement();
        ScoreBoard Score = new ScoreBoard();
        Random RandomValue = new Random();
        int data;
        int matrix;
        int count = 0; // 컴퓨터가 방어하는 경우의 수가 을 때 값을 입력넣기 위한 수       
        static public bool estimate = true;
        static private bool error;

        string InputSearch; // 오류 검출을 위한 입력 값
        public void Computer()
        {
            int RandomInt;
            bool RandomAnswer = true;
            RandomInt = RandomValue.Next();
            RandomInt = RandomInt % 10;

            Exception Code = new Exception();
            Console.Clear();
            Score.Board();
            Game.Overlap();
 

            while (estimate)
            {
                //////////////오류검출  및 입력코드/////////////////////
                Console.Write("번호를 입력하세요::");
                InputSearch = Console.ReadLine();
                error = Code.Check(InputSearch);
                if (error == true) data = int.Parse(InputSearch);
                else if (error == false)
                {
                        while (error != true)
                        {
                            Console.Clear();
                            Game.Overlap(); // 다시 입력
                            Console.Write("숫자 의외의 값입니다. 다시 입력해주세요 : ");
                            InputSearch = Console.ReadLine();
                            error = Code.Check(InputSearch);
                        }
                    data = int.Parse(InputSearch);
                }
                //////////////오류검출  및 입력코드/////////////////////

                if (GameBoard.array[data - 1] == 'O' || GameBoard.array[data - 1] == 'X') // 중복입력시 재입력
                {
                    Console.Clear(); // 중복해서 입력했을 때 화면 지우고
                    Game.Overlap(); // 다시 화면출력
                    Console.Write("다시 입력해주세요:"); // 입력했던 곳에 다시 입력할 때 재입력 안내
                    continue;
                }

                Game.FirstSet(data); // 사용자의 입력값 배열에 넣기
                GameCheck.draw++; // 입력 횟수
                Result.Judge(); // Judgement 클래스로 이동 후 행렬 체크

                // == 'O'은 ' '끼리 같은 때 X가 입력되는 것을 방지
                // continue는 두 개의 행과 열이 중첩 반복될 때 x가 두 번 입력되는 것을 방지
                //Draw는 0, x 수 
                count = 0;
                if (GameBoard.array[0] == 'O' && GameBoard.array[1] == 'O' && GameBoard.array[1] != 'X') { Game.SecondSet(3); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[3] == 'O' && GameBoard.array[4] == 'O' && GameBoard.array[5] != 'X') { Game.SecondSet(6); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[6] == 'O' && GameBoard.array[7] == 'O' && GameBoard.array[8] != 'X') { Game.SecondSet(9); GameCheck.draw++; count++; Result.Judge(); continue; }
                // 오른쪽 두 개 열에 O 입력 시 x로 방어
                if (GameBoard.array[1] == 'O' && GameBoard.array[2] == 'O' && GameBoard.array[0] != 'X') { Game.SecondSet(1); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[4] == 'O' && GameBoard.array[5] == 'O' && GameBoard.array[4] != 'X') { Game.SecondSet(4); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[7] == 'O' && GameBoard.array[8] == 'O' && GameBoard.array[6] != 'X') { Game.SecondSet(7); GameCheck.draw++; count++; Result.Judge(); continue; }
                // 위에 두 개 행에 0 입력 시 x로 방어
                if (GameBoard.array[0] == 'O' && GameBoard.array[3] == 'O' && GameBoard.array[6] != 'X') { Game.SecondSet(7); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[1] == 'O' && GameBoard.array[4] == 'O' && GameBoard.array[7] != 'X') { Game.SecondSet(8); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[2] == 'O' && GameBoard.array[5] == 'O' && GameBoard.array[8] != 'X') { Game.SecondSet(9); GameCheck.draw++; count++; Result.Judge(); continue; }
                // 아래 두 개 행에 0 입력 시 x로 방어
                if (GameBoard.array[3] == 'O' && GameBoard.array[6] == 'O' && GameBoard.array[0] != 'X') { Game.SecondSet(1); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[4] == 'O' && GameBoard.array[7] == 'O' && GameBoard.array[1] != 'X') { Game.SecondSet(2); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[5] == 'O' && GameBoard.array[8] == 'O' && GameBoard.array[2] != 'X') { Game.SecondSet(3); GameCheck.draw++; count++; Result.Judge(); continue; }
                // 왼쪽에서 오른쪽 대각선 두 개 행 입력 시 x로 방어
                if (GameBoard.array[0] == 'O' && GameBoard.array[4] == 'O' && GameBoard.array[8] != 'X') { Game.SecondSet(9); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[4] == 'O' && GameBoard.array[8] == 'O' && GameBoard.array[0] != 'X') { Game.SecondSet(1); GameCheck.draw++; count++; Result.Judge(); continue; }
                // 오른쪽에서 왼쪽 대각선 두 개 행 입력 시 x로 방어
                if (GameBoard.array[2] == 'O' && GameBoard.array[4] == 'O' && GameBoard.array[6] != 'X') { Game.SecondSet(7); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[4] == 'O' && GameBoard.array[6] == 'O' && GameBoard.array[2] != 'X') { Game.SecondSet(3); GameCheck.draw++; count++; Result.Judge(); continue; }
                // 첫행과 세 번째 행이 같을 시
                if (GameBoard.array[0] == 'O' && GameBoard.array[6] == 'O' && GameBoard.array[3] != 'X') { Game.SecondSet(4); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[1] == 'O' && GameBoard.array[7] == 'O' && GameBoard.array[4] != 'X') { Game.SecondSet(5); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[2] == 'O' && GameBoard.array[8] == 'O' && GameBoard.array[5] != 'X') { Game.SecondSet(6); GameCheck.draw++; count++; Result.Judge(); continue; }
                // 첫열과 세 번째 열이 같을 시
                if (GameBoard.array[0] == 'O' && GameBoard.array[2] == 'O' && GameBoard.array[1] != 'X') { Game.SecondSet(2); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[3] == 'O' && GameBoard.array[5] == 'O' && GameBoard.array[4] != 'X') { Game.SecondSet(5); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[6] == 'O' && GameBoard.array[8] == 'O' && GameBoard.array[7] != 'X') { Game.SecondSet(8); GameCheck.draw++; count++; Result.Judge(); continue; }
                // 띄어진 대각선 원소끼리 같을 시
                if (GameBoard.array[0] == 'O' && GameBoard.array[8] == 'O' && GameBoard.array[4] != 'X') { Game.SecondSet(5); GameCheck.draw++; count++; Result.Judge(); continue; }
                if (GameBoard.array[2] == 'O' && GameBoard.array[6] == 'O' && GameBoard.array[4] != 'X') { Game.SecondSet(5); GameCheck.draw++; count++; Result.Judge(); continue; }

                //방어가 안되는 경우일 경우 제일 처음오는 ' '에 x값 대입
                if(count == 0)
                {
                    RandomAnswer = true;
                    while (RandomAnswer)
                    {
                        if (GameBoard.array[RandomInt] != '0' && GameBoard.array[RandomInt] != 'X') // O나 X가 아닌 좌표에 값 대입
                        {
                            Game.SecondSet(RandomInt + 1); //좌표에 값이 들어갈 때 -1이 되므로 +1로 넣어줌
                            Game.Overlap(); // 다시 화면출력
                            GameCheck.draw++; // 입력 횟수
                            RandomAnswer = false;
                        }
                        else
                        {
                            RandomInt = RandomValue.Next();
                            RandomInt %= 10; // 난수 생성후 %10을 통해 0~9까지 값이 나오게 설정
                        }
                    }
                    
               }
                
            }
        }
    }
}
