#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {

    //グラム単位を表すクラス
    public class GrumUnit : DistanceUnit {

#if Mywork

        private static List< GrumUnit > units = new List< GrumUnit > {      //所持用

            new GrumUnit{ Name = "g" , Coefficient = 0.001 , } ,
            new GrumUnit{ Name = "kg" , Coefficient = 1 , } ,

        };

        public static ICollection< GrumUnit > Units { get { return units; } }     //外部公開（アクセス）用

        /// <summary>
        /// ポンド単位からグラム単位に変換します
        /// </summary>
        /// <param name="unit">ポンド単位</param>
        /// <param name="value">値</param>
        /// <returns>変換値</returns>

        public double FromPoundUnit( PoundUnit unit , double value ){

            return ( value * unit.Coefficient ) * 0.454 / this.Coefficient;

        }

#elif Answer

        private static List< GrumUnit > units = new List< GrumUnit > {      //所持用

            new GrumUnit{ Name = "g" , Coefficient = 0.001 , } ,
            new GrumUnit{ Name = "kg" , Coefficient = 1 , } ,

        };

        public static ICollection< GrumUnit > Units { get { return units; } }     //外部公開（アクセス）用

        /// <summary>
        /// ポンド単位からグラム単位に変換します
        /// </summary>
        /// <param name="unit">ポンド単位</param>
        /// <param name="value">値</param>
        /// <returns>変換値</returns>

        public double FromPoundUnit( PoundUnit unit , double value ){

            return ( value * unit.Coefficient ) * 0.454 / this.Coefficient;

        }

#endif

    }

}
