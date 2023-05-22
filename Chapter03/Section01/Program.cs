using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {

    class Program {

        //public delegate bool Judgement( int value );        //デリゲートの宣言

        static void Main(string[] args) {

            var numbers = new[] { 5 , 3, 9 , 6 , 7 , 5 , 8 , 1 , 0 , 5 , 10 , 4 };
            //Judgement judge = IsEven;       //メソッドを格納
            
            int count = numbers.Count( /*numbers ,*/ n => n % 2 == 0 );     // =>： ラムダ演算子、return、{}、型名、()、;とか省略可能

            Console.WriteLine( count );      //処理がと渡す

        }

        /*      もう指定済み
        //指定された値が何個あるかを求めて返す
        public static int Count ( int[] numbers , Predicate< int > judge ) {       //Predicate　bool型を返す　ほかにもいろいろある

            int count = 0;

            foreach( int n in numbers )
            {

                if( judge( n ) == true )        //judge っていう処理 を n で呼んで true か false を受けとる
                {
                    count++;
                }

            }

            return count;

        }
        */

    }

}
