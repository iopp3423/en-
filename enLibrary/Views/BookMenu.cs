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
        SearchBook Search = new SearchBook();
        BorrowBook Borrow = new BorrowBook();
        CheckBook CheckBook = new CheckBook();
        ReviseUserInformation Revise = new ReviseUserInformation();

        private int choose;
        public void SeeBookMenu()
        {
            PrintCollection.PrintLoginAfter(); // 도서 메뉴 출력
            choose = Inputting.UserDoInput();

            switch (choose)
            {
                case 0:
                    {
                        Search.Searching();
                        break;
                    }
                case 1:
                    {
                        Borrow.Borrowing();
                        break;
                    }

                case 2:
                    {
                        CheckBook.Checking();
                        break;
                    }
                case 3:
                    {
                        Revise.Revising();
                        break;
                    }
                case 4: break;

                default: break;
            }
        }


    }


}

