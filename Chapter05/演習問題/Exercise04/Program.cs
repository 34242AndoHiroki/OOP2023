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
            string[] tags = { "Novelist", "BestWork", "Born" };
            string[] comments = { "作者　", "代表作", "誕生年" };

            var informations = line.Split(';');

            for (int i = 0; i < tags.Length; i++)
            {

                for (int j = 0; j < informations.Length; j++)
                {
                    if (informations[j].Contains(tags[i]))
                        Console.WriteLine(informations[j].Replace(tags[i] + "=", comments[i] + "："));
                }

            }
            #endregion
#else
            #region 模範解答

            #endregion
#endif
        }
    }
}
