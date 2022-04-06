using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    class Input
    {
        Exeption ErrorCheck = new Exeption();
        Print PrintCollection = new Print();
        string inputSearch; // 오류 검출을 위한 입력 값
        int input;
        static private int noError = 1;
        static private int error;



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
    }
}
