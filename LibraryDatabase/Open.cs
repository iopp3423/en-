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
            //Start.StartMenu();
            //관리자 id = enen1234, pw = enen4321



            string input = "";
            ConsoleKeyInfo info = Console.ReadKey();
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    input += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(input))
                    {
                        input = input.Substring(Constants.CURRENT_LOCATION, input.Length);
                        int passwordX = Console.CursorLeft;
                        Console.SetCursorPosition(passwordX , Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(passwordX, Console.CursorTop);
                    }
                }
                info = Console.ReadKey();
            }
            Console.WriteLine();
            Console.WriteLine(input);


        }       
    }
}