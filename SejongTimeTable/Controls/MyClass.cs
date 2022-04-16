using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SejongTimeTable.Views;
using SejongTimeTable.Models;

namespace SejongTimeTable.Controls
{
    internal class MyClass
    {
        Printing MenuView = new Printing();
        public ClassVO Application;

        public MyClass()
        {

        }
        public MyClass(ClassVO Application)
        {
            this.Application = Application; // 수강신청 과목 저장리스트
        }
        public void Menu()
        {
            Console.Clear();

            MenuView.PrintMySubject();

            foreach (ClassVO list in Application.Data)
            {
                Console.WriteLine(list);

            }
            /*
            while (true)
            {
                Console.SetCursorPosition(Constants.REMOVE_X, Constants.REMOVE_Y);
                Constants.cursur = Console.ReadKey(true);
                if (Constants.cursur.Key == ConsoleKey.F5) { ApplyMenu(); break; }// 뒤로가기               
                else continue;
            }
            */

        }
    }
}
