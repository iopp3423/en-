using System;
using LibruryDatabase.Models;
using LibruryDatabase.Controls;
using MySql.Data.MySqlClient;

namespace LibruryDatabase
{
    internal class Start
    {
        
        static void Main(string[] args)
        {
            StartConnection Start = new StartConnection();
            Start.StartMenu();
        }
    
    }
}
