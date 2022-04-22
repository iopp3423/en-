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
            string Id = "iopp3423";
            string Pw = "cho3135";

            UserData Data = new UserData();
            
            StartConnection Start = new StartConnection();
            Start.StartMenu();

            
            
            
            
        }
        
        
    }
}
