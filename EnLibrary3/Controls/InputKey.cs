using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EnLibrary3.Controls
{
    using EnLibrary3.Views;
    using EnLibrary3.Controls;
    internal class InputKey
    {
        Regex IdCheck = new Regex(@"^[0-9a-zA-Z]{8,10}$");
        Regex CallNumberCheck = new Regex(@"^01[0-9]-[0-9]{4}-[0-9]{4}$");
        Regex PwCheck = new Regex(@"^[0-9a-zA-Z]{4,10}$");
        Regex NameCheck = new Regex(@"^[가-힣]{2,5}$");
        Regex AgeCheck = new Regex(@"^[0-9]{1,2}1?[0-9]?[0-9]$");
        Exeption ErrorCheck = new Exeption();
        UserVO User = new UserVO();
        ListVO List = new ListVO();
        LoginAfter After = new LoginAfter();
        //Login DoLogin = new Login();
        //public ListVO List;

        ConsoleKeyInfo back;
        ConsoleKeyInfo cursur;

        static private int noError = 1;
        static private int error;
        static private bool pass = false;
        static private bool reEnter = true;
        static private bool completeInformation;
        static private string pw; // 비밀번호 확인 때문에 전역변수선언
        static private string loginId; // 로그인 때문에 전역변수 선언
        
        public InputKey()
        {
        }
        public InputKey(ListVO List)
        {
            this.List = List;
        }
        
        public void BackUserMode() // 유저모드로 뒤돌아가기 함수
        {
            User UserMode = new User();
            back = Console.ReadKey(true);
            if(ConsoleKey.F5 == back.Key) { Console.Clear(); UserMode.Mode(); } // f5누르면 로그인 회원가입 선택화면으로 돌아가기        
        }

        public int UserDoInput() // 1~9 에러 검출코드
        {
            int input;
            string inputSearch; // 오류 검출을 위한 입력 값
            inputSearch = Console.ReadLine();
            error = ErrorCheck.Checking(inputSearch); //error가 1이면 정상
            if (error == noError) input = int.Parse(inputSearch);
            else
            {
                while (error != 1)
                {
                    Console.Write("다시 입력해주세요: ");
                    inputSearch = Console.ReadLine();
                    error = ErrorCheck.Checking(inputSearch); // 에러가 1이될 때까지 재입력
                }
                input = int.Parse(inputSearch); // 에러가 1이면 반복문 탈출 후 정수 값 대입
            }
            return input; // 정수 값 리턴
        }

        public void LoginId() //////////////로그인 아이디
        {
            BackUserMode();
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.SetCursorPosition(33, 6); // 커서 위치 맞게 변경                  
                    Console.Write(" 다시 입력해주세요 :");
                    //Console.Write(new string(' ', Console.WindowWidth));
                }

                loginId = Console.ReadLine(); // 아이디 입력
                completeInformation = IdCheck.IsMatch(loginId); // 유저아이디 정규화로 양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    Console.SetCursorPosition(48, 7); // 커서 위치 맞게 변경
                    reEnter = true;
                    break;
                }
                
                reEnter = false;
            }
        }

        public void LoginPw()/////////로그인 비밀번호
        {
            Login DoLogin = new Login();
            bool passlogin = false;
            BackUserMode();
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.SetCursorPosition(33, 7); // 커서 위치 맞게 변경                  
                    Console.Write(" 다시 입력해주세요 :");
                }
                pw = Console.ReadLine(); // 비밀번호 입력
                completeInformation = PwCheck.IsMatch(pw); // 비밀번호 정규화로 양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    foreach (UserVO list in List.UserList)
                    {
                        if(list.id == loginId && list.pw == pw)
                        {
                            passlogin = true;
                            reEnter = true;
                            pass = false;
                        }
                    }
                    if (passlogin == true)
                    {
                        Console.Clear();
                        pass = false;
                        After.BookMenu();
                    }
                    else if (passlogin == false)
                    {
                        Console.SetCursorPosition(28, 8);
                        Console.WriteLine("회원정보가 일치하지 않습니다.");
                        Console.SetCursorPosition(28, 9);
                        Console.Write("다시 입력하려면 ENTER를 눌러주세요.");
                        cursur = Console.ReadKey(true);
                        if (cursur.Key == ConsoleKey.Enter) { Console.Clear(); DoLogin.LibraryLogin(); } // enter누르면 로그인
                        else if (cursur.Key == ConsoleKey.Escape) return; // esc는 저
                        reEnter = true;
                        break;
                    }
                    
                    
                }
                //reEnter = false;
            }
        }


        public void Id() // Id 입력 코드
        {       
            string id;
            BackUserMode();
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.SetCursorPosition(34, 6); // 커서 위치 맞게 변경                  
                    Console.Write(" 다시 입력해주세요 :");
                    //Console.Write(new string(' ', Console.WindowWidth));
                }
                
                id = Console.ReadLine(); // 아이디 입력
                completeInformation = IdCheck.IsMatch(id); // 유저아이디 정규화로 양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    Console.SetCursorPosition(34, 7); // 커서 위치 맞게 변경
                    reEnter = true;
                    User.Id = id;
                    break;
                }
                reEnter = false;

            }
        }
        

        
        public void Pw()
        {
            BackUserMode();
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.SetCursorPosition(34, 7); // 커서 위치 맞게 변경                  
                    Console.Write(" 다시 입력해주세요 :");
                }
                pw = Console.ReadLine(); // 비밀번호 입력                               
                completeInformation = PwCheck.IsMatch(pw); // 비밀번호 정규화로 양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    Console.SetCursorPosition(38, 8); // 커서 위치 맞게 변경
                    reEnter = true;
                    User.Pw = pw;
                    break;
                }
                reEnter = false;
            }
        }


        public void PwPass()
        {
            BackUserMode();
            string pwPass;
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.SetCursorPosition(36, 8); // 커서 위치 맞게 변경                  
                    Console.Write(" 다시 입력해주세요 :");

                }
                pwPass = Console.ReadLine(); // 비밀번호 입력                               
                completeInformation = PwCheck.IsMatch(pwPass); // 비밀번호 정규화로 양식 맞는지 확인 && 기존의 비밀번호랑 맞는지 확인

                if (completeInformation == true && pwPass == pw) // 비밀번호가 맞으면  
                {
                    Console.SetCursorPosition(19, 9); // 커서 위치 맞게 변경
                    reEnter = true;
                    break;

                }
                reEnter = false;
            }
        }
       
        public void Name()
        {
            BackUserMode();
            string name;
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.SetCursorPosition(19, 9); // 커서 위치 맞게 변경                  
                    Console.Write(" 다시 입력해주세요 :");
                }
                name = Console.ReadLine(); //이름 입력                               
                completeInformation = NameCheck.IsMatch(name); // 이름 정규화로 양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    Console.SetCursorPosition(7, 10); // 커서 위치 맞게 변경
                    reEnter = true;
                    User.Name = name;
                    break;
                }
                reEnter = false;
            }
        }
        public void Age()
        {
            BackUserMode();
            string age;
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.SetCursorPosition(7, 10); // 커서 위치 맞게 변경                  
                    Console.Write(" 다시 입력해주세요 :");
                }
                age = Console.ReadLine(); //나이 입력                               
                completeInformation = AgeCheck.IsMatch(age); // 나이 정규화로 양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    Console.SetCursorPosition(27, 11); // 커서 위치 맞게 변경
                    reEnter = true;
                    User.Age = age;
                    break;
                }
                reEnter = false;
            }
        }
        public void CallNumber()
        {
            BackUserMode();
            string callNumber;
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.SetCursorPosition(27, 11); // 커서 위치 맞게 변경                  
                    Console.Write(" 다시 입력해주세요 :");
                }
                callNumber = Console.ReadLine(); // 전화번호 입력                               
                completeInformation = CallNumberCheck.IsMatch(callNumber); // 전화번호 정규화로 01x-xxxx-xxxx양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    Console.SetCursorPosition(6, 12); // 커서 위치 맞게 변경
                    reEnter = true;
                    User.CallNumber = callNumber;
                    break;
                }
                reEnter = false;
            }
        }

        public void Address()
        {
            User UserMode = new User();
            BackUserMode();
            string address;
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.SetCursorPosition(6, 12); // 커서 위치 맞게 변경                  
                    Console.Write(" 다시 입력해주세요 :");
                }
                address = Console.ReadLine();
                User.Address= address;

                List.UserList.Add(User);


                
                foreach (UserVO list in List.UserList)
                {
                    Console.WriteLine(list.id);
                    Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                }
                
                
                //UserMode.Mode();qhghtnw


                break;
            }
        }
        
    }
}
