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
        //BookMenu Menu = new BookMenu();
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
            BookMenu Menu = new BookMenu();
            PrintCollection.PrintSearchingTitle(); //책 제목 안내문구 출력
            Inputting.InputString();
            Book.Searching(); // 제목으로 검색
            Console.WriteLine("뒤로가기는 0번을 눌러주세요 :");
            Console.WriteLine("프로그램 종료는 1번을 눌러주세요 :");
            input = Inputting.UserDoInput();
            if (input == 0) Menu.SeeBookMenu();
        }
        public void SearchingAuthor()
        {
            BookMenu Menu = new BookMenu();
            PrintCollection.PrintSearchingAuthor(); //작가 안내문구 출력
            Inputting.InputString();
            Book.SearchingAuthor(); // 작가로검색
            Console.WriteLine("뒤로가기는 0번을 눌러주세요 :");
            Console.WriteLine("프로그램 종료는 1번을 눌러주세요 :");
            input = Inputting.UserDoInput();
            if (input == 0) Menu.SeeBookMenu();
        }
        public void SearchingPublisher()
        {
            BookMenu Menu = new BookMenu();
            PrintCollection.PrintSearchingPublisher(); //출판사 안내문구 출력
            Inputting.InputString();
            Book.SearchingPublisher();// 출판사로 검색
            Console.WriteLine("뒤로가기는 0번을 눌러주세요 :");
            Console.WriteLine("프로그램 종료는 1번을 눌러주세요 :");
            input = Inputting.UserDoInput();
            if (input == 0) Menu.SeeBookMenu();
        }
    }
}
