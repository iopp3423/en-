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

            test.storelog();
            //Start.StartMenu();





            //관리자 id = enen1234, pw = enen4321

            /*
            void LogWrite(string log)
            {
                string DirectotyPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Log";
                string FilePath = DirectotyPath + "\\Log_" + DateTime.Today.ToString("MMdd") + ".log";
                string temp;

                DirectoryInfo directory = new DirectoryInfo(DirectotyPath);
                FileInfo file = new FileInfo(FilePath);


                if (!directory.Exists) Directory.CreateDirectory(DirectotyPath);

                if (!file.Exists)
                {
                    using (StreamWriter writer = new StreamWriter(FilePath))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, log);
                        writer.WriteLine(temp);
                        writer.Close();
                    }
                }
                else
                {
                    using (StreamWriter writer = File.AppendText(FilePath))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, log);
                        writer.WriteLine(temp);
                        writer.Close();
                    }
                }

            }
            */
        }
    }
}
