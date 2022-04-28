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


            
            string id = "iopp3423";

           
            
            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();

                //string DeleteQuer = "DELETE FROM book WHERE number = {0}";
               
                string borrowUserQuery = "SELECT * FROM BORROWMEMBER WHERE id = ('{0}')";
                //string borrowUserQuer = "SELECT * FROM BORROWMEMBER WHERE id = '" + id + " ';";

                MySqlCommand Command = new MySqlCommand(String.Format(borrowUserQuery, id), book);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    Console.Write("책 번호 :");
                    Console.WriteLine(bookData["number"].ToString());
                    Console.Write("책 제목 :");
                    Console.WriteLine(bookData["bookname"].ToString());
                    Console.Write("책 저자 :");
                    Console.WriteLine(bookData["author"].ToString());
                    Console.Write("출판사  :");
                    Console.WriteLine(bookData["publish"].ToString());
                    Console.Write("대여날짜:");
                    Console.WriteLine(bookData["borrowbook"].ToString());
                    Console.Write("반납날짜:");
                    Console.WriteLine(bookData["returnbook"].ToString());
                    Console.WriteLine("===============================================================");
                }
                bookData.Close();
            }
            
            
        }
    
    }
}
