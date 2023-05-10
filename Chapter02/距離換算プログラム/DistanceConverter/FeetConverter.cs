using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {

    //フィートとメートルの単位換算クラス
    public class FeetConverter {

        //フィートからメートルを求める
        public double FromMeter( double feet ) {
            return feet * 0.3048;
        }

        //メートルからフィートを求める
        public double ToMeter( double metar ) {
            return metar / 0.3048;
        }

    }
}
