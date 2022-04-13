using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using SejongTimeTable.Views;
using SejongTimeTable.Controls;

namespace SejongTimeTable.Models
{
    class ClassList
    {
        public List<ClassVO> AllPrint = new List<ClassVO>();
        // 바탕화면에 excelStudy.xlsx 파일을 다운로드 받은 후 실행해보기!
        // C#에서 Excel을 사용하는 자세한 방법은 검색을 통해 스스로 공부해봅시다.
        private string number;
        private string mager;
        private string classNumber;
        private string group;
        private string classname;
        private string seperation;
        private string grade;
        private string score;
        private string day;
        private string room;
        private string professor;
        private string language;
        public void Table()
        {
            int row, col;

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
                Excel.Range cellRange = worksheet.get_Range("A1", "L185") as Excel.Range;

                // 설정한 범위만큼 데이터 담기 (Value2 -셀의 기본 값 제공)
                Array data = cellRange.Cells.Value2;

                // 데이터 출력
                /*
                Console.WriteLine(data.GetValue(1, 1));
                Console.WriteLine(data.GetValue(1, 2));
                Console.WriteLine(data.GetValue(1, 3));
                Console.WriteLine(data.GetValue(2, 1));
                Console.WriteLine(data.GetValue(2, 2));
                Console.WriteLine(data.GetValue(2, 3));
                Console.WriteLine(data.GetValue(3, 1));
                Console.WriteLine(data.GetValue(3, 2));
                Console.WriteLine(data.GetValue(3, 3));
                */

                for (row = 1; row <= 184; row++)
                {

                    number = (string)data.GetValue(row, 1);
                    mager = (string)data.GetValue(row, 2);
                    classNumber = (string)data.GetValue(row, 3);
                    group = (string)data.GetValue(row, 4);
                    classname = (string)data.GetValue(row, 5);
                    seperation = (string)data.GetValue(row, 6);
                    grade = (string)data.GetValue(row, 7);
                    score = (string)data.GetValue(row, 8);
                    day = (string)data.GetValue(row, 9);
                    room = (string)data.GetValue(row, 10);
                    professor = (string)data.GetValue(row, 11);
                    language = (string)data.GetValue(row, 12);

                    AllPrint.Add(new ClassVO(number, mager, classNumber, group, classname, seperation, grade, score, day, room, professor, language));
                }

                Console.WriteLine(AllPrint[0]);

                // 모든 워크북 닫기
                application.Workbooks.Close();

                // application 종료
                application.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }
            public override string ToString()
        {
            return "번호 : " + number + "개설학과 : " + mager + "학수번호 : " + classNumber + "교과목명 : " + classNumber + "이수구분   : " + group + "학년   : " + seperation + "학점   : " + grade + "요일   : " + score + "강의실   : " + day + "교수님   : " + room + "학년   : " + professor + "언어   : " + language;
        }
    
    }
}