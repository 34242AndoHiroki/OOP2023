using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0411 {
    class Program {

        static int[] money = { 10000, 5000, 2000, 1000, 500, 100, 50, 10, 5, 1 };

        static void Main(string[] args) {       //エントリーポイント

            //int count = int.Parse( Console.ReadLine() );

            /*for (int j = 0; j < count; j++)
            {

                //Console.WriteLine();    //ここでも間違いではない

                for (int i = 0; i < count; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();    //改行

            }*/

            /*//三角
            for (int i = 0; i < count; i++)
            {

                //空白を出力
                for (int j = 0; j < count - ( i + 1 ) ; j++)
                //for (int i = 0; i <= j; i++) ×    1スタートもやめて。
                {
                    Console.Write(" ");
                }

                //"*"を出力
                for (int k = 0; k < ( k + 1 ); k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();    //改行

            }

            //正三角形（全角）
            for (int i = 0; i < count; i++)
            {

                //空白を出力
                for (int j = 0; j < (count - (i + 1)); j++)        //空白用のループ
                {
                    Console.Write(" ");
                }

                //"*"を出力
                for (int k = 0; k < i; k++)
                {
                    Console.Write("＊");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            //逆正三角形（全角）
            for (int i = 0; i < count; i++)
            {

                //空白を出力
                for (int j = 0; j < i ; j++)        //空白用のループ
                {
                    Console.Write(" ");
                }

                //"*"を出力
                for (int k = 0; k < count - i; k++)
                {
                    Console.Write("＊");
                }

                Console.WriteLine();        //改行
            }*/

            /*//⑤
            //演習１
            Console.Write("金額：");
            int price = int.Parse(Console.ReadLine());
            Console.Write("支払い：");
            int pay = int.Parse(Console.ReadLine());
            int back = pay - price;
            int[] money = { 10000 , 5000 , 1000 , 500 , 100 , 50 , 10 , 5 , 1 };
            int[] amount = new int[ money.Length ];
            int point = 0;

            Console.WriteLine( back < 0 ? "お金が足りません" : "お釣り：" + back );

            while ( back > 0 ){

                amount[ point ] = back / money[ point ];
                back %= money[ point ];
                point++;

            }

            for (int i = 0; i < amount.Length ; i++)
            {
                
                //Console.WriteLine( "%d円%s：%d枚" , money[i] , ( i > 2 ? "札" : "玉" ) , amount[i]);

                Console.Write( money[ i ] + "円" );

                if( i > 2 ){     //札

                    Console.Write("札");

                }
                else{      //玉

                    Console.Write("玉");

                }
                
                Console.WriteLine( "：" + amount[ i ] + "枚" );

            }*/

            /*//演習２
            Console.Write("金額：");
            int price = int.Parse(Console.ReadLine());
            Console.Write("支払い：");
            int pay = int.Parse(Console.ReadLine());
            int back = pay - price;
            int[] money = { 10000, 5000, 1000, 500, 100, 50, 10, 5, 1 };
            int[] amount = new int[money.Length];
            int point = 0;
            int cpy;

            Console.WriteLine(back < 0 ? "お金が足りません" : "お釣り：" + back);

            while (back > 0)
            {

                amount[point] = back / money[point];
                back %= money[point];
                point++;

            }

            for (int i = 0; i < amount.Length; i++)
            {

                Console.Write( money[i] + "円" + ( i < 3 ? "札" : "玉" ) + "：" );
                cpy = amount[i];

                for ( int j = 0 ; j < cpy ; j++ )
                {

                    Console.Write( "＊" );

                }

                Console.WriteLine();

            }*/

            /*//演習３
            Console.Write("金額：");
            int price = int.Parse(Console.ReadLine());
            Console.Write("支払い：");
            int pay = int.Parse(Console.ReadLine());
            int back = pay - price;
            int[] amount;

            Console.WriteLine( back < 0 ? "お金が足りません" : "お釣り：" + back );

            amount = calcAmount(ref back);
            printStar(amount);*/

            //模範解答
            
            //法則性が見つかったら取り掛かること
            String[] moneyString = { "一万円札" , "五千円札" , "千円札" , "五百円玉" , "百円玉" , "五十円玉" , "十円玉" , "五円玉" , "一円玉" };
            int[] moneyInteger = { 10000, 5000, 1000, 500, 100, 50, 10, 5, 1 };
            //int[] moneyInteger = {     10000,        5000,      1000,         500,       100,         50,         10,         5,         1 };     //  上に合わせて書くも可

            //金額の入力
            Console.Write("金額：");
            int total = int.Parse(Console.ReadLine());

            //支払い金額入力
            Console.Write("支払い：");
            int pay = int.Parse(Console.ReadLine());

            //お釣りの計算
            int change = pay - total;
            Console.Write("お釣り：{0}円" , change);

            //金種枚数出力

            //ベタな書き方　初歩的
            /*Console.Write("一万円札：{0}枚", change / 10000);
            change %= 10000;

            Console.Write("五千円札：{0}枚", change / 5000);
            change %= 5000;

            Console.Write("千円札：{0}枚", change / 1000);
            change %= 1000;

            Console.Write("五百円玉：{0}枚", change / 500);
            change %= 500;

            Console.Write("百円玉：{0}枚", change / 100);
            change %= 100;

            Console.Write("五十円玉：{0}枚", change / 50);
            change %= 50;

            Console.Write("十円玉：{0}枚", change / 10);
            change %= 10;

            Console.Write("五円玉：{0}枚", change / 5);
            change %= 5;

            Console.Write("一円玉：{0}枚", change / 1);
            change %= 1;*/

            //ベタからの効率化
            for (int i = 0; i < moneyString.Length ; i++)
            {
                //Console.WriteLine(moneyString[i] + "：{0}枚", change / moneyInteger[i]);        //枚数を値で出力
                Console.Write(moneyString[i] + "：{0}枚", change / moneyInteger[i]);       
                astOut(change / moneyInteger[i]);        //枚数を"*"で出力
                /*
                for (int i = 0; i < change / moneyInteger[i]; i++)
                {
                    Console.Write("＊");
                }*/
                change %= moneyInteger[i];
            }

        }

        private static int[] calcAmount( ref int back ) {       //枚数を求める

            int[] amount = new int[ money.Length ];
            int point = 0;
            
            while ( back > 0 )
            {

                amount[point] = back / money[point];
                back %= money[point];
                point++;

            }

            return amount;

        }

        private static void printStar( int[] amount ) {     //星を出力する

            int cpy;

            for (int i = 0; i < amount.Length; i++)
            {

                //Console.Write( "{0}円{a}：" , money[i] , (i < 4 ? "札" : "玉") );
                Console.Write(money[i] + "円" + ( i < 4 ? "札" : "玉") + "：");
                cpy = amount[i];

                for (int j = 0; j < cpy; j++)
                {

                    Console.Write("＊");

                }

                Console.WriteLine();

            }

        }

        //模範メソッド

        //指定した個数の"*"を出力する
        private static void astOut( int count ) {

            for (int i = 0; i < count; i++)
            {
                Console.Write("＊");
            }
            Console.WriteLine();       //改行

        }

    }
}
