using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    class Program {
        static void Main(string[] args) {

            if ( args.Length >= 1 && args[ 0 ] == "-tom" )
            {

                //フィートからメートルへの対応表を出力
                for ( int feet = 1 ; feet <= 10 ; feet++ )
                {

                    double metar = FeetToMetar( feet );
                    Console.WriteLine( "{0} ft = {1:0.0000}m" , feet , metar );

                }

            }
            else
            {

                //メートルからフィートへの対応表を出力
                for ( int metar = 1 ; metar <= 10 ; metar++ )
                {

                    double feet = MetarToFeet( metar );
                    Console.WriteLine( "{0} ft = {1:0.0000}m" , metar , feet );

                }

            }

        }

        //フィートからメートルを求める
        static double FeetToMetar( int feet ) {

            return feet * 0.3048;

        }

        //メートルからフィートを求める
        static double MetarToFeet( int metar ) {

            return metar / 0.3048;

        }

    }

}
