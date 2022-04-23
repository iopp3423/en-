using System;
using LibruryDatabase.Models;
using LibruryDatabase.Controls;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using LibruryDatabase.Utility;
using LibruryDatabase.Exception;

namespace LibruryDatabase
{
    internal class Start
    {
        
        static void Main(string[] args)
        {
            StartConnection Start = new StartConnection();
            //Start.StartMenu();
            Console.Write(++Constants.BOOK_NUMBER);
            //관리자 id = enen1234, pw = enen4321
        }
    
    }
}
