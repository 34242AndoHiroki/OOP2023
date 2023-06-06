using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {

            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

#if true
            #region 自力
            int novelist = 0;
            int bestwork = 1;
            int born = 2;

            var informations = line.Split(';');

            Console.WriteLine(informations[novelist].Replace("Novelist=", "作者　："));
            Console.WriteLine(informations[bestwork].Replace("BestWork=", "代表作："));
            Console.WriteLine(informations[born].Replace("Born=", "誕生年："));

            #endregion
#else
            #region 模範解答

            #endregion
#endif
        }
    }
}
