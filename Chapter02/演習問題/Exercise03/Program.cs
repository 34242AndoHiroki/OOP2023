using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
#if true
            #region 自力
            var sales = new SalesCounter(@"data\sales.csv");
            IDictionary<string, int> amount = null;
            int pattern;

            Console.WriteLine("＊＊売上集計＊＊");
            Console.WriteLine("１：店舗別売り上げ");
            Console.WriteLine("２：商品カテゴリー別売り上げ");
            Console.Write(">");
            pattern = int.Parse(Console.ReadLine());

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

            #endregion
#endif
        }
    }
}
