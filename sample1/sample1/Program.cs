using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample1
{
    class StarProgram
    {
        //삼각형
        public void Triangle(int cnt)
        {
            int i, j, k;
          
            for (i = 1; i <= cnt; i++)
            {
                // 띄어쓰기
                for (j = 0; j < cnt - i; j++)
                {
                    Console.Write(" ");
                }

                // 별 개수
                for (k = 0; k < i * 2 - 1; k++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }
        //역 삼각형
        public void ReverseTriangle(int cnt)
        {
            int i, j, k, L = 0;
   
            for (i = cnt; i > 0; i--, L++)
            {
                //띄어쓰기 
                for (k = 0; k < L; k++)
                {
                    Console.Write(" ");
                }

                //별 개수
                for (j = i * 2 - 1; j > 0; j--)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }

        //모래시계
        public void SandClock(int cnt)
        {
            int i, j, k, L = 0;


            for (i = cnt; i > 0; i--, L++)
            {
                //띄어쓰기 
                for (k = 0; k < L; k++)
                {
                    Console.Write(" ");
                }

                //별 개수
                for (j = i * 2 - 1; j > 0; j--)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            for (i = 1; i <= cnt; i++)
            {
                // 띄어쓰기
                for (j = 0; j < cnt - i; j++)
                {
                    Console.Write(" ");
                }

                // 별 개수
                for (k = 0; k < i * 2 - 1; k++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }

        }
        //다이아
        public void DiaTriangle(int cnt)
        {
            int i, j, k, L = 0; 

            for (i = 1; i <= cnt; i++)
            {
                // 띄어쓰기
                for (j = 0; j < cnt - i; j++)
                {
                    Console.Write(" ");
                }

                // 별 개수
                for (k = 0; k < i * 2 - 1; k++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }

            for (i = cnt-1; i > 0; i--, L++)
            {
                //띄어쓰기 
                for (k = 0; k <= L; k++)
                {
                    Console.Write(" ");
                }

                //별 개수
                for (j = i * 2 - 1; j > 0; j--)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }
        public void StartGame()
        {
            int i = 1;
            int cnt;

            Console.Write("줄 수 입력 : ");
            cnt = int.Parse(Console.ReadLine());

            while (i != 0)
            {
                StarProgram Star = new StarProgram();

                i = int.Parse(Console.ReadLine());
                if (i == 1) Star.Triangle(cnt);
                else if (i == 2) Star.ReverseTriangle(cnt);
                else if (i == 3) Star.SandClock(cnt);
                else if (i == 4) Star.DiaTriangle(cnt);

                else break;
            }
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            StarProgram Star = new StarProgram();
            Star.StartGame();
        }
    }
}
