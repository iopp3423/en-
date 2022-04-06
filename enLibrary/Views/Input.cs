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
        List<UserInformationVo> UserInformation = new List<UserInformationVo>();
        Regex IdCheck = new Regex(@"^01[01678]-[0-9]{4}-[0-9]{4}$");

        string inputSearch; // 오류 검출을 위한 입력 값
        int input;
        static private int noError = 1;
        static private int error;
        static private bool pass = false;
        static private bool completeInformation;
        static private string id;
        static private string pw;
        static private string pwPass;
        static private string name;
        static private string callNumber;
        static private string address;
        static private int members=0;



        public int UserDoInPut()
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

        public void Id()
        {
            
        }
        public void Pw()
        {

        }
        public void PwPass()
        {

        }
        public void Name()
        {

        }
        public void CallNumber()
        {
            while (pass == false)
            {
                id = Console.ReadLine();
                Console.Write(id);
                completeInformation = IdCheck.IsMatch(id);
                if (completeInformation == true)
                {
                    UserInformation[0].Id = id;
                    Console.Write(UserInformation[0].Id);
                    pass = true;
                }
            }
        }
        public void Address()
        {

        }
    }
}
