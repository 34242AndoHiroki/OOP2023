using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Section02 {

    class Program {

        static void Main(string[] args) {

            //IsMatch01();            //そうか否かとかいうやつは「Is～」」という名前にするらしい
            //IsMatch02();
            //StartWith();
            //EndWith();
            //PerfectMatch();
            PerfectMatch02();

            Console.ReadLine();

        }

        //静的メソッドを使用した場合メソッド(@…逐語的リテラル)
        private static void IsMatch01() {

            var text = "private List< string > results = new List< string >";
            bool isMatch = Regex.IsMatch( text , @"List< \w+ >" );      //\w：任意の単語

            if ( isMatch )
                Console.WriteLine( "見つかりました" );
            else
                Console.WriteLine( "見つかりません" );

        }

        //インスタンスを使用した場合メソッド
        private static void IsMatch02() {       //検索条件をインスタンス化

            var text = "private List< string > results = new List< string >";
            var regex = new Regex( @"List< \w+ >" );      //\w：任意の単語
            bool isMatch = regex.IsMatch( text );

            if ( isMatch )
                Console.WriteLine( "見つかりました" );
            else
                Console.WriteLine( "見つかりません" );

        }

        public static void StartWith() {

            var text = "using System.Text.RegularExpressions;";
            bool isMatch = Regex.IsMatch( text , @"^using" );           // ^：始まり（行頭）

            if ( isMatch )
                Console.WriteLine( "'using'で始まっています" );
            else
                Console.WriteLine( "'using'で始まっていません" );

        }

        public static void EndWith() {

            var text = "Regexクラスを使った文字列操作について説明します。";
            bool isMatch = Regex.IsMatch( text , @"ます。$" );            // $：終わり（行末）    後ろにつけるもの

            if ( isMatch )
                Console.WriteLine( "'ます。'で終わっています" );
            else
                Console.WriteLine( "'ます。'で終わっていません" );

        }

        //10-5
        public static void PerfectMatch() {     //こういう場合はインスタンス変数を使おう

            var strings = new[] { "Microsoft Windows" , "Windows Server" , "Windows" , };

            var regex = new Regex( @"^(W|w)indows$" );

            var regex1 = new Regex( @"(W|w)indows$" );      //Microsoft Windows と Windows の２つ
            var regex2 = new Regex( @"^(W|w)indows" );      //Windows Server と Windows の２つ
            var regex3 = new Regex( @"(W|w)indows" );       // すべて（３つ）

            var count = strings.Count( s => regex.IsMatch( s ) );
            Console.WriteLine( "{0}行と一致" , count );

        }

        //10-7
        public static void PerfectMatch02() {

            var strings = new[] { "13000", "-50.6" , "0.123" ,  "+180.00" , "10.2.5" , "320-0851" , " 123" , "$1200" , "500円" , };

            //var regex = new Regex( @"^[-+]?(\d+)(\.\d+)?$" );       // ?：あるかないか　０か１ 　（）：グループ化、グルーピング　まとめる       \.：ピリオド

            //郵便番号を抽出する正規表現
            //var regex = new Regex( @"^(\d{3})[-](\d{4})$" );        //自力
            var regex = new Regex( @"^\d{3}-\d{4}$" );        //解答
            //var regex = new Regex( @"^[0-9]{3}-[0-9]{4}$" );        //別解

            foreach ( var s in strings ) {

                var isMatch = regex.IsMatch( s );

                if ( isMatch )
                    Console.WriteLine( s );

            }

        }

    }

}
