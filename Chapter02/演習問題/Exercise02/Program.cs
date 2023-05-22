using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
#if false
        #region 自力
        static void Main(string[] args) {
            PrintInchToMetarList(1, 10);
        }

        private static void PrintMetarToInchList(int start, int stop) {

            for (int metar = start; metar <= stop; metar++)
            {
                double inch = InchConverter.FromMeter(metar);
                Console.WriteLine("{0} m = {1:0.0000} in", metar, inch);
            }

        }

        private static void PrintInchToMetarList(int start, int stop) {

            for (int inch = start; inch <= stop; inch++)
            {
                double metar = InchConverter.ToMeter(inch);
                Console.WriteLine("{0} in = {1:0.0000} m", inch, metar);
            }

        }
        #endregion
#else
        #region 模範解答
        //DistanceConverterのProgramをコピーして変更
        static void Main(string[] args) {
            if (args.Length < 3)        //引数の数の例外処理　下の共通条件の抽出
            {
                return;     //何もしない
            }

            //こっちのほうがわかりやすい
            int start = int.Parse(args[1]);
            int end = int.Parse(args[2]);
            
            switch (args[0])
            {
                case "-tom":
                    PrintInchToMetarList(start, start);
                    break;

                case "-toi":
                    PrintMetarToInchList(start, start);
                    break;
            }

        }

        private static void PrintInchToMetarList(int start, int stop) {
            for (int inch = start; inch <= stop; inch++)
            {
                double metar = InchConverter.ToMeter(inch);
                Console.WriteLine("{0} ft = {1:0.0000}m", inch, metar);
            }
        }

        private static void PrintMetarToInchList(int start, int stop) {
            for (int metar = start; metar <= stop; metar++)
            {
                double inch = InchConverter.FromMeter(metar);
                Console.WriteLine("{0} ft = {1:0.0000}m", metar, inch);
            }
        }
        #endregion
#endif
    }
}
