using System;
using LibruryDatabase.Models;
using LibruryDatabase.Controls;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using LibruryDatabase.Utility;
using System.IO;


namespace LibruryDatabase
{
    internal class OpenLibrary
    {

        static void Main(string[] args)
        {
            StartConnection Start = new StartConnection();
            text2 test = new text2();
            //test test1 = new test();

            //test.storelog();
            //test.naver();
            //test1.naver();

            Start.StartMenu();
            //관리자 id = enen1234, pw = enen4321

           
        }
    }
}
