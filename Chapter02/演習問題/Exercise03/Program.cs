using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
#if false
            #region 自力
            var sales = new SalesCounter(@"data\sales.csv");
            IDictionary<string, int> amount = null;
            int pattern;
            string[] comments = { "１：店舗別売り上げ" , "２：商品カテゴリー別売り上げ" };

            Console.WriteLine("＊＊売上集計＊＊");
            foreach (string comment in comments)
            {
                Console.WriteLine(comment);
            }
            Console.Write(">");

            while (true)
            {
                try
                {
                    pattern = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    throw new ArgumentException("入力が不正です。");
                }
            }

            switch(pattern)
            {
                case 1:     //店舗別売り上げ
                    amount = sales.GetPerStoreSales();
                    break;

                case 2:     //商品カテゴリー別売り上げ
                    amount = sales.GetPerCategorySales();
                    break;
            }

            foreach (KeyValuePair<string, int> obj in amount)
            {
                Console.WriteLine("{0}：{1:C}", obj.Key, obj.Value);
            }
            #endregion
#else
            #region 模範解答
            Console.WriteLine("**売上集計**");      //忠実に再現して
            Console.WriteLine("1：店舗別売り上げ");
            Console.WriteLine("2：商品カテゴリー別売り上げ");
            Console.Write(">");     //WriteLineだと改行されちゃう

            int select = int.Parse(Console.ReadLine());

            var sales = new SalesCounter(@"data\sales.csv");

            IDictionary<string,int> amountPerStore = sales.GetPerCategorySales();       //共通する型に
            if (select == 1)
            {
                amountPerStore = sales.GetPerStoreSales();
            }
            else
            {
                amountPerStore = sales.GetPerCategorySales();
            }
            foreach (KeyValuePair<string, int> obj in amountPerStore)
            {
                Console.WriteLine("{0} {1:C}", obj.Key, obj.Value);
            }
            #endregion
#endif
        }
    }
}
