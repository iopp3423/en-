using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejongTimeTable.Models
{
    internal class ClassVO
    {
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

        
    }
}
