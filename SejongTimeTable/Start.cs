using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using SejongTimeTable.Views;
using SejongTimeTable.Controls;

namespace SejongTimeTable//Example Example 왜 있지
{
    class Start
    {
        // 바탕화면에 excelStudy.xlsx 파일을 다운로드 받은 후 실행해보기!
        // C#에서 Excel을 사용하는 자세한 방법은 검색을 통해 스스로 공부해봅시다.
        static void Main(string[] args)
        {
            Console.SetWindowSize(Constants.CONSOLE_SIZE_WIDTH, Constants.CONSOLE_SIZE_HEIGHT); // 콘솔크기 지정
            Logging Login = new Logging();
           Print LoginView = new Print();
            LoginView.PrintLogin();
            Login.LoginId();



            /*
            try
            {
                // Excel Application 객체 생성
                Excel.Application application = new Excel.Application();

                // Workbook 객체 생성 및 파일 오픈 (바탕화면에 있는 excelStudy.xlsx 가져옴)
                Excel.Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\excelStudy.xlsx");

                // sheets에 읽어온 엑셀값을 넣기 (한 workbook 내의 모든 sheet 가져옴)
                Excel.Sheets sheets = workbook.Sheets;

                // 특정 sheet의 값 가져오기
                Excel.Worksheet worksheet = sheets["ensharp"] as Excel.Worksheet;

                // 범위 설정 (좌측 상단, 우측 하단)
                Excel.Range cellRange = worksheet.get_Range("A1", "C3") as Excel.Range;

                // 설정한 범위만큼 데이터 담기 (Value2 -셀의 기본 값 제공)
                Array data = cellRange.Cells.Value2;

                // 데이터 출력
                Console.WriteLine(data.GetValue(1, 1));
                Console.WriteLine(data.GetValue(1, 2));
                Console.WriteLine(data.GetValue(1, 3));
                Console.WriteLine(data.GetValue(2, 1));
                Console.WriteLine(data.GetValue(2, 2));
                Console.WriteLine(data.GetValue(2, 3));
                Console.WriteLine(data.GetValue(3, 1));
                Console.WriteLine(data.GetValue(3, 2));
                Console.WriteLine(data.GetValue(3, 3));

                // 모든 워크북 닫기
                application.Workbooks.Close();

                // application 종료
                application.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
            */
        }
    }
}
