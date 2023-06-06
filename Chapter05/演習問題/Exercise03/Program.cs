using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {

            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);

        }
#if !true
        #region 自力
        private static void Exercise3_1(string text) {
            Console.WriteLine("文字数：" + text.Count(c => c == ' '));
        }

        private static void Exercise3_2(string text) {
            Console.WriteLine(text.Replace("big", "small"));
        }

        private static void Exercise3_3(string text) {
            //Console.WriteLine("単語数：" + (text.Count(c => c == ' ') + 1));
            Console.WriteLine("単語数：" +  text.Split(' ').Length);
        }

        private static void Exercise3_4(string text) {
            text.Split(' ').Where(s => s.Length <= 4).ToList().ForEach(Console.WriteLine);
        }

        private static void Exercise3_5(string text) {
            var words = text.Split(' ');
            var sb = new StringBuilder();

            foreach( var word in words )
            {
                sb.Append(word + ' ');
            }

            //Trim() は上書きしないから sb の意味がなくなるかも
            Console.WriteLine(sb.ToString().Trim());        //おおもとの書き換えはなし

            //var replaced = sb.ToString().Trim();        //変換後を保持
            //Console.WriteLine(replaced);

            //ほかの方法
            /*
            var words = text.Split(' ');
            var sb = new StringBuilder(words[0]);
            for (int i = 1; i < words.Length; i++)
            {
                sb.Append(words[i] + ' ');
            }

            Console.WriteLine(sb.ToString());
            */

        }
        #endregion
#else
        #region 模範解答
        private static void Exercise3_1(string text) {

            //int spaces = text.Count();      //37　文字列長

            int spaces = text.Count(c => c == ' ');     //s より c が好ましい
            Console.WriteLine("空白数：{0}", spaces);

            //これでもいけないことはないけどやめて
            //int count = 0;
            //foreach (var str in text)
            //{
            //    if(str == ' ')
            //    {
            //        count++;
            //    }
            //}
        }

        private static void Exercise3_2(string text) {
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3_3(string text) {
            var count = text.Split(' ').Length;        //配列の要素数が返ってくる。Length はプロパティ
            //var count = text.Split(' ').Count();        //Count() だと処理が走って遅くなる
            Console.WriteLine("単語数：{0}", count);
        }

        private static void Exercise3_4(string text) {
            var words = text.Split(' ').Where(word => word.Length <= 4);

            //一行完結型　ここまでやらなくていい
            //var words = text.Split(' ').Where(word => word.Length <= 4).ToList();
            //words.ForEach(Console.WriteLine);

            foreach (var word in words)
                Console.WriteLine(word);
        }

        private static void Exercise3_5(string text) {
            var array = text.Split(' ').ToArray();      //後で変更がないように ToArray() で即時実行してる

            //一応完成
            //var sb = new StringBuilder();       //ストリングビルダー生成
            //foreach (var word in array)
            //{
            //    sb.Append(word);
            //    sb.Append(' ');
            //    //sb.Append(word + ' ');        //これもアリ
            //}
            //var createWords = sb.ToString();
            //Console.WriteLine(createWords);

            if(array.Length > 0)        //ガード処理。sbの不要なインスタンス生成を阻止
            {
                var sb = new StringBuilder(array[0]);
                foreach (var word in array.Skip(1))     //要素番号1番を飛ばし
                {
                    sb.Append(' ');
                    sb.Append(word);
                }
                var createWords = sb.ToString();
                Console.WriteLine(createWords);
            }
        }
        #endregion
#endif        
    }
}
