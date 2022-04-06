using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    class Exeption
    {
        static int correctCount = 0;
        string[] CheckArray = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };


        public int Checking(string CodeCheck)
        {
            foreach (string Number in CheckArray)
            {
                if (Number == CodeCheck) correctCount=1;
            }
            if (correctCount == 1)
            {
                correctCount = 0;
                return 1; // 1이면 정상
            }
            else return 0;// 0이면 오류검출
        }
    }
    
}
