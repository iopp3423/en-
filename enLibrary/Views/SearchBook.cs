using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    using EnLibrary.Controls;
    class SearchBook
    {
        BookVO Book = new BookVO();
        Input Inputting = new Input();
        Print PrintCollection = new Print();
        static private int input;

        public void Searching()
        {
            Console.Clear();           
            Book.StoreBookLIst();
            Book.Print();
            PrintCollection.PrintSearchMenu();
            input = Inputting.UserDoInput(); //사용자 입력
            switch(input)
            {
                case 0:
                    {
                        SearchingTitle();
                        break;
                    }
                case 1:
                    {
                        SearchingAuthor();
                        break;
                    }
                case 2:
                    {
                        SearchingPublisher();
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                    default: break;

            }
        }

        public void SearchingTitle()
        {
            PrintCollection.PrintSearchingTitle(); //책 제목 안내문구 출력
            Inputting.InputString();
            Book.Searching(); // 제목으로 검색
           
        }
        public void SearchingAuthor()
        {

            PrintCollection.PrintSearchingAuthor(); //작가 안내문구 출력
            Inputting.InputString();
            Book.SearchingAuthor(); // 작가로검색
           
        }
        public void SearchingPublisher()
        {
            PrintCollection.PrintSearchingPublisher(); //출판사 안내문구 출력
            Inputting.InputString();
            Book.SearchingPublisher();// 출판사로 검색
           
        }
    }
}
