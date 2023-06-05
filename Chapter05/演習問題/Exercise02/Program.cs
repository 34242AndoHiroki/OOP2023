using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            var line = Console.ReadLine();

#if true
            #region 自力
            int result;
            if(int.TryParse(line ,out result))
            {
                Console.WriteLine("{0:C}", result);
            }
            else
            {
                Console.WriteLine();
            }
            #endregion
#else
            #region 模範解答
            int num;
            if(int.TryParse(line, out num))
            {
                Console.WriteLine("{0:#,#}" , num);
            }
            else
            {
                Console.WriteLine("数値文字列ではありません");
            }
            #endregion
#endif

        }
    }
}
