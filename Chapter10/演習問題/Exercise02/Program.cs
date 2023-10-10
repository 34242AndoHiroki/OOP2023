//#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            Pickup3DigitNumber("sample.txt");
        }

#if Mywork
        #region 自力
        private static void Pickup3DigitNumber(string file) {
            //var result = new List<MatchCollection>();     //保存用

            foreach (var line in File.ReadLines(file)) {        //行ごと

                //result.Add(Regex.Matches(line, @"\d{3,}"));       //保存用

                foreach (var match in Regex.Matches(line,@"\b\d{3,}\b")) {
                    Console.WriteLine(match);
                }

            }
        }
        #endregion
#elif Answer
        #region 模範解答
        private static void Pickup3DigitNumber(string file) {
            foreach (var line in File.ReadLines(file)) {        //デバックかけて動作確認してみること
                var matches = Regex.Matches(line,@"\b\d{3,}\b");        // Split() は必要ない
                //var matches = Regex.Matches(line,@"\d");        //数字がいっぱい出てくる
                //var matches = Regex.Matches(line,@"\d+");       //含まれる数字が出てくる

                foreach (Match m in matches) {
                    Console.WriteLine(m.Value);
                }

            }
        }
        #endregion
#endif



    }
}
