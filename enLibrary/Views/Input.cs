using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EnLibrary.Views
{
    using EnLibrary.Controls;
    class Input
    {
        Exeption ErrorCheck = new Exeption();
        Print PrintCollection = new Print();
        UserInformationVo Information = new UserInformationVo();      
        Regex IdCheck = new Regex(@"^[0-9a-zA-Z]{8,10}$");
        Regex CallNumberCheck = new Regex(@"^01[01678]-[0-9]{4}-[0-9]{4}$");
        Regex PwCheck = new Regex(@"^[0-9a-zA-Z]{4,10}$");
        Regex NameCheck = new Regex(@"^[가-힣]{2,5}$");
        Regex AgeCheck = new Regex(@"^[0-9]{1,2}1?[0-9]?[0-9]$");
        Regex AddressCheck = new Regex(@"^[가-힣]{2,5}[시] {1}[가-힣]{2,5}[구] {1}[가-힣]{2,5}[동 | 읍 | 면 | 리]{1} $");

        string inputSearch; // 오류 검출을 위한 입력 값
        int input;
        static private int noError = 1;
        static private int error;
        static private bool pass = false;
        static private bool reEnter = true;
        static private bool completeInformation;
        static public string idConfirm;
        static public string pwConfirm;
        static private string id;
        static private string pw;
        static private string pwPass;
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
                while(error != 1)
                {
                    Console.Clear();
                    PrintCollection.LibraryPrint(); // 라이브러리 출력
                    PrintCollection.MenuPrint(); // 메뉴 출력
                    Console.Write("다시 입력해주세요: ");                    
                    inputSearch = Console.ReadLine();
                    error = ErrorCheck.Checking(inputSearch); // 에러가 1이될 때까지 재입력
                }
                input = int.Parse(inputSearch); // 에러가 1이면 반복문 탈출 후 정수 값 대입
            }
            return input; // 정수 값 리턴
        }

        public void IdConfirm() // Id 입력 코드
        {
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.Clear();                  
                    Console.Write("잘못된 입력입니다. 설명에 맞게 입력해주세요 :");
                }
                idConfirm = Console.ReadLine(); // 아이디 입력                               
                completeInformation = IdCheck.IsMatch(idConfirm); // 유저아이디 정규화로 양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    reEnter = true;
                    break;
                }
                reEnter = false;
            }
        }
        public void PwConfirm() // Id 입력 코드
        {
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.Clear();
                    Console.Write("잘못된 입력입니다. 설명에 맞게 입력해주세요 :");
                }
                pwConfirm = Console.ReadLine(); // 아이디 입력                               
                completeInformation = PwCheck.IsMatch(pwConfirm); // 유저비밀번호 정규화로 양식 맞는지 확인
                Information.UserInformationStore(); // 나증에 지워줘야함@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                if (completeInformation == true) // 양식이 맞으면  
                {
                    reEnter = true;
                    break; //종료
                }
                reEnter = false;
            }
        }

        public void Id() // Id 입력 코드
        {
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false) 
                {                   
                    Console.Clear();
                    PrintCollection.JoinUser();
                    Console.Write("잘못된 입력입니다. 설명에 맞게 입력해주세요 :"); 
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
        public void Pw()
        {
            while (pass == false)
            {
                //PrintCollection.JoinUser(); // 위 회원가입 창 and Id 설명 출력
                if (reEnter == false)
                {
                    Console.Clear();
                    PrintCollection.JoinUser();
                    Console.Write("잘못된 입력입니다. 설명에 맞게 입력해주세요 :");
                }
                pw = Console.ReadLine(); // 비밀번호 입력                               
                completeInformation = PwCheck.IsMatch(pw); // 비밀번호 정규화로 양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    Information.Pw = pw; // 대입                 
                    reEnter = true;
                    Information.UserInformationStore(); // 이거 나중에 풀면 지워줘야함 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ 주소 or 전화번호에서 작성
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
                    Console.Write("잘못된 입력입니다. 설명에 맞게 입력해주세요 :");
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
                    Console.Write("잘못된 입력입니다. 설명에 맞게 입력해주세요 :");
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
                    Console.Write("잘못된 입력입니다. 설명에 맞게 입력해주세요 :");
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
                    Console.Write("잘못된 입력입니다. 설명에 맞게 입력해주세요 :");
                }
                callNumber = Console.ReadLine(); // 전화번호 입력                               
                completeInformation = CallNumberCheck.IsMatch(callNumber); // 전화번호 정규화로 01x-xxxx-xxxx양식 맞는지 확인
               
                if (completeInformation == true) // 양식이 맞으면  
                {
                    Information.CallNumber = callNumber; // 대입
                    //Information.UserInformationStore();  /////////////////////////////////////여기까지 오면 회원가입 정보 저장 나중에 주소함수고치고 주소함수로 내려야함
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
                    Console.Write("잘못된 입력입니다. 설명에 맞게 입력해주세요 :");
                }
                address = Console.ReadLine(); // 전화번호 입력                               
                completeInformation = AddressCheck.IsMatch(address); // 전화번호 정규화로 01x-xxxx-xxxx양식 맞는지 확인

                if (completeInformation == true) // 양식이 맞으면  
                {
                    Information.Address = address; // 대입
                    reEnter = true;
                    break;
                }
                reEnter = false;
            }
        }

    }
}
