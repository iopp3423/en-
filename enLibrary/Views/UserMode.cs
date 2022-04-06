using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EnLibrary.Views
{
    using EnLibrary.Controls;
    class UserMode
    {
        Print PrintCollection = new Print();
        Input Inputting = new Input();
        UserInformationVo print = new UserInformationVo();
        UserInformationVo UserInformationVO = new UserInformationVo();
        List<UserInformationVo> users = new List<UserInformationVo>();

        static private int inputData;
        public void Mode() // 모드 설정 함수
        {
            Console.Clear();
            PrintCollection.LibraryPrint(); // 라이브러리 출력
            PrintCollection.JoinOrLogin(); // 회원가입 or 로그인 출력
            inputData = Inputting.UserDoInPut(); //사용자 입력
            switch (inputData)
            {
                case 0: JoinGroup(); break;
                case 1: Login(); break;
                case 2: break;
            }
        }

        public void JoinGroup() // 회원가입
        {
            Console.Clear();
            PrintCollection.Join(); // 위에 회원가입창 출력
            Inputting.CallNumber(); // ID 입력
   
        }

        public void Login() // 로그인
        {

        }
    }
}
