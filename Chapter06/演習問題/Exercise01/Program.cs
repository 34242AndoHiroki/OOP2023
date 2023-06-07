using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);

        }
#if !true
        #region 自力
        private static void Exercise1_1(int[] numbers) {
            Console.WriteLine(numbers.Max());
        }

        private static void Exercise1_2(int[] numbers) {
            //一行完結型
            numbers.Reverse().Take(2).ToList().ForEach(Console.WriteLine);

            //利点を生かす
            //var select = numbers.Reverse().Take(2);

            //foreach (var n in select)
            //{
            //    Console.WriteLine(n);
            //}
        }

        private static void Exercise1_3(int[] numbers) {
            //一行完結型
            numbers.Select(n => n.ToString()).ToList().ForEach(Console.WriteLine);

            //利点を生かす
            //var convert = numbers.Select(n => n.ToString());

            //foreach (var n in convert)
            //{
            //    Console.WriteLine(n);
            //}
        }

        private static void Exercise1_4(int[] numbers) {
            numbers.OrderBy(x => x).Take(3).ToList().ForEach(Console.WriteLine);
        }

        private static void Exercise1_5(int[] numbers) {
            Console.WriteLine(numbers.Distinct().Where(x => x > 10).Count());
        }
        #endregion
#else
        #region 模範解答
         private static void Exercise1_1(int[] numbers) {
            var max = numbers.Max();
            Console.WriteLine(max);
        }

        private static void Exercise1_2(int[] numbers) {
            
        }

        private static void Exercise1_3(int[] numbers) {
            
        }

        private static void Exercise1_4(int[] numbers) {
            
        }

        private static void Exercise1_5(int[] numbers) {
            
        }
        #endregion
#endif
    }
}
