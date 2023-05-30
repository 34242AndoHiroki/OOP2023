using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            var ym = new YearMonth(2023,5);     //実行時に参照 DLL
            var c21 = ym.Is21Century;
            var ymNextMonth = ym.AddOneMonth();

            Console.WriteLine(ym);      //〇〇〇〇年△月
                                        //オーバーライドなしだと、Exercise01.YearMonth
            Console.WriteLine(ymNextMonth);      //〇〇〇〇年△月

        }
    }
}
