using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample0410 {
    class Program {
        static void Main(string[] args) {

            //"群馬県太田市"を10回出力
            /*for ( int i = 0 ; i < 10 ; i++ ){
                Console.WriteLine( i + "：群馬県太田市");
            }*/

            /*for (int i = 0; i < 10; i++){
                Console.WriteLine( "{0}：群馬県太田市" , i );
            }*/

            //入力機構付き
            //Console.Write( "何回繰り返しますか？：" );
            //int count = int.Parse( Console.ReadLine() );

            /*for ( int i = 0; i < count ; i++ ){
                Console.WriteLine("{0}：群馬県太田市", i);
            }*/

            //表示は1スタート
            /*for ( int i = 0 ; i < count ; i++) {
                Console.WriteLine("{0}：群馬県太田市", i + 1);
            }*/

            //正方形を出力
            /*Console.Write("一辺を何個表示しますか？：");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++) {

                for (int j = 0; j < count; j++) {

                    Console.Write("*");

                }

                Console.WriteLine();
                
            }*/

            //二等辺三角形
            Console.Write("一辺を何個表示しますか？：");
            int count = int.Parse(Console.ReadLine());

            //左下
            for (int i = 1; i <= count; i++)
            {

                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            //左上
            for (int i = count; i >= 0; i--)
            {

                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }

            Console.WriteLine();

            //右下   
            for (int i = 1; i <= count; i++)
            {

                for (int j = 0; j < (count - i); j++)        //空白用のループ
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            //右上
            for (int i = count; i >= 0; i--)
            {

                for (int j = 0; j < (count - i); j++)        //空白用のループ
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            /*//正三角形
            for (int i = 1; i <= count; i++)
            {

                for (int j = 0; j < (count - i); j++)        //空白用のループ
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < ( 2 * i - 1 ) ; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            //逆正三角形
            for (int i = count; i > 0; i--)
            {

                for (int j = 0; j < (count - i); j++)        //空白用のループ
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < (2 * i - 1); j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }*/

            //正三角形（全角）
            for (int i = 1; i <= count; i++)
            {

                for (int j = 0; j < (count - i); j++)        //空白用のループ
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < i; j++)
                {
                    Console.Write("＊");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            //逆正三角形（全角）
            for (int i = count; i > 0; i--)
            {

                for (int j = 0; j < (count - i); j++)        //空白用のループ
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < i; j++)
                {
                    Console.Write("＊");
                }

                Console.WriteLine();
            }

        }
    }
}
