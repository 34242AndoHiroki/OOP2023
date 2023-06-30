using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";
            Exercise1_1(text);
            Console.WriteLine();
            Exercise1_2(text);
        }

#if !true
        #region 自力
        private static void Exercise1_1(string text) {
            var dict = new Dictionary<Char, int>();

            foreach (var ch in text)
            {
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    if (ch.ToString().ToUpper()==c.ToString())
                    {
                        if (dict.ContainsKey(c)) dict[c]++;
                        else dict.Add(c, 1);
                        break;
                    }
                }
            }

            dict.OrderBy(c => c.Key).ToList().ForEach(c => Console.WriteLine("'{0}'：{1}",c.Key,c.Value));
        }

        private static void Exercise1_2(string text) {
            var dict = new SortedDictionary<Char, int>();

            foreach (var ch in text)
            {
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    if (ch.ToString().ToUpper() == c.ToString())
                    {
                        if (dict.ContainsKey(c)) dict[c]++;
                        else dict.Add(c, 1);
                        break;
                    }
                }
            }

            dict.ToList().ForEach(c => Console.WriteLine("'{0}'：{1}", c.Key, c.Value));
        }
        #endregion
#else
        #region 模範解答
        private static void Exercise1_1(string text) {
            var dict = new Dictionary<Char, int>();
            foreach (var c in text)
            {
                var uc = char.ToUpper(c);
                if ('A' <= c && c <= 'Z')
                {
                    if (dict.ContainsKey(uc))
                    {
                        dict[uc]++;
                    }
                    else
                    {
                        dict[uc] = 1;
                    }
                }
            }

            foreach (var item in dict.OrderBy(c=>c.Key))        //OrderBy(c=>c)はだめ
            {
                Console.WriteLine("{0}：{1}", item.Key, item.Value);
            }
        }

        private static void Exercise1_2(string text) {
            var dict = new SortedDictionary<Char, int>();
        }
        #endregion
#endif

    }
}
