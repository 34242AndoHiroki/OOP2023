using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public class YearMonth {
#if !true
        #region 自力
        //年
        public int Year { get; private set; }
        //月
        public int Month { get; private set; }
        //21世紀の判定
        public bool Is21Century => 2001 <= Year && Year <= 2100;

        //コンストラクタ
        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }

        public YearMonth() { }

        //メソッド
        //4.1.3
        public YearMonth AddOneMonth() {
            return
                new YearMonth {
                    Month = (this.Month) % 12  == 0 ? ,
                    Year  = ,
                };
            
        }

        #endregion
#else
        #region 模範解答
        public int Year { get; private set; }
        
        public int Month { get; private set; }

        public YearMonth(int year , int month) {
            Year = year;
            Month = month;
        }

        //4.1.2
        public bool Is21Centry
        {
            get
            {
                return 2001 <= Year && Year <= 2100;
            }
        }
        #endregion
#endif
    }
}
