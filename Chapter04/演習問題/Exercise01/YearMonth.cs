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
        //21世紀の判定
        public bool Is21Century => 2001 <= Year && Year <= 2100;

        //コンストラクタ
        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }

        //メソッド
        public YearMonth AddOneMonth() {
            return new YearMonth((this.Month) == 12 ? this.Year + 1 : this.Year, (this.Month) % 12 == 0 ? 1 : this.Month + 1);

            //YearMonth() があれば
            //return new YearMonth
            //{
            //    Year = (this.Month) == 12 ? this.Year + 1 : this.Year,
            //    Month = (this.Month) % 12 == 0 ? 1 : this.Month + 1
            //}
        }

        //ToString()のオーバーライド
        public override string ToString() {
            return this.Year + "年" + this.Month + "月";
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
