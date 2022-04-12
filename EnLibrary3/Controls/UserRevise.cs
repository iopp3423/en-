namespace EnLibrary3.Controls
{
    using EnLibrary3.Controls;
    using EnLibrary3.Views;
    using System.Text.RegularExpressions;
    internal class UserRevise
    {

        Regex IdCheck = new Regex(@"^[0-9a-zA-Z]{8,10}$");
        Regex CallNumberCheck = new Regex(@"^01[0-9]-[0-9]{4}-[0-9]{4}$");
        Regex PwCheck = new Regex(@"^[0-9a-zA-Z]{4,10}$");
        bool isFinished = true;
        Print View = new Print();       

        ConsoleKeyInfo cursur;
        public void ReviseUser()
        {
            string id;
            string pw;
            string call;
            string address;
            bool isRight;
            InputKey Input = new InputKey();
            ListVO List = new ListVO();
            UserVO User = new UserVO();
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
            Console.WriteLine(string.Format("{0,40}", "────---───변경하고 싶은 정보에 입력 전 Enter를 입력해주세요.─────────"));
            View.PrintUser();
            Console.SetCursorPosition(0, 13);


                int x = 16, y = 13;
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
                    case ConsoleKey.Escape:
                        {
                            isFinished = false;
                            return;
                        }
                    case ConsoleKey.Enter:
                        {                         

                            if (y == 13)
                            {
                                id = Console.ReadLine(); // 아이디 입력
                                isRight = IdCheck.IsMatch(id); // 유저아이디 정규화로 양식 맞는지 확인
                                if (isRight == true) { User.Id = id; }
                                foreach (UserVO list in List.UserList)
                                {
                                    if (list.Id == InputKey.loginId)
                                    {
                                        //list.id=id;
                                        Console.SetCursorPosition(30, 13);
                                        Console.Write("아이디가 변경되었습니다.");
                                        Console.SetCursorPosition(16, 14);
                                        //Console.Write(list.id);
                                        //isFinished = false;
                                    }
                                }
                                break;
                            } 

                            if (y == 14)
                            {
                                pw = Console.ReadLine();
                                isRight = IdCheck.IsMatch(pw); // 유저아이디 정규화로 양식 맞는지 확인
                                if (isRight == true) { User.Pw = pw; }
                                foreach (UserVO list in List.UserList)
                                {
                                    if (list.Id == InputKey.loginId)
                                    {
                                        list.Pw = pw;
                                        Console.SetCursorPosition(30, 14);
                                        Console.Write("비밀번호가 변경되었습니다.");
                                        Console.SetCursorPosition(16, 15);
                                    }
                                }
                                break;
                            }
                           

                            if (y == 15)
                            {
                                call = Console.ReadLine();
                                isRight = IdCheck.IsMatch(call); // 유저아이디 정규화로 양식 맞는지 확인
                                if (isRight == true) { User.CallNumber = call; }

                                foreach (UserVO list in List.UserList)
                                {
                                    if (list.Id == InputKey.loginId)
                                    {
                                        list.CallNumber = call;
                                        Console.SetCursorPosition(30, 15);
                                        Console.Write("전화번호가 변경되었습니다.");
                                        Console.SetCursorPosition(16, 16);
                                    }
                                }
                                break;
                            }
                            
                            if (y == 16)
                            {
                                address = Console.ReadLine();
                                User.Address = address;
                                foreach (UserVO list in List.UserList)
                                {
                                    if (list.Id == InputKey.loginId)
                                    {
                                        list.Address = address;
                                        Console.SetCursorPosition(30, 16);
                                        Console.Write("주소가 변경되었습니다.");
                                        Console.SetCursorPosition(16, 17);
                                    }
                                }
                            }
                            break;

                        }
                    default: break;
                }
            }
            
        }
    }
    /*
    public void print()
    {
        foreach (UserVO list in List.UserList)
        {
            if (list.Id == InputKey.loginId)
            {
                Console.WriteLine(list);
            }
        }
    }
    */
}
  