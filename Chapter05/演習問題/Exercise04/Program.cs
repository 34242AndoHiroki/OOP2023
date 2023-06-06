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
            string[] tags = { "Novelist", "BestWork", "Born" };      //変更前の書式
            string[] comments = { "作者　", "代表作", "誕生年" };    //変更後の書式

            var informations = line.Split(';');

            for (int i = 0; i < comments.Length; i++)
            {
                Console.WriteLine(informations[i].Replace(tags[i] + "=", comments[i] + "："));
            }

            #endregion
#else
            #region 模範解答

            #endregion
#endif
        }
    }
}
