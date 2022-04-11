namespace EnLibrary3.Controls
{
    using EnLibrary3.Controls;
    using EnLibrary3.Views;
    internal class UserRevise
    {
       
        bool isFinished = true;
        //InputKey Input = new InputKey();
        Print View = new Print();
        
        ConsoleKeyInfo cursur;
        public void ReviseUser()
        {
            ListVO List = new ListVO();
            Console.Clear();
           
            View.PrintUserRevise();
            foreach (UserVO list in List.UserList)
            {
                if (list.Id == InputKey.loginId)
                {
                    Console.Write(list);
                }
            }
            Console.WriteLine();
            Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
            View.PrintUser();
            Console.SetCursorPosition(0, 13);


                int x = 0, y = 13;
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
                            if (y < 13) y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            y++;
                            if (y > 16) y--; // 선택 외의 화면으로 커서 못나감
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
