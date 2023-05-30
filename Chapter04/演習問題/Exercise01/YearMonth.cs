using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public class YearMonth {
#if true
        #region 自力
        //年
        public int Year { get; private set; }
        //月
        public int Month { get; private set; }

        //コンストラクタ
        public YearMonth( int year , int month ) {
            Year = year;
            Month = month;
        }

        //メソッド
        
        #endregion
#else
        #region 模範解答
        
        #endregion
#endif
    }
}
