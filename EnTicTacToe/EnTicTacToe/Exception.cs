﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    class Exception
    {

        VsUser Usercase = new VsUser();
        int ErrorCount;
        string[] CheckArray = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

        public bool Check(string CodeCheck)
        {
            ErrorCount = 0;
            foreach(var Number in CheckArray)
            {
                if (Number == CodeCheck) ErrorCount++;
            }
            if (ErrorCount == 1) return true;
            else return false;
        }
    }
}