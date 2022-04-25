using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Exception;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;
using System.Runtime.InteropServices;

namespace LibruryDatabase.Controls
{
    // 이름,id 검색했을 때 없는 유저면 재 검색하라고 안내메시지 나와야함
    internal class ModificationAdmin
    {

        Screen Menu = new Screen();
        public void ModifyMember()
        {
            string name;
            string id;

            Console.Clear();
            Menu.PrintUserData(); //유저목록 출력
            Console.Write("이름을 입력하세요 :");
            name = InputName(); // 이름 입력
            Console.Clear();
            Menu.PrintSearchUser(name); // 이름맞는 사람 출력
            Console.Write("삭제하실 유저 id를 입력하세요 :");
            id = InputId();
            UserData.Get().RemoveUserInformation(id);
        }


        string InputName() // 이름입력
        {
            string name;

            while (Constants.LOGIN)
            {
                name = Console.ReadLine();
                Constants.ClearCurrentLine(Constants.CURRENT_LOCATION); // 
                if (Constants.CHECK == Regex.IsMatch(name, Utility.Exception.NAME_CHECK))
                {
                    Constants.ClearCurrentLine(Constants.BEFORE_INPUT_LOCATION);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    Console.Write("다시 입력해주세요 :"); continue;
                }
                break;
            }
            return name;
        }

        public string InputId() // id 입력
        {

            string id;

            while (Constants.LOGIN)
            {
                id = Console.ReadLine();
                Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);

                if (Constants.CHECK == Regex.IsMatch(id, Utility.Exception.ID_CHECK))
                {
                    Constants.ClearCurrentLine(Constants.BEFORE_INPUT_LOCATION);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    Console.Write("id를 다시 입력해주세요 :"); continue;
                }
                break;
            }
            return id;
        }
    }
}
