using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EnLibrary3.Views
{
    using EnLibrary3.Views;
    internal class InputKey
    {
        Regex IdCheck = new Regex(@"^[0-9a-zA-Z]{8,10}$");
        Regex CallNumberCheck = new Regex(@"^01[0-9]-[0-9]{4}-[0-9]{4}$");
        Regex PwCheck = new Regex(@"^[0-9a-zA-Z]{4,10}$");
        Regex NameCheck = new Regex(@"^[가-힣]{2,5}$");
        Regex AgeCheck = new Regex(@"^[0-9]{1,2}1?[0-9]?[0-9]$");
        Exeption ErrorCheck = new Exeption();
        int input;
        string inputSearch; // 오류 검출을 위한 입력 값
        static private int noError = 1;
        static private int error;
        static private string pwPass; // 전역변수 지역변수로 바꿔줘야함 //////////////////////////////////////////////////////
        static private string name;
        static private string callNumber;
        static private string age;
        static private string address;
        

        public int UserDoInput() // 1~9 에러 검출코드
        {
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
        /*
        public void Id() // Id 입력 코드
        {
            string id;
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.Clear();
                    PrintCollection.JoinUser();
                    Console.Write("잘못된 입력입니다. ID를 다시 입력해주세요 :");
                }
                id = Console.ReadLine(); // 아이디 입력                               
                completeInformation = IdCheck.IsMatch(id); // 유저아이디 정규화로 양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    Information.Id = id;
                    reEnter = true;
                    break;
                }
                reEnter = false;
            }
        }
        */

        /*
        public void Pw()
        {
            string pw;
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.Clear();
                    PrintCollection.JoinUser();
                    Console.Write("잘못된 입력입니다. PW를 다시 입력해주세요");
                }
                pw = Console.ReadLine(); // 비밀번호 입력                               
                completeInformation = PwCheck.IsMatch(pw); // 비밀번호 정규화로 양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    Information.Pw = pw; // 대입                 
                    reEnter = true;
                    break;
                }
                reEnter = false;
            }
        }
        public void PwPass()
        {
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.Clear();
                    PrintCollection.JoinUser();
                    Console.Write("잘못된 입력입니다. PW를 다시 입력해주세요 :");
                }
                pwPass = Console.ReadLine(); // 비밀번호 입력                               
                completeInformation = PwCheck.IsMatch(pwPass); // 비밀번호 정규화로 양식 맞는지 확인 && 기존의 비밀번호랑 맞는지 확인

                if (completeInformation == true && Information.Pw == pwPass) // 양식이 맞으면  
                {
                    Information.PwPass = pw; // 대입                 
                    reEnter = true;
                    break;

                }
                reEnter = false;
            }
        }

        public void Name()
        {
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.Clear();
                    PrintCollection.JoinUser();
                    Console.Write("잘못된 입력입니다. 이름을 다시 입력해주세요 :");
                }
                name = Console.ReadLine(); //이름 입력                               
                completeInformation = NameCheck.IsMatch(name); // 이름 정규화로 양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    Information.Name = name; // 대입                 
                    reEnter = true;
                    break;
                }
                reEnter = false;
            }
        }
        public void Age()
        {
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.Clear();
                    PrintCollection.JoinUser();
                    Console.Write("잘못된 입력입니다. 나이를 다시 입력해주세요 :");
                }
                age = Console.ReadLine(); //나이 입력                               
                completeInformation = AgeCheck.IsMatch(age); // 나이 정규화로 양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    Information.Age = age; // 대입                 
                    reEnter = true;
                    break;
                }
                reEnter = false;
            }
        }
        public void CallNumber()
        {
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.Clear();
                    PrintCollection.JoinUser();
                    Console.Write("잘못된 입력입니다. 전화번호를 다시 입력해주세요 :");
                }
                callNumber = Console.ReadLine(); // 전화번호 입력                               
                completeInformation = CallNumberCheck.IsMatch(callNumber); // 전화번호 정규화로 01x-xxxx-xxxx양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    Information.CallNumber = callNumber; // 대입                   
                    reEnter = true;
                    break;
                }
                reEnter = false;
            }
        }

        public void Address()
        {
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.Clear();
                    PrintCollection.JoinUser();
                    Console.Write("잘못된 입력입니다. 주소를 다시 입력해주세요 :");
                }
                address = Console.ReadLine(); //                                             
                Information.Address = address; // 대입
                Information.UserInformationStore();  /////////////////////////////////////여기까지 오면 회원가입 정보 저장 나중에 주소함수고치고 주소함수로 내려야함
                break;

            }
        }
        */
    }
}
