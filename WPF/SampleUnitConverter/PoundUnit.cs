#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {

    //ポンド単位を表すクラス
    public class PoundUnit :DistanceUnit {

#if Mywork

        private static List< PoundUnit > units = new List< PoundUnit > {      //所持用

            new PoundUnit{ Name = "ozf" , Coefficient = 0.0625 , } ,        //( 1 / 16 )
            new PoundUnit{ Name = "lb" , Coefficient = 1 , } ,
            new PoundUnit{ Name = "cwt" , Coefficient = 14 , } ,

        };

        public static ICollection< PoundUnit > Units { get { return units; } }     //外部公開（アクセス）用

        /// <summary>
        /// グラム単位からポンド単位に変換します
        /// </summary>
        /// <param name="unit">グラム単位</param>
        /// <param name="value">値</param>
        /// <returns>変換値</returns>

        public double FromGrumUnit( GrumUnit unit , double value ){

            return ( value * unit.Coefficient ) / 0.454 / this.Coefficient;

        }

#elif Answer

        private static List< PoundUnit > units = new List< PoundUnit > {      //所持用

            new PoundUnit{ Name = "oz" , Coefficient = 1 , } ,
            new PoundUnit{ Name = "lb" , Coefficient = 16 , } ,

        };

        public static ICollection< PoundUnit > Units { get { return units; } }     //外部公開（アクセス）用

        /// <summary>
        /// グラム単位からポンド単位に変換します
        /// </summary>
        /// <param name="unit">グラム単位</param>
        /// <param name="value">値</param>
        /// <returns>変換値</returns>

        public double FromGrumUnit( GrumUnit unit , double value ){

            return ( value * unit.Coefficient ) / 28.35 / this.Coefficient;

        }

#endif

    }

}
