using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {     //名前空間

    class Program {     //クラス名（変更可能）
        static void Main(string[] args) {

            /*
             * 商品コード：123
             * 商品名：かりんとう
             * 商品価格：180
             * 
             * ①上記の商品インスタンスを作成する
             * ②税込みの価格を表示する【Console.WriteLine()を利用して出力】
             * 
             * 実行は「Ctrlキー」＋「F5」（コンソールアプリの場合、デバックなしで実行）
             */

            //Product karinto = new Product( 123 , "かりんとう" , 180 );
            //Console.WriteLine( "税込価格：" + karinto.GetPriceIncludingTax() + "円" );

            //インスタンスの生成
            Product karinto = new Product( 123 , "かりんとう" , 180 );
            Product daifuku = new Product( 235 , "大福もち" , 160 );

            Console.WriteLine( "かりんとうの税込価格：" + karinto.GetPriceIncludingTax() + "円" );
            Console.WriteLine( "大福もちの税込価格：" + daifuku.GetPriceIncludingTax() + "円" );

        }
    }
}
