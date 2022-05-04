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
            ChoiceUserOrAdmin Start = new ChoiceUserOrAdmin();
            Start.StartMenu();
            //관리자 id = enen1234, pw = enen4321         
        }
    }
}
