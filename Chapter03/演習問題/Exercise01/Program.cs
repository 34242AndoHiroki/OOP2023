using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            // 3.1.1
            Exercise1_1(numbers);
            Console.WriteLine("-----");

            // 3.1.2
            Exercise1_2(numbers);
            Console.WriteLine("-----");

            // 3.1.3
            Exercise1_3(numbers);
            Console.WriteLine("-----");

            // 3.1.4
            Exercise1_4(numbers);
        }
#if true
        #region 自力
        private static void Exercise1_1(List<int> numbers) {
            //Console.WriteLine(numbers.Exists(n => n % 8 == 0 || n % 9 == 0) ? "存在しています" : "存在していません");
        }

        private static void Exercise1_2(List<int> numbers) {
            numbers.ForEach(n => Console.WriteLine(n / 2.0));
        }

        private static void Exercise1_3(List<int> numbers) {
            numbers.Where(n => n >= 50).ToList().ForEach(n => Console.WriteLine(n));
        }

        private static void Exercise1_4(List<int> numbers) {
            List<int> list = numbers.Select(n=>n*2).ToList();
            list.ForEach(n => Console.WriteLine(n));

            //numbers.Select(n => n * 2).ToList().ForEach(n => Console.WriteLine(n));
        }
        #endregion
#else
        #region 模範解答
        private static void Exercise1_1(List<int> numbers) {

            var exist = numbers.Exists(n => n % 8 == 0 ||n % 9 == 0);       // -> :アロー演算子　ポインターのやつ
            if (exist)
                Console.WriteLine("存在しています");
            else
                Console.WriteLine("存在していません");

        }

        private static void Exercise1_2(List<int> numbers) {
            numbers.ForEach(s => Console.WriteLine(s / 2.0));

            //var datas = numbers.Select(n => n / 2.0);
            //foreach(var item in datas)
            //{
            //    Console.WriteLine(item + " ");
            //}
        }

        private static void Exercise1_3(List<int> numbers) {
            //var datas = numbers.Where(n => n >= 50);
            //foreach(var item in datas)
            //{
            //    Console.WriteLine(item + " ");
            //}

            //foreach (var item in numbers.Where(n => n >= 50))       //慣れたらこっちでやろう
            //{
            //    Console.WriteLine(item + " ");
            //}

            numbers.Where(n => n >= 50).ToList().ForEach(Console.WriteLine);     //1行で
        }

        private static void Exercise1_4(List<int> numbers) {
            //var list = numbers.Select(n => n * 2).ToList();        //List<int>のキャストはできない
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item + " ");
            //}

            numbers.Select(n => n * 2).ToList().ForEach(Console.WriteLine);     //1行で
        }
        #endregion
#endif
    }
}

