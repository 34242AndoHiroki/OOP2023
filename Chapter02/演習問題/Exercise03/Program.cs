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
            var amountPerStore = sales.GetPerCategorySales();
            foreach (KeyValuePair<string, int> obj in amountPerStore)
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
