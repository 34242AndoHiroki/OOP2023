using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                 "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            Console.WriteLine("**** 3.1 ****");
            Exercise2_1(names);
            Console.WriteLine("**** 3.2 ****");
            Exercise2_2(names);
            Console.WriteLine("**** 3.3 ****");
            Exercise2_3(names);
            Console.WriteLine("**** 3.4 ****");
            Exercise2_4(names);
        }

#if !false
        #region 自力
        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名を入力。空行で終了");
            var line = Console.ReadLine();
            while (line != "")
            {
                Console.WriteLine(names.FindIndex(s => s.Equals(line)));
                line = Console.ReadLine();
            }
        }

        private static void Exercise2_2(List<string> names) {
            Console.WriteLine(names.Count(s=>s.Contains("o")));  
        }

        private static void Exercise2_3(List<string> names) {
            var array = names.Where(s => s.Contains("o")).ToArray();
            foreach (string s in array) Console.WriteLine(s);

            //names.Where(s => s.Contains("o")).ToArray();
        }

        private static void Exercise2_4(List<string> names) {
            names.Where(s => s.StartsWith("B")).Select(s=>s.Length).ToList().ForEach(Console.WriteLine);
        }
        #endregion
#else
        #region 模範解答
        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名を入力。空行で終了");
            do
            {
                var line = Console.ReadLine();
                //if (city == "") break;        //これでもいい
                if (string.IsNullOrEmpty(line))     //IsNullOrWhiteSpaceでもOK
                    break;

                var index = names.FindIndex(s => s == line);    //names.FindIndex(s => line.Equals(s))もOK
            } while (true);
        }

        private static void Exercise2_2(List<string> names) {
            //var count = names.Where(s => s.Contains('o')).Count();      //抽出はWhereにお任せ　手間
            var count = names.Count(s => s.Contains('o'));      //Count自身に処理を渡して抽出させる
            Console.WriteLine(count);
        }

        private static void Exercise2_3(List<string> names) {
            var selected = names.Where(s => s.Contains('o')).ToArray();
            foreach (var name in names)
                Console.WriteLine(name);
        }

        private static void Exercise2_4(List<string> names) {
            //問題とやってることが違うから×
            //var selected = names.Where(s => s.StartsWith("B"));

            //foreach (var item in selected)
            //    Console.WriteLine("{0},{1}",item,item.Length);

            //正しい
            var selected = names.Where(s => s.StartsWith("B"))
                                .Select(s => new { s, s.Length });      //インスタンスで返却

            foreach (var item in selected)
                Console.WriteLine("{0},{1}", item, item.Length);        //都市名はいらない
        }
        #endregion
#endif
    }
}
