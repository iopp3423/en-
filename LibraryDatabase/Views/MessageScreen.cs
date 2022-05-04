using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibruryDatabase.Views
{
    internal class MessageScreen
    {
        //유저 관련 
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
            Console.Write("핸드폰 번호(01x-xxxx-xxxx) :");
        }
        public void PrintInputAddressMessage()
        {
            Console.Write("주소 :");
        }
        public void PrintInputAgeMessage()
        {
            Console.WriteLine("나이 :");
        }
        public void PrintAuthorInput()
        {
            Console.Write("입력 (영어,한글 2~8자) :");
        }
        public void PrintpublishInput()
        {
            Console.Write("입력 (한글 2~8자) :");
        }
        public void PrintBookTitle()
        {
            Console.Write("책 제목 (한글, 영어 2~10자) :");
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
            return "존재하지 않는 책입니다. 뒤로가기 : ESC"; 
        }
        public string PrintNoneQuantity()
        {
            return "도서 수량이 부족합니다. 뒤로가기 : ESC";
        }
        public string PrintAlreadyBorrowMessage()
        {
            return "이미 대여하셨습니다. 뒤로가기 : ESC";
        }
        public string PrintDoneBorrowMessage()
        {
            return "뒤로가기 : ESC";
        }
        public string PrintReviseInformation()
        {
            return "정보가 변경되었습니다. 뒤로가기 : ESC";
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
            return "대여하지 않은 도서입니다. 뒤로가기 : ESC";
        }
        public string PrintAlreadyReturn()
        {
            return "이미 반납하셨습니다. 뒤로가기 : ESC";
        }
        public string PrintReturnBook()
        {
            return "도서를 반납하였습니다. 뒤로가기 : ESC";
        }
        public void PrintInputReturnBookNumber()
        {
            Console.Write("반납할 책 번호를 입력해주세요 : ");
        }
        public string PrintNoBookMessage()
        {
            return "찾으시는 책이 없습니다. 뒤로가기 ESC";
        }
        public void PrintBack()
        {
            Console.Write("뒤로가기 : ESC");
        }
        public string PrintChooseRemoveUserMessage()
        {
            return "회원삭제 : Enter                                          뒤로가기 : ESC";
        }
        public string PrintNoneUserMessage()
        {
            return "회원목록에 없습니다.              뒤로가기 : ESC";
        }
        public void PrintRemoveUserInputMessage()
        {
            Console.Write("삭제하실 유저 id를 입력하세요 :");
        }
        public string PrintNoneuser()
        {
            return "회원목록에 없습니다.             뒤로가기 : ES";
        }
        public string PrintNoneReturnBookMessage()
        {
            return "반납하지 않은 도서가 있습니다.   뒤로가기 : ESC";
        }
        public string PrintRemoveUserMessage()
        {
            return "삭제되었습니다.                      뒤로가기 : ESC";
        }
        public void PrintAddisbn()
        {
            Console.Write("추가하실 도서의 isbn을 입력해주세요 : ");
        }
        public void PrintNoneIsbnMessage()
        {
            Console.Write("맞는 isbn이 없습니다. 뒤로가기 : ESC");
        }










        //관리자 관련
        public string PrintBackOrExit()
        {
            return "뒤로가기 : ESC";
        }
        public string PrintInputOrBackMessage()
        {
            return "책 정보 입력 : Enter                                      뒤로가기 : ESC";
        }
        public string PrintDoneBookRegister()
        {
            return "도서가 등록되었습니다. 뒤로가기 : ESC";
        }
        public void PrintAuthorInputMessage()
        {
            Console.WriteLine("작가(영어, 한글 2~8자) :");
        }
        public void PrintPublisherInputMessage()
        {
            Console.WriteLine("출판사(영어 한글 2~8자):");
        }
        public void PrintPublishDayInput()
        {
            Console.WriteLine("출시일(YYYY/MM/DD) :");
        }
        public void PrintQuantityInputMessage()
        {
            Console.WriteLine("수량(1~3자리 숫자):");
        }
        public void PrintPriceInputMessage()
        {
            Console.WriteLine("가격 :");
        }
        public string PrintReviseBookInput()
        {
            return "책 수정 : Enter                                          뒤로가기 : ESC";
        }
        public string PrintReviseAfterMessage()
        {
            return "수정이 완료되었습니다.  뒤로가기 : ESC";
        }
        public void PrintChooseReviseInput()
        {
            Console.Write("책 수량 수정 1번, 책 가격 수정 2번 입력:");
        }
        public void PrintInputQuantity()
        {
            Console.Write("수정할 수량을 입력해주세요(숫자만) :");
        }
        public void PrintInputPrice()
        {
            Console.Write("수정할 가격을 입력해주세요(1000~, 숫자만) :");
        }
        public void PrintInputBookNumber()
        {
            Console.Write("책 번호를 입력해주세요 :");
        }
        public void PrintInputBookName()
        {
            Console.Write("  입력 (영어,한글 2~8자) :");
        }
        public string PrintErrorInputMessage()
        {
            return "잘못입력하셨습니다.  재입력 : Enter";
        }
        public void PrintBookQunatityInput()
        {
            Console.Write("  출력할 도서 수 입력    :");
        }
        public string PrintNoneInput()
        {
            return "누락된 입력이있습니다.  재입력 : Enter";
        }
        public string PrintChooseRemoveBook()
        {
            return "책 제거 : Enter                                         뒤로가기 : ESC";
        }
        public string PrintRemoveBookMessage()
        {
            return "책이 삭제되었습니다.  뒤로가기 : ESC";
        }
        public void PrintRemoveBookNumberMessage()
        {
            Console.Write("삭제할 책 번호 :");
        }
        public void PrintReInputTitleMessage()
        {
            Console.Write("다시 입력해주세요(영어 한글제한없음) :");
        }
        public string PrintDoneInput()
        {
            return "입력되었습니다.         뒤로가기 : ESC";
        }
        public string BackPrint()
        {
            return "        뒤로가기 : ESC";
        }
        public string PrintContinueRequestmessage()
        {
            return "입력 : Enter                뒤로가기 : ESC";
        }
        public void PrintIsbnMessage()
        {
            Console.WriteLine("ISBN :");
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
