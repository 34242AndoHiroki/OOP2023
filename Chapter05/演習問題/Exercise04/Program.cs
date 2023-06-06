//#define NonArray
#define StringArray

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {

#if true

    #region 自力
        static void Main(string[] args) {

            Stopwatch sw = new Stopwatch();     //タイマーインスタンス生成
            sw.Start();     //タイマースタート

            string[][] tags = {
                new[] { "Novelist", "作者　" },        //{ before , after }
                new[] { "BestWork", "代表作" },
                new[] { "Born", "誕生年" },
            };

    #if NonArray
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

            var informations = line.Split(';');

            var list = new List<string[]>();

            foreach (string information in informations)
            {
                list.Add(information.Split('='));
            }

            foreach (string[] tag in tags)
            {
                foreach (string[] words in list)
                {
                    if(words[0] == tag[0])
                    {
                        Console.WriteLine("{0}：{1}",tag[1],words[1]);
                        break;
                    }
                }
            }
    #elif StringArray
            string[] lines =
            {
                "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886",
                "Novelist=夏目漱石;BestWork=坊ちゃん;Born=1867",
                "Novelist=太宰治;BestWork=人間失格;Born=1909",
                "Novelist=宮沢賢治;BestWork=銀河鉄道の夜;Born=1896",
            };

            var list = new List<string[]>();

            foreach(var line in lines)
            {
                list.Add(line.Split(';'));
            }

            foreach (var line in list)
            {
                Console.WriteLine(line[0].Replace("Novelist=", "作者　："));
                Console.WriteLine(line[1].Replace("BestWork=", "代表作："));
                Console.WriteLine(line[2].Replace("Born=", "誕生年："));
            }
#endif
            Console.WriteLine("実行時間 = {0}", sw.Elapsed.ToString(@"ss\.ffff"));        //時間表示
        }
        #endregion

#else

        #region 模範解答
        static void Main(string[] args) {
            Stopwatch sw = new Stopwatch();     //タイマーインスタンス生成
            sw.Start();     //タイマースタート

#if NonArray
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
#elif StringArray
            string[] lines =
            {
                "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886",
                "Novelist=夏目漱石;BestWork=坊ちゃん;Born=1867",
                "Novelist=太宰治;BestWork=人間失格;Born=1909",
                "Novelist=宮沢賢治;BestWork=銀河鉄道の夜;Born=1896",
            };
#endif

#if NonArray
            //var pair = line.Split(';');       // ; で区切る

            foreach (var pair in line.Split(';'))
            {
                var array = pair.Split('=');
                Console.WriteLine("{0}：{1}",ToJapanese(array[0]),array[1]);
            }
#elif StringArray
            foreach (var line in lines)
            {
                foreach (var pair in line.Split(';'))
                {
                    var array = pair.Split('=');
                    Console.WriteLine("{0}：{1}", ToJapanese(array[0]), array[1]);
                }

            }
#endif
            Console.WriteLine("実行時間 = {0}" , sw.Elapsed.ToString(@"ss\.ffff"));        //時間表示
        }

        static string ToJapanese(string key) {
            switch (key)
            {
                case "Novelist":
                    return "作家　";
                case "BestWork":
                    return "代表作";
                case "Born":
                    return "誕生年";
                //default :
                //    return "引数エラー";       //エラーじゃないエラー　テキスト
            }
            throw new ArgumentException("正しい引数ではありません");        //エラーを投げる
        }
        #endregion

#endif
    }
}
