using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {

    class Program {

        static void Main(string[] args) {

            //ReadSales( @"Sales.csv" );      //ドライバー
                                              //テストのために仕方なく作るメソッドはスタブ

        }

        //売り上げデータを読み込み、Saleオブジェクトのリストを返す
        static List< Sale > ReadSales( string filePath ) {

            List< Sale > sales = new List< Sale >();        //売り上げデータを格納する
            string[] lines = File.ReadAllLines( filePath );     //ファイルからすべてのデータを読み込む

            foreach ( string line in lines )        //すべての行から1行ずつ取り出す（順番に）
            {

                string[] items = line.Split( ',' );     //区切りで項目別に分ける
                Sale sale = new Sale        //Saleインスタンスを生成（見ればわかることはコメントには基本書かない）
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
