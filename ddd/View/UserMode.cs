using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.View
{
    using Controls;
    class UserSign
    {
        int mode;
        int userMode = 1;
        int managerMode = 2;
        UserDataVo UserData = new UserDataVo();
        Print AllPrint = new Print();

        public void SelectMenu() 
        {
            AllPrint.PrintLoginOrJoin(); // 유저모드 or 관리자 모드 선택
            mode = int.Parse(Console.ReadLine());
            if (mode == userMode) EnterUser(); // 유저모드
            else if (mode == managerMode) EnterManager(); //관리자모드
        }

        public void EnterUser() // 유저모드
        {
            AllPrint.PrintTitle(); // 맨 위 타이틀
            AllPrint.PrintMenu(); // 회원가입, 로그인
        }
        public void EnterManager() // 관리자모드
        {

        }

        public void Login()
        {

        }


    }
}
