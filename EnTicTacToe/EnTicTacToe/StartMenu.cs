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
            VsUser UserCase = new VsUser();
            VsComputer ComputerCase = new VsComputer();
            int MenuNumber;

            Console.Write("      Tic Tac Toe 게임을 시작합니다!\n\n");
            Console.Write(" ----------------메뉴-------------------\n");
            Console.Write("l유저끼리 대결하시려면 1번을 눌러주세요l\n");
            Console.Write("l컴퓨터와 대결하시려면 2번을 눌러주세요l\n");
            Console.Write(" ---------------------------------------\n");
            Console.Write("모드 선택 : ");

            MenuNumber = int.Parse(Console.ReadLine()); // 모드 선택을 위한 메뉴넘버 입력
            while (MenuNumber<0 || MenuNumber>2) // 0에서 2사이의 값이 아니면 다시 입력
            {
                Console.Clear();
                switch (MenuNumber)
                {
                    case 0: break; // 0 입력받으면 종료
                    case 1: UserCase.User(); break; // 1 입력받으면 VS유저
                    case 2: ComputerCase.Computer(); break; // 2 입력받으면 VS컴퓨터
                    default:
                        { 
                            Console.Write("      Tic Tac Toe 게임을 시작합니다!\n\n");
                            Console.Write(" ----------------메뉴-------------------\n");
                            Console.Write("l유저끼리 대결하시려면 1번을 눌러주세요l\n");
                            Console.Write("l컴퓨터와 대결하시려면 2번을 눌러주세요l\n");
                            Console.Write(" ---------------------------------------\n");
                            Console.Write("잘못 입력하셨습니다. 다시 모드를 선택해주세요.\n");
                            Console.Write("모드 선택 : ");
                            MenuNumber = int.Parse(Console.ReadLine()); // 모드 선택을 위한 메뉴넘버 입력
                            break;
                        }
                }
            }
        }
    }
}