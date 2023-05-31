using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
#if true
        #region 自力
        static void Main(string[] args) {
            var yearMontm = new YearMonth(2023, 5);     //実行時に参照 DLL
            var c21 = yearMontm.Is21Century;
            var ymNextMonth = yearMontm.AddOneMonth();

            Console.WriteLine(yearMontm);      //〇〇〇〇年△月
                                               //オーバーライドなしだと、Exercise01.YearMonth
            Console.WriteLine(ymNextMonth);      //〇〇〇〇年△月

            // 4.2.1
            var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2020, 12),
            };

            // 4.2.2
            Console.WriteLine("\n- 4.2.2 ---");
            Exercise2_2(ymCollection);
            Console.WriteLine("\n- 4.2.4 ---");

            // 4.2.4
            Exercise2_4(ymCollection);
            Console.WriteLine("\n- 4.2.5 ---");


            // 4.2.5
            Exercise2_5(ymCollection);

        }

        private static void Exercise2_2(YearMonth[] ymCollection) {
            ymCollection.ToList().ForEach(ym => Console.WriteLine(ym));
        }

        //4.2.3
        static YearMonth FindFirst21C(YearMonth[] ymCollection) {
            return ymCollection.ToList().Find(ym => ym.Is21Century);
        }

        private static void Exercise2_4(YearMonth[] ymCollection) {
            Console.WriteLine(FindFirst21C(ymCollection).ToString() ?? "21世紀のデータはありません");
        }

        private static void Exercise2_5(YearMonth[] ymCollection) {
            var OneMonthLater = ymCollection.Select(ym => ym.AddOneMonth()).ToArray();
            OneMonthLater.ToList().ForEach(oml => Console.WriteLine(oml));
        }

        #endregion
#else
        #region 模範解答
        static void Main(string[] args) {

            var ym = new YearMonth(2023, 5);     //実行時に参照 DLL
            var c21 = ym.Is21Century;
            var ymNextMonth = ym.AddOneMonth();

            Console.WriteLine(ym);      //〇〇〇〇年△月
                                        //オーバーライドなしだと、Exercise01.YearMonth
            Console.WriteLine(ymNextMonth);      //〇〇〇〇年△月

            // 4.2.1
            var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2020, 12),
            };

            // 4.2.2
            Console.WriteLine("\n- 4.2.2 ---");
            Exercise2_2(ymCollection);
            Console.WriteLine("\n- 4.2.4 ---");

            // 4.2.4
            Exercise2_4(ymCollection);
            Console.WriteLine("\n- 4.2.5 ---");


            // 4.2.5
            Exercise2_5(ymCollection);

        }

        private static void Exercise2_2(YearMonth[] ymCollection) {
            throw new NotImplementedException();
        }

        private static YearMonth FindFirst21C(YearMonth[] ymCollection) {
            foreach (var ym in ymCollection)
            {
                if (ym.Is21Century == true)
                {
                    return ym;      //〇
                }
                else
                {
                    return null;    //〇
                }
            }
        }

        private static void Exercise2_4(YearMonth[] ymCollection) {
            throw new NotImplementedException();
        }

        private static void Exercise2_5(YearMonth[] ymCollection) {
            throw new NotImplementedException();
        }
        #endregion
#endif

    }
}
