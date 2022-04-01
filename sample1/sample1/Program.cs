using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample1
{
    class StarProgram
    {
        public void Triangle(int cnt)
        {
            int i, j, k, L = 0;

            ///////////////////삼각형
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
        public void Reverse_Triangle(int cnt)
        {
            int i, j, k, L = 0;
            //////////////////////역 삼각형
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
        public void Sand_Clock(int cnt)
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
    }
    class program
    {
        static void Main(string[] args)
        {
            int cnt;
            int i=0;
            Console.Write("별의 개수를 찍으세요 : ");
            cnt = int.Parse(Console.ReadLine());

            StarProgram Star = new StarProgram();

            while (i != 4)
            {
                i = int.Parse(Console.ReadLine());
                if(i == 1)Star.Triangle(cnt);
                else if(i == 2)Star.Reverse_Triangle(cnt);
                else if (i == 3)Star.Sand_Clock(cnt);
            }

            ///////////////////삼각형
            ///
            /*
            for(i=1;i<=cnt;i++)
            {
                // 띄어쓰기
                for(j=0;j<cnt-i;j++)
                {
                    Console.Write(" ");
                }

                // 별 개수
                for(k=0;k<i*2-1;k++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }

            //////////////////////역 삼각형
            for(i=cnt; i>0; i--, L++)
            {
                //띄어쓰기 
                for (k = 0; k < L; k++)
                {
                    Console.Write(" ");
                }

                //별 개수
                for (j=i*2-1;j>0;j--)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            */
            
            /*  모래시계
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
            */


        }
    }
}
