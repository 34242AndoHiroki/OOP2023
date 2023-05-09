using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    class Program {
        static void Main(string[] args) {

            //フィートからメートルへの対応表を出力
            for ( int feet = 1 ; feet <= 10 ; feet++ )
            {

                double metar = FeetToMetar( feet );
                Console.WriteLine("{0} ft = {1:0.0000}m", feet, metar);

            }

        }

        //フィートからメートルを求める
        static double FeetToMetar( int feet ) {

            return feet * 0.3048;

        }
    }
}
