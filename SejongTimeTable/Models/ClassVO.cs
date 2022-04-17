using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace SejongTimeTable.Models
{

    public class ClassVO
    {
        public List<ClassVO> Data = new List<ClassVO>();

        public string number;
        public string mager;
        public string classNumber;
        public string group;
        public string classname;
        public string seperation;
        public string grade;
        public string score;
        public string day;
        public string room;
        public string professor;
        public string language;

        public ClassVO()
        {
           //생성자
        }

        public ClassVO(string number, string mager, string classNumber,string group, string classname, string seperation, string grade, string score, string day, string room, string professor, string language)
        {
            this.number = number;
            this.mager = mager;
            this.classNumber = classNumber;
            this.group = group;
            this.classname = classname;
            this.seperation = seperation;
            this.grade = grade;
            this.score = score;
            this.day = day;
            this.room = room;
            this.professor = professor;
            this.language = language;
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Mager
        {
            get { return mager; }
            set { mager = value; }
        }
        public string ClassNumber
        {
            get { return classNumber; }
            set { classNumber = value; }
        }
        public string Group
        {
            get { return group; }
            set { group = value; }
        }
        public string Classname
        {
            get { return classname; }
            set { classname = value; }
        }
        public string Seperation
        {
            get { return seperation; }
            set { seperation = value; }
        }
        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        public string Score
        {
            get { return score; }
            set { score = value; }
        }

        public string Day
        {
            get { return day; }
            set { day = value; }
        }
        public string Room
        {
            get { return room; }
            set { room = value; }
        }
        public string Professor
        {
            get { return professor; }
            set { professor = value; }
        }
        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        public override string ToString()
        {
            return number  + "    " + mager  + "    " + classNumber   + "      " + group  + "    " + classname + "       " + seperation  + "     " + grade  + "      " + score + "        " + day + "     " + room  + "      " + professor  + "      " +language;
        }

       
        public void ClassList()
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
                                number = data.GetValue(row, col).ToString();
                                break;

                            case 2:
                                if (data.GetValue(row, col) == null)
                                { mager = null; break; }
                                mager = data.GetValue(row, col).ToString();
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
                                if (data.GetValue(row, col) == null) { seperation = null; break; }
                                seperation = data.GetValue(row, col).ToString();
                                break;

                            case 7:
                                if (data.GetValue(row, col) == null) { grade = null; break; }
                                grade = data.GetValue(row, col).ToString();
                                break;

                            case 8:
                                if (data.GetValue(row, col) == null) { score = null; break; }
                                score = data.GetValue(row, col).ToString();
                                break;

                            case 9:
                                if (data.GetValue(row, col) == null) { day = null; break; }
                                day = data.GetValue(row, col).ToString();
                                break;

                            case 10:
                                if (data.GetValue(row, col) == null) { room = null; break; }
                                room = data.GetValue(row, col).ToString();
                                break;

                            case 11:
                                if (data.GetValue(row, col) == null) { professor = null; break; }
                                professor = data.GetValue(row, col).ToString();
                                break;

                            case 12:
                                if (data.GetValue(row, col) == null) { language = null; break; }
                                language = data.GetValue(row, col).ToString();
                                break;

                            default: break;
                        }


                    }
                    Data.Add(new ClassVO(number, mager, classNumber, group, classname, seperation, grade, score, day, room, professor, language));

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
