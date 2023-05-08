using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {     //名前空間

    class Program {     //クラス名（変更可能）
        static void Main(string[] args) {

            #region P26のサンプルプログラム
            //インスタンスの生成
            //Product karinto = new Product( 123 , "かりんとう" , 180 );
            //Product daifuku = new Product( 235 , "大福もち" , 160 );

            //Console.WriteLine( "かりんとうの税込価格：" + karinto.GetPriceIncludingTax() + "円" );
            //Console.WriteLine( "大福もちの税込価格：" + daifuku.GetPriceIncludingTax() + "円" );
            #endregion

            //DateTime date = new DateTime( 2023 , 5 , 8 );         //5月8日
            DateTime date = DateTime.Today;     //今日の日付を取得

            //１０日後を求める
            //DateTime daysAfter10 = date.AddDays( 10 );
            //Console.WriteLine( "今日の10日後は" + daysAfter10.Day+ "日です。" );

            /*
             * 【演習１】
             * 実行結果
             * 
             * 今日の日付：2023年5月8日
             * 10日後：2023年5月18日
             * 10日前：2023年4月  日
             * 
             * ※できた人は「0508演習1」とコメントを入力し、コミット＆プッシュ
             * 
             * 【演習２】
             * 実行結果
             * 
             * 誕生日を入力
             * 西暦：
             * 月：
             * 日：
             * 
             * あなたは生まれてから今日まで〇〇〇〇日目です。【ヒント：TimeSpan構造体を使用】
             * 
             * ※できた人は「0508演習2」とコメントを入力し、コミット＆プッシュ。
             */

            #region 【演習１】

            /*
             * 【演習１】
             * 実行結果
             * 
             * 今日の日付：2023年5月8日
             * 10日後：2023年5月18日
             * 10日前：2023年4月  日
             * 
             * ※できた人は「0508演習1」とコメントを入力し、コミット＆プッシュ
             */

            //１０日後を求める
            //DateTime daysAfter10 = date.AddDays( 10 );
            //Console.WriteLine( "10日後：" + daysAfter10.Year + "年" + daysAfter10.Month + "月" + daysAfter10.Day + "日です。" );
            Console.WriteLine( "10日後：" 
                    + date.AddDays( 10 ).Year + "年" 
                    + date.AddDays( 10 ).Month + "月" 
                    + date.AddDays( 10 ).Day + "日" );     //すっきり、変数削減

            //１０日前を求める
            //DateTime daysBefore10 = date.AddDays( -10 );
            //Console.WriteLine( "今日の10日前は" + daysBefore10.Year + "年" + daysBefore10.Month + "月" + daysBefore10.Day + "日です。" );
            Console.WriteLine("10日前："
                    + date.AddDays( -10 ).Year + "年"
                    + date.AddDays( -10 ).Month + "月"
                    + date.AddDays( -10 ).Day + "日");     //すっきり、変数削減

            #endregion

            #region 【演習２】

            /* 【演習２】
             * 実行結果
             * 
             * 誕生日を入力
             * 西暦：
             * 月：
             * 日：
             * 
             * あなたは生まれてから今日まで〇〇〇〇日目です。【ヒント：TimeSpan構造体を使用】
             * 
             * ※できた人は「0508演習2」とコメントを入力し、コミット＆プッシュ。
             */

            Console.Write( "西暦：" );
            int year = int.Parse( Console.ReadLine() );
            Console.Write( "月：" );
            int month = int.Parse( Console.ReadLine() );
            Console.Write( "日：" );
            int day = int.Parse( Console.ReadLine() );

            DateTime birthDay = new DateTime( year , month , day );
            DateTime now = DateTime.Today;
            TimeSpan total = now - birthDay;

            Console.WriteLine( "あなたは生まれてから今日まで{0}日目です。" , total.Days );

            #endregion

        }
    }
}
