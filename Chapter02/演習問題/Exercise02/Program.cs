using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {

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

    }
}
