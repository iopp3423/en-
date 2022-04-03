using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    class StartMenu
    {
        public void Menu()
        {
            int MenuNumber;

            Console.Write("      Tic Tac Toe 게임을 시작합니다!");
            Console.Write("\n\n");
            Console.Write(" ----------------메뉴-------------------");
            Console.Write("\n");
            Console.Write("l유저끼리 대결하시려면 1번을 눌러주세요l");
            Console.Write("\n");
            Console.Write("l컴퓨터와 대결하시려면 2번을 눌러주세요l");
            Console.Write("\n");
            Console.Write(" ---------------------------------------\n");
            Console.Write("모드 선택 : ");
            MenuNumber = int.Parse(Console.ReadLine()); // 모드 선택을 위한 메뉴넘버 입력
        }
    }
}