namespace EnLibrary3.Controls
{
    using EnLibrary3.Views;
    using EnLibrary3.Models;
    internal class BookCheck
    {
        Print View = new Print();
        bool isFinished = true;
        ConsoleKeyInfo cursur;
        public void CheckBook()
        {
            Console.Clear();
            int x = 0, y = 0;
            //Console.WriteLine();
            View.PrintBookList();
            Check();
            
        }





        public void Check()
        {
            LoginAfter Menu = new LoginAfter();
            Console.Write("구현을 못해서 Enter누르면 메뉴로 돌아갑니다..");
            cursur = Console.ReadKey(true);
            if (cursur.Key == ConsoleKey.Enter) { Console.Clear(); Menu.BookMenu(); }
            else if (cursur.Key == ConsoleKey.Escape) return;
        }
    }
}
