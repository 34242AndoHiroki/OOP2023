using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {

    class Program {

        static void Main(string[] args) {

            #region 条件演算子
            //これくらいなら、コメントでもいい

            //var list = new List<int> { 10 , 20 , 30 , 40 , };
            //var key = 40;       //ここをいろいろ変更してみて

            //var num = list.Contains( key ) ? 1 : 0;     //条件演算子・三項演算子

            //Console.WriteLine( num );

            #endregion

            #region 合体演算子

            //string code = "12345";
            //var message = GetMassage( code ) ?? DefaultMessage();       //null合体演算子
            //            //  対象                  処理              対象がnullなら処理実行

            //Console.WriteLine( message );

            #endregion

            #region null条件演算子

            Sale sale = new Sale()      //varでもOK
            {
                Amount = 1000 ,     //Amountのみの定義
            };

            //Sale sale = null;     //この場合は処理しない

            //「int?」は null許容型、「?.」は null条件演算子
            int? ret = sale?.Amount;        //nullだったら、処理をしなくなる

            Console.WriteLine( ret );       //nullだと例外エラー

            #endregion

        }

        private static object GetMassage( string code ) {

            return null;

        }

        private static object DefaultMessage() {

            return "DefaultMessage";

        }

    }

    //売り上げクラス
    public class Sale {

        //店舗名
        public string ShopName { get; set; }

        //商品カテゴリー
        public string ProductCategory { get; set; }

        //売上高
        public int Amount { get; set; }

    }

}
