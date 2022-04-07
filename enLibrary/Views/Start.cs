using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    class Start
    {
        static void Main(string[] args)
        {
            SelectMode Mode = new SelectMode();
            Mode.Print();      
        }
    }
    
    /*
    class Program
    {
        static void Main(string[] args)
        {
            List<int> number = new List<int>();     //리스트 생성

            number.Add(10);      //리스트 추가
            number.Add(20);      //리스트 추가
            number.Add(30);      //리스트 추가

            Console.WriteLine(number[0]);       //[0] 번째 리스트 출력
            Console.WriteLine(number[1]);       //[1] 번째 리스트 출력
            Console.WriteLine(number[2]);       //[2] 번째 리스트 출력

            number.Remove(10);      //리스트에서 10을 삭제 합니다

            Console.WriteLine(number[0]);       //[0] 번째 리스트 출력
            Console.WriteLine(number[1]);       //[1] 번째 리스트 출력

            int I = 20;     //체크할 숫자 선언

            if (number.Contains(I))     //리스트에서 숫자 체크
            {
                Console.WriteLine("{0}이 리스트에 존재함", I);
            }
        }
    }
    */
}