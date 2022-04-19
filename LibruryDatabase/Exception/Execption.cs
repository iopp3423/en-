using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibruryDatabase.Exception
{
    internal class Execption
    {
        public const string ID_CHECK = @"^[0-9a-zA-Z]{8,10}$";
        public const string NUMBER_CHECK = @"^01[0-9]-[0-9]{4}-[0-9]{4}$";
        public const string PW_CHECK = @"^[0-9a-zA-Z]{4,10}$";
        public const string NAME_CHECK = @"^[가-힣]{2,5}$";
        public const string AGE_CHECK = @"^[0-9]{1,2}1?[0-9]?[0-9]$";
        public const string ADDRESS_CHECK = @"^(([가-힣]+(d|d(,|.)d|)+(읍|면|동|가|리))(^구|)((d(~|-)d|d)(가|리|)|))([ ](산(d(~|-)d|d))|)|(([가-힣]|(d(~|-)d)|d)+(로|길))$";
    }
}
