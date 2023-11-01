//#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise01 {

#if Mywork
    class ToHankakuProcessor : TextProcessor{

        List<string> lines = new List<string>();

        protected override void Initialize(string fname) {
            
        }

        protected override void Execute(string line) {

            var s = line;

            var chars = Regex.Matches(line, @"[０-９]");

            foreach (var c in chars) {
                s = Regex.Replace(s,c.ToString(),_dictionary[c.ToString().First()].ToString());
            }

            lines.Add(s);
        }

        protected override void Terminate() {
            foreach (var line in lines) {
                Console.WriteLine(line);
            }
        }

        private static Dictionary<char, char> _dictionary =
            new Dictionary<char, char>
            {
                {'０','0'},{'１','1'},{'２','2'},{'３','3'},{'４','4'},
                {'５','5'},{'６','6'},{'７','7'},{'８','8'},{'９','9'},
            };

    }

    
#elif Answer
    class ToHankakuProcessor : TextProcessor {

        private static Dictionary<char, char> _dictionary =
            new Dictionary<char, char>
            {
                {'０','0'},{'１','1'},{'２','2'},{'３','3'},{'４','4'},
                {'５','5'},{'６','6'},{'７','7'},{'８','8'},{'９','9'},
            };

        protected override void Execute(string line) {
            var s = Regex.Replace(line, "[０-９]", c => _dictionary[c.Value[0]].ToString());
            //var s = Regex.Replace(line,"[０-９]",c=>_dictionary[c.Value['２']].ToString());      //２ なら 2 に変換する
            Console.WriteLine(s);

            //foreach は工夫が必要
            //foreach (var number in _dictionary) {
            //    var s = Regex.Replace(line, "[０-９]", c => _dictionary[c.Value[0]].ToString());

            //}
        }

        protected override void Terminate() {
            //Console.WriteLine(s);     //フィールドに宣言すれば表示可能
        }

    }
#endif
}
