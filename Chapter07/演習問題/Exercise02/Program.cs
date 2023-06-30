using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
#if !true
            #region 自力
            var abbrs = new Abbreviations();

            //7.2.3
            abbrs.Add("NGO", "非政府組織");
            Console.WriteLine(abbrs.Count);
            abbrs.Add("NPO", "非営利組織");
            Console.WriteLine(abbrs.Count);
            abbrs.Remove("UNICEF");
            Console.WriteLine(abbrs.Count);
            abbrs.Remove("PPAP");
            Console.WriteLine(abbrs.Count);


            //7.2.4
            //即時実行
            abbrs.Where(a => a.Key.Length <= 3).ToList().ForEach(a => Console.WriteLine("{0}={1}", a.Key, a.Value));

            //遅延実行
            //var selected = abbrs.Where(a => a.Key.Length == 3);

            //foreach (var item in selected)
            //{
            //    Console.WriteLine("{0}={1}", item.Key, item.Value);
            //}
            #endregion
#else
            #region 模範解答
            //コンストラクタの呼び出し
            var abbrs = new Abbreviations();

            //Addメソッドの呼び出し
            abbrs.Add("IOC","国際オリンピック委員会");
            abbrs.Add("NPT", "核拡散防止条約");

            // 7.2.3
            // 上のAddメソッドで、２つのオブジェクトを追加しているので、
            // 読み込んだ単語数 + 2 が、Countの値になる。

            //int count = abbrs.Count;        //()なしはプロパティ
            Console.WriteLine(abbrs.Count);
            Console.WriteLine();

            // 7.2.3（Removeの呼び出し）
            if (abbrs.Remove("NPT"))
                Console.WriteLine(abbrs.Count);
            if (!abbrs.Remove("NPT"))
                Console.WriteLine("削除できません");
            Console.WriteLine();


            // 7.2.4
            // IEnumerable<> を実装したので、LINQが使える

            //全件取得
            //foreach (var item in abbrs)
            //{
            //    Console.WriteLine("{0}={1}",item.Key,item.Value);
            //}

            foreach (var item in abbrs.Where(abb => abb.Value.Length == 3))
            {
                Console.WriteLine("{0}={1}",item.Key,item.Value);
            }

            #endregion
#endif
        }
    }
}
