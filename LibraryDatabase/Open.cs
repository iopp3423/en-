using System;
using LibruryDatabase.Models;
using LibruryDatabase.Controls;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using LibruryDatabase.Utility;
using System.IO;


namespace LibruryDatabase
{
    internal class Open
    {

        static void Main(string[] args)
        {
            ChoiceUserOrAdmin Start = new ChoiceUserOrAdmin();
            Start.StartMenu();
            //관리자 id = enen1234, pw = enen4321

            //test a = new test();
            //a.Print();
            /*
            string passwordChangeStar = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (Constants.isPassing != Regex.IsMatch(info.KeyChar.ToString(), Utility.Exception.INPUT))
                { 
                    Console.Write(info.KeyChar.ToString());               
                    passwordChangeStar += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(passwordChangeStar))
                    {
                        passwordChangeStar = passwordChangeStar.Substring(Constants.CURRENT_LOCATION, passwordChangeStar.Length - Constants.ONE);
                        int passwordX = Console.CursorLeft;
                        Console.SetCursorPosition(passwordX - Constants.ONE, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(passwordX - Constants.ONE, Console.CursorTop);
                    }
                }
                else if(info.Key == ConsoleKey.F5)
                {
                    Console.Write("됐다.");
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            */
        }       
    }
}