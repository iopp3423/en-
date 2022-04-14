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
        List<ClassVO> Data = new List<ClassVO>();
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

                for (row = Constants.ROW_START; row < Constants.ROW_END; row++) // 리스트에 엑셀 파일 저장
                {
                    Constants.COL_START = Constants.ZERO;
                    for (col = Constants.COL_START; col < Constants.COL_END; col++)
                    {
                        switch (col)
                        {
                            case 1:
                                if (data.GetValue(row, col) == null)
                                { number = null; break; }
                                number = data.GetValue(row, col).ToString() + " ";
                                break;

                            case 2:
                                if (data.GetValue(row, col) == null)
                                { mager = null; break; }
                                mager = data.GetValue(row, col).ToString() + " ";
                                break;

                            case 3:
                                if (data.GetValue(row, col) == null)
                                { classNumber = null; break; }
                                classNumber = data.GetValue(row, col).ToString();
                                break;

                            case 4:
                                if (data.GetValue(row, col) == null) { group = null; break; }
                                group = data.GetValue(row, col).ToString();
                                break;

                            case 5:
                                if (data.GetValue(row, col) == null) { classname = null; break; }
                                classname = data.GetValue(row, col).ToString();
                                break;

                            case 6:
                                if (data.GetValue(row, col) == null) {seperation = null; break; }
                                seperation = data.GetValue(row, col).ToString();
                                break;

                            case 7:
                                if (data.GetValue(row, col) == null) { grade = null; break;}
                                grade = data.GetValue(row, col).ToString();
                                break;

                            case 8:
                                if (data.GetValue(row, col) == null) { score = null; break;}
                                score = data.GetValue(row, col).ToString();
                                break;

                            case 9:
                                if (data.GetValue(row, col) == null) { day = null; break;}
                                day = data.GetValue(row, col).ToString();
                                break;

                            case 10:
                                if (data.GetValue(row, col) == null) { room = null; break;}
                                room = data.GetValue(row, col).ToString();
                                break;

                            case 11:
                                if (data.GetValue(row, col) == null) { professor = null; break;}
                                professor = data.GetValue(row, col).ToString();
                                break;

                            case 12:
                                if (data.GetValue(row, col) == null) { language = null; break;}
                                language = data.GetValue(row, col).ToString();
                                break;

                         default: break;
                        }


                    }
                    Data.Add(new ClassVO(number, mager, classNumber, group, classname, seperation, grade, score, day, room, professor, language));
        
                }


                //Console.WriteLine(AllPrint[0]);

                foreach (ClassVO s in Data)
                {
                    
                     Console.WriteLine(s);
                    
                }


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
            
    
    }
}