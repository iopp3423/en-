using System;
using LibruryDatabase.Models;
using LibruryDatabase.Controls;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using LibruryDatabase.Utility;

namespace LibruryDatabase
{
    internal class Start
    {
        
        static void Main(string[] args)
        {          
            StartConnection Start = new StartConnection();
            //Start.StartMenu();
            //관리자 id = enen1234, pw = enen4321





            string quantity;

        
            Console.Write("수정할 수량을 입력해주세요(숫자만) :");
            while (Constants.PASS)
            {
                quantity = Console.ReadLine();
             
                if (Constants.CHECK == Regex.IsMatch(quantity, Utility.Exception.QUANTITY))
                {
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }


            string bookPrice;

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
            Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("수정할 가격을 입력해주세요(숫자만) :");

            while (Constants.PASS)
            {
                bookPrice = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                if (Constants.CHECK == Regex.IsMatch(bookPrice, Utility.Exception.PRICE))

                {
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
        }
    
    }
}
