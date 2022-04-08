using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    class SelectMode
    {
        UserMode User = new UserMode();
        ManageMode Manage = new ManageMode();
        Print PrintCollection = new Print();
        Input Inputting = new Input();
        int inputData; // 사용자 오류 검출 후 입력된 값
        public void Print()
        {
            PrintCollection.LibraryPrint();
            PrintCollection.MenuPrint();
            InputData();
        }

        public void InputData()
        {
            inputData = Inputting.UserDoInput();

            switch(inputData)
            {
                case 0: User.Mode(); break;
                case 1: Manage.Mode(); break;
                case 2: Console.Write("도서관리 프로그램이 종료되었습니다."); break;
            }
        }
      
       
    }
}
