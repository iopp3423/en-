using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Utility;
using LibruryDatabase.Models;

namespace LibruryDatabase
{
    internal class test
    {
        private memberDAO memberDao;
        private memberDTO memverDto;

        public test()
        {
           memberDao = new memberDAO();
        }

        public void login()
        {
            string id;
            string pw;
            memberDao.connection();

            id = Console.ReadLine();
            pw = Console.ReadLine();

            memberDTO dto = new memberDTO();

            dto.Id=id;
            dto.Password = pw;

            Console.WriteLine(dto.Id);
            Console.WriteLine(dto.Password);

            Console.WriteLine(memberDao.Login(id, pw));
        }      

       
    }

    
    
}
