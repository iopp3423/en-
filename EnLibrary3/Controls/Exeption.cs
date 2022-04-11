using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary3.Controls
{
    internal class Exeption
    {
        static int correctCount = 0;
        static private int initialization = 0;
        static private int passInt = 1;
        string[] CheckArray = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public int Checking(string CodeCheck)
        {
            foreach (string Number in CheckArray)
            {
                if (Number == CodeCheck) correctCount = passInt;
            }
            if (correctCount == passInt)
            {
                correctCount = initialization; // 정상
                return 1; // 1이면 정상
            }
            else return 0;// 0이면 오류검출
        }
    }
}
