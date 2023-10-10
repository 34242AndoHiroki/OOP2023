#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Exercise05 {
    class Program {
        static void Main(string[] args) {
            TagLower("sample.html");
        }

        private static void TagLower(string file) {
            var lines = File.ReadLines(file);
            var sb = new StringBuilder();

#if Mywork
            #region 自力
            foreach (var line in lines) {
                string v = line;
                foreach (Match tag in Regex.Matches(line, @"<.+?>")) {
                    v = Regex.Replace(v, tag.Value, tag.Value.ToLower());
                }
                sb.Append(v);
            }
            #endregion
#elif Answer
            #region 模範解答
            foreach (var line in lines) {
                var s = Regex.Replace(line,
                    @"<(/?)([A-Z][A-Z0-9])*(.*?)>",       //正規表現
                    m => {      //変換
                        return string.Format("<{0}{1}{2}>",m.Groups[1].Value, m.Groups[2].Value.ToLower(), m.Groups[3].Value);
                    }
                    );
                sb.AppendLine(s);
            }
            #endregion
#endif

            //ファイル出力
            File.WriteAllText(file, sb.ToString());

            var text = File.ReadAllText("sample.html");
            Console.WriteLine(text);
        }
    }
}
