//#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var texts = new[] {
               "Time is money.",
               "What time is it?",
               "It will take time.",
               "We reorganized the timetable.",
            };

#if Mywork
            #region 自力
            foreach (var text in texts) {
                if (Regex.IsMatch(text, @"\b[T|t]ime\b")) {
                    Console.WriteLine("{0}：{1}",text,Regex.Match(text, @"[T|t]ime").Index);
                }
            }
            #endregion
#elif Answer
            #region 模範解答
            // Exercise02 とほとんど同じ
            foreach (var line in texts) {
                var matches = Regex.Matches(line,@"\btime\b",RegexOptions.IgnoreCase);
                //var matches = Regex.Matches(line,@"\b(T|t)ime\b");
                foreach (Match m in matches) {
                    Console.WriteLine("{0}：{1}",line,m.Index);
                }
            }
            #endregion
#endif


        }
    }
}
