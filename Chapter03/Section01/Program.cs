using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {

    class Program {

        //public delegate bool Judgement( int value );        //デリゲートの宣言

        static void Main(string[] args) {

            var numbers = new[] { 5 , 3 , 9 , 6 , 7 , 5 , 8 , 1 , 0 , 5 , 10 , 4 };

            //int count = numbers.Count( n => n % 2 == 0 );     // =>： ラムダ演算子、return、{}、型名、()、;とか省略可能

            //5以上
            //int count = numbers.Count( n => n >= 5 );

            //３以上８未満
            //int count = numbers.Count( n => 3 <= n && n < 8 );

            //１を含む
            //int count = numbers.Count( n => n.ToString().Contains( '1' ) );

#if false

            #region 自力

            //５の倍数をカウントする
            int count = numbers.Count( n => n % 5 == 0 );       //倍数は０を含む

            //合計値
            var sum = numbers.Sum();

            //偶数の合計値
            var evens_sum = numbers.Sum( n => n % 2 );

            #endregion

#else

            #region 模範解答

            //５の倍数をカウントする
            int count = numbers.Count( v => v % 5 == 0 && v > 0 );       // v はよろしくない

            //合計値
            //var sum = numbers.Sum();

            //偶数の合計値
            var sum = numbers.Where( n => n % 2 == 0 ).Sum();

            //偶数の平均値
            var avg = numbers.Where( n => n % 2 == 0 ).Average();

            #endregion

#endif

            Console.WriteLine( count );
            Console.WriteLine( sum );
            //Console.WriteLine( evens_sum );

        }

    }

}

