using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    internal class BookMenu
    {
        Print PrintCollection = new Print();
        Input Inputting = new Input();
        private int choose;
        public void SeeBookMenu()
        {
            PrintCollection.PrintLoginAfter(); // 도서 메뉴 출력
            choose = Inputting.UserDoInput();
            switch(choose)
            {
                case 0: SearchBook(); break;
                case 1: BorrowBook(); break;
                case 2: CheckBook(); break;
                case 3: ReviseUserInformation(); break;
                default: break;
            }
        }

        public void SearchBook()
        {

        }

        public void BorrowBook()
        {

        }

        public void CheckBook()
        {

        }
        public void ReviseUserInformation()
        {

        }
    }
}
