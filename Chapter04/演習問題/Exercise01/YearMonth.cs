﻿using System;
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

        

        #endregion
#else
        #region 模範解答
        public int Year { get; private set; }
        
        public int Month { get; private set; }
        
        public int Is21Centry { get; set; }

        public YearMonth(int year , int month) {
            Year = year;
            Month = month;
        }
        #endregion
#endif
    }
}
