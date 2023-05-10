using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {

    //フィートとメートルの単位換算クラス
    public static class FeetConverter {     

        //定数
        private const double ratio = 0.3048;        //publicはあんまり好ましくない
        //public static readonly double ratio = 0.3048;     //publicならreadonlyにしよう

        //フィートからメートルを求める
        public static double FromMeter( double feet ) {
            return feet * ratio;
        }

        //メートルからフィートを求める
        public static double ToMeter( double metar ) {
            return metar / ratio;
        }

    }
}
