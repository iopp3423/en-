using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    class Start
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;



            // Console 창에 보여질 커서의 x 좌표와 y 좌표

            int x = 40, y = 12;



            // 커서의 이동을 표현하는 것이 목적이므로 무한 루프를통해 커서표현을 반복

            for (; ; )

            {

                // 커서만 표시되는 것이 아니라 #도 같이 표시되므로 표시된 자국을 지우기 위한 역할

                Console.Clear();



                // x 와 y 좌표에 커서를 표시하기위한 메서드

                Console.SetCursorPosition(x, y);



                // 커서의 위치표시

                Console.Write('#');



                // 눌려진 키의 정보를 저장

                cki = Console.ReadKey(true);



                // 저장된 키의 정보에 대해 검색

                switch (cki.Key)

                {

                    // 좌

                    case ConsoleKey.LeftArrow:

                        {

                            x--;

                            break;

                        }



                    // 우

                    case ConsoleKey.RightArrow:

                        {

                            x++;

                            break;

                        }



                    // 상

                    case ConsoleKey.UpArrow:

                        {

                            y--;

                            break;

                        }



                    // 하

                    case ConsoleKey.DownArrow:

                        {

                            y++;

                            break;

                        }



                    // 종료

                    case ConsoleKey.Q:

                        {

                            return;

                        }

                }

            }
        }
    }

}