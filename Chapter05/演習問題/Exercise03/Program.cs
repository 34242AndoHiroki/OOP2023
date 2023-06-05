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
#if true
        #region 自力
        private static void Exercise3_1(string text) {
            Console.WriteLine("文字数：" + text.Count(c => c == ' '));
        }

        private static void Exercise3_2(string text) {
            Console.WriteLine(text.Replace("big", "small"));
        }

        private static void Exercise3_3(string text) {
            Console.WriteLine("単語数：" + (text.Count(c => c == ' ') + 1));
        }

        private static void Exercise3_4(string text) {
            text.Split(' ').Where(s => s.Length <= 4).ToList().ForEach(Console.WriteLine);
        }

        private static void Exercise3_5(string text) {
            var words = text.Split(' ');
            var sb = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                sb.Append(words[i]);
                if (i != words.Length - 1) sb.Append(" ");
            }

            Console.WriteLine(sb.ToString());
            
        }
        #endregion
#else
        #region 模範解答
        private static void Exercise3_1(string text) {

            //これでもいけないことはないけどやめて
            int count = 0;
            foreach (var str in text)
            {
                if(str == ' ')
                {
                    count++;
                }
            }
        }

        private static string Exercise3_2(string text) {
            return text.Replace("big","small");
        }

        private static string Exercise3_3(string text) {
            return "単語数" + Exercise3_1(text) + 1;
        }

        private static void Exercise3_4(string text) {
             text.Split(' ').Where(s => s.Length <= 4).ToList().ForEach(Console.WriteLine);
        }

        private static void Exercise3_5(string text) {
            var words = text.Split(' ').ToArray();
            var sb = new StringBuilder(words[1]);

            for (int i = 1; i < words.Length; i++)
            {
                sb.Append(" ");
                sb.Append(words[1]);
            }

            Console.WriteLine(sb.ToString());
            
        }
        #endregion
#endif        
    }
}
