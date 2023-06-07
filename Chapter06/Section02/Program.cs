using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {

    class Program {

        static void Main(string[] args) {

            Stopwatch sw = new Stopwatch();     //タイマーインスタンス生成
            sw.Start();     //タイマースタート

            var numbers = Enumerable.Range( 1 , 1000000 ).ToArray();        //要素数 1000000 の配列取得　3.836 MB  
            //var numbers = Enumerable.Range( 1 , 1000000 );                // 0.021 MB
            //var numbers = Enumerable.Range( 1 , 1000000 ).ToList();         // 4.021 MB
            WriteTotalMemory("配列確保後");

            //偶数だけを取り出す

#if !true

            #region 自力

            numbers.Where( x => x % 2 == 0 ).ToList().ForEach( Console.WriteLine );

            #endregion

#else

            #region 模範解答

            var evenNumbers = numbers.Where( n => n % 2 == 0 );     //ToList() があると 実行時間 = 00.01753 ms
                                                                    //ToArray() だと 実行時間 = 00.01652 ms
            Console.WriteLine( "偶数抽出後" );

            //foreach ( var item in numbers )
            //{
            //    Console.WriteLine( item + " " );
            //}

            //取り出した偶数の平均値を求める
            var ave = evenNumbers.Average();

            WriteTotalMemory( "偶数抽出後平均" );
            Console.WriteLine( "実行時間 = {0}" , sw.Elapsed.ToString( @"ss\.fffff" ) );        //時間表示

            #endregion

#endif

        }

        static void WriteTotalMemory( string header ) {

            var totalMemory = GC.GetTotalMemory( true ) / 1024.0 / 1024.0;          // MB に変換
            Console.WriteLine( $"{header}: {totalMemory:0.000 MB}" );

        }

    }

}
