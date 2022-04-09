using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    using EnLibrary.Controls;
    internal class ReviseUserInformation
    {
        int inputData;
        Print PrintCollection = new Print();
        UserVO Information = new UserVO();
        Input Inputting = new Input();

        public void Revising()
        {
            Console.Clear();
            Information.Print();
            Console.WriteLine("────────────────────────────────────────────────────────────");
            Console.Write("\n\n");
            PrintCollection.RevisingInformation();
            inputData = Inputting.UserDoInput(); //사용자 입력
            switch (inputData)
            {
                case 1: { RevisingCall(); break; }
                case 2: { RevisingPw(); break; }
                case 3: { RevisingAge(); break; }
                default: break;
            }
        }

        public void RevisingCall()
        {
            Inputting.CallNumber();
            Information.RevisingCallNumber();
            Information.Print();
        }
        public void RevisingPw()
        {
            Inputting.Pw();
            Information.RevisingPw();
            Information.Print();
            
        }
        public void RevisingAge()
        {
            Inputting.Age();
            Information.RevisingAge();
            Information.Print();

        }
    }
}
