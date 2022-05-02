using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibruryDatabase.Views
{
    internal class MessageScreen
    {
        public string PrintAlreadyId()
        {
            return "이미 존재하는 ID 입니다. 재입력 : Enter, 뒤로가기 : ESC 두 번";
        }
        public string PrintAlreadyPassword()
        {
            return "비밀번호가 일치하지않습니다. 재입력 : Enter, 뒤로가기 : ESC 두 번";
        }
        public string PrintDoneRegister()
        {
            return "회원가입이 완료되었습니다. Enter : 로그인 이동, 뒤로가기 : ESC 두 번";
        }
        public string PrintErrorUserInformation()
        {
            return "회원정보가 일치하지 않습니다. 재입력 : Enter, 뒤로가기 : ESC 두 번";
        }
        public void PrintIdInputMessage()
        {
            Console.Write("ID(영어, 숫자 포함(8~10자) :");
        }
        public void PrintPasswordInputMessage()
        {
            Console.Write("PW(영어, 숫자 포함(4~10자) :");
        }
        public void PrintPasswordCheckMessage()
        {
            Console.WriteLine("PW확인(영어, 숫자 포함(4~10자) :");
        }
        public void PrintInputNameMessage()
        {
            Console.WriteLine("유저 이름(2~5자) :");
        }
        public void PrintInutCallNumberMessage()
        {
            Console.WriteLine("핸드폰 번호(01x-xxxx-xxxx) :");
        }
        public void PrintInputAddressMessage()
        {
            Console.WriteLine("주소 :");
        }
        public void PrintInputAgeMessage()
        {
            Console.WriteLine("나이 :");
        }
        public string PrintBorrowBookMessage()
        {
            return "대여 : Enter                                  뒤로가기 : ESC"; 
        }
        public void PrintBorrowBookNumberMessage()
        {
            Console.Write("  대여하실 책 번호 :");
        }
        public string PrintNoneBook()
        {
            return "존재하지 않는 책입니다. 뒤로가기 : ESC      프로그램 종료 : F5"; 
        }
        public string PrintNoneQuantity()
        {
            return "도서 수량이 부족합니다. 뒤로가기 : ESC       프로그램 종료 : F5";
        }
        public string PrintAlreadyBorrowMessage()
        {
            return "이미 대여하셨습니다. 뒤로가기 : ESC, 프로그램 종료 : F5 ";
        }
        public string PrintDoneBorrowMessage()
        {
            return "대여하였습니다. 뒤로가기 : ESC     프로그램 종료 : F5";
        }
        public string PrintReviseInformation()
        {
            return "정보가 변경되었습니다. 뒤로가기 : ESC, 프로그램 종료 : F5";
        }
        public void PrintReEnterMessage()
        {
            Console.Write("다시 입력해주세요 :");
        }
        public string PrintReturnBookMessage()
        {
            return "반납 : Enter                                  뒤로가기 : ESC";
        }
        public string PrintNoBorrowBookMessage()
        {
            return "대여하지 않은 도서입니다. 뒤로가기 : ESC, 프로그램 종료 : F5 ";
        }
        public string PrintAlreadyReturn()
        {
            return "이미 반납하셨습니다. 뒤로가기 : ESC, 프로그램 종료 : F5 ";
        }
        public string PrintReturnBook()
        {
            return "도서를 반납하였습니다. 뒤로가기 : ESC, 프로그램 종료 : F5";
        }
        public void PrintInputReturnBookNumber()
        {
            Console.Write("반납할 책 번호를 입력해주세요 : ");
        }

        public void GreenColor(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ResetColor();
        }
        public void RedColor(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
