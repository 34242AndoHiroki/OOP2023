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

            Console.WriteLine( c21 );

            Console.WriteLine( ym.AddOneMonth().ToString() );
            Console.WriteLine(ym.AddOneMonth().Is21Century);

        }
    }
}
