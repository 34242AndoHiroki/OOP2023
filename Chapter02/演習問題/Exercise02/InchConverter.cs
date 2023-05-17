using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
#if false
    #region 自力
    //インチとメートルの単位換算クラス
    public static class InchConverter {
        //定数
        private const double ratio = 0.0254;

        //インチからメートルを求める
        public static double FromMeter(double inch) {
            return inch / ratio;
        }

        //メートルからインチを求める
        public static double ToMeter(double metar) {
            return metar * ratio;
        }
    }
    #endregion
#else
    #region 模範解答
    //FeetConverterをまんまコピーして変更
    public static class InchConverter {     //feetからinch
        //定数
        private const double ratio = 0.0254;

        //メートルからインチを求める
        public static double ToMeter(double metar) {
            return metar * ratio;
        }

        //インチからメートルを求める
        public static double FromMeter(double inch) {       //feetからinch
            return inch / ratio;
        }
    }
    #endregion
#endif
}
