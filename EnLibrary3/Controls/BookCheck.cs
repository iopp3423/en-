namespace EnLibrary3.Controls
{
    using EnLibrary3.Views;
    internal class BookCheck
    {
        Print View = new Print();
        bool isFinished = true;
        ConsoleKeyInfo cursur;
        public void CheckBook()
        {
            Console.Clear();
            int x = 15, y = 0;
            Console.WriteLine();
            View.PrintBookList();

            while (isFinished)
            {
                // x 와 y 좌표에 커서를 표시하기위한 메서드
                Console.SetCursorPosition(x, y);

                cursur = Console.ReadKey(true);
                // 저장된 키의 정보에 대해 검색

                switch (cursur.Key)
                {
                    // 상
                    case ConsoleKey.UpArrow:
                        {
                            y--;
                            if (y < 0) y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            y++;
                            if (y > 2) y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            isFinished = true;
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

    }
}
