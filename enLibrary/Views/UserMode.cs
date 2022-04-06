using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    class UserMode
    {
        Print PrintCollection = new Print();
        Input Inputting = new Input();
        static private int inputData;
        public void Mode()
        {
            Console.Clear();
            PrintCollection.LibraryPrint(); // 라이브러리 프린트
            PrintCollection.JoinOrLogin(); // 회원가입 or 로그인 프린트
            inputData = Inputting.UserDoInPut(); //사용자 입력
            switch(inputData)
            {
                case 0: JoinGroup(); break;
                case 1: Login(); break;
                case 2: break;
            }
        }

        public void JoinGroup()
        {

        }

        public void Login()
        {

        }
    }
}
