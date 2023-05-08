using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {

    //商品クラス
    class Product {

        //商品コード
        public int Code { get; set; }       //自動実装プロパティ
        //商品名
        public string Name { get; set; }
        //商品価格（税抜き）
        public int Price { get; set; }

        //propで簡単にできる


        //コンストラクタ
        public Product( int code , string name , int price ) {

            this.Code = code;       //thisなしでもOK    省略可能
            this.Name = name;
            this.Price = price;

        }


        //消費税を求める（消費税率は10%）
        public int GetTax() {

            return ( int )( Price * 0.1 );      //キャスト

        }


        public int GetPriceIncludingTax() {

            return Price + GetTax();

        }

    }
}
