namespace EnLibraury2.Views
{

    class Input
    {
        Exeption ErrorCheck = new Exeption();
        Print PrintCollection = new Print();
        UserVO Information = new UserVO();
        Regex IdCheck = new Regex(@"^[0-9a-zA-Z]{8,10}$");
        Regex CallNumberCheck = new Regex(@"^01[0-9]-[0-9]{4}-[0-9]{4}$");
        Regex PwCheck = new Regex(@"^[0-9a-zA-Z]{4,10}$");
        Regex NameCheck = new Regex(@"^[가-힣]{2,5}$");
        Regex AgeCheck = new Regex(@"^[0-9]{1,2}1?[0-9]?[0-9]$");


        string inputSearch; // 오류 검출을 위한 입력 값
        int input;
        static private int noError = 1;
        static private int error;
        static private bool pass = false;
        static private bool reEnter = true;
        static private bool completeInformation;
        static public string idConfirm;
        static public string pwConfirm;
        static private string id;
        static private string pw;
        static private string pwPass;
        static private string name;
        static private string callNumber;
        static private string age;
        static private string address;
        static public string searchingBook;

        public int UserDoInput() // 1~9 에러 검출코드
        {
            inputSearch = Console.ReadLine();
            error = ErrorCheck.Checking(inputSearch); //error가 1이면 정상
            if (error == noError) input = int.Parse(inputSearch);
            else
            {
                while (error != 1)
                {

                    Console.Write("다시 입력해주세요: ");
                    inputSearch = Console.ReadLine();
                    error = ErrorCheck.Checking(inputSearch); // 에러가 1이될 때까지 재입력
                }
                input = int.Parse(inputSearch); // 에러가 1이면 반복문 탈출 후 정수 값 대입
            }
            return input; // 정수 값 리턴
        }
    }
}
