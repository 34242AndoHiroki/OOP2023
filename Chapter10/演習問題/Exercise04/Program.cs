//#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            var lines = File.ReadAllLines("sample.txt");

#if Mywork
            #region 自力
            var str = new List<string>();
            foreach (var line in lines) {
                str.Add(Regex.Replace(line, @"[V|v]ersion\s*=\s*""v4.0""", "version=\"v5.0\""));
            }

            //書き込み
            File.WriteAllLines("sample.txt",str);

            //lines.ToList().ForEach(x=>Regex.Replace(x, @"[V|v]ersion\s*=\s*v4.0", "version=v5.0"));
            //File.WriteAllLines("sample.txt", lines);
            #endregion
#elif Answer
            #region 模範解答
            var newline = lines
                .Select(s=>Regex.Replace(s,@"\b(V|v)ersion\s*=\s*""v4.0""", @"version=""v5.0"""));
                //.Select(s=>Regex.Replace(s,@"\b[Vv]ersion\s*=\s*""v4.0""", @"version=""v5.0"""));       //[] でも OK　どっちでもいい

            //書き込み
            File.WriteAllLines("sample.txt", newline);
            #endregion
#endif
            // これ以降は確認用
            var text = File.ReadAllText("sample.txt");
            Console.WriteLine(text);
        }
    }
}
