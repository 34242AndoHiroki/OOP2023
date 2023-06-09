﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    public class SalesCounter {
       
        private IEnumerable< Sale > _sales;     //IEnumerableを実装しているものならなんでも入る

        //コンストラクタ
        public SalesCounter( string filePath ) {
            _sales = ReadSales( filePath );
        }

        //店舗別売り上げを求める
        public IDictionary< string , int > GetPerStoreSales() {
            var dict = new SortedDictionary< string , int >();     //勝手にソートしてくれる。何順かは知らん。
            foreach( Sale sale in _sales)
            {
                if ( dict.ContainsKey( sale.ShopName ) )
                    dict[ sale.ShopName ] += sale.Amount;     //店名が既に存在する（売り上げ加算）
                else
                    dict[ sale.ShopName ] = sale.Amount;       //店名が存在しない（新規格納）
            }
            return dict;
        }

        //売り上げデータを読み込み、Saleオブジェクトのリストを返す
        private static IEnumerable< Sale > ReadSales( string filePath ) {     //staticなしでOK
                    //読み込み機構は共用という意味合い？
            var sales = new List< Sale >();        //売り上げデータを格納する
            var lines = File.ReadAllLines( filePath );     //ファイルからすべてのデータを読み込む
            foreach ( string line in lines )        //すべての行から1行ずつ取り出す
            {
                var items = line.Split( ',' );     //区切りで項目別に分ける
                var sale = new Sale        //Saleインスタンスを生成
                {
                    ShopName = items[ 0 ] ,
                    ProductCategory = items[ 1 ] ,
                    Amount = int.Parse( items[ 2 ] ) ,
                };
                sales.Add( sale );      //Salesインスタンスをコレクションに追加
            }
            return sales;
        }

    }
}
