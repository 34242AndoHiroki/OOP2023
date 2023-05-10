using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    class Program {

        static FeetConverter fc = new FeetConverter();      //〇

        static void Main(string[] args) {
            //FeetConverter fc = new FeetConverter();       //〇
            if (args.Length >= 1 && args[0] == "-tom")
            {
                //フィートからメートルへの対応表を出力
                PrintFeetToMetarList(1, 10);
            }
            else
            {
                //メートルからフィートへの対応表を出力
                PrintMetarToFeetList(1, 10);
            }
        }

        private static void PrintMetarToFeetList(int start, int stop) {
            //FeetConverter fc = new FeetConverter();       //〇
            for (int metar = 1; metar <= 10; metar++)
            {
                //FeetConverter fc = new FeetConverter();          //for内のnewはだめ
                double feet = fc.FromMeter(metar);
                Console.WriteLine("{0} ft = {1:0.0000}m", metar, feet);
            }
        }

        private static void PrintFeetToMetarList(int start, int stop) {
            for (int feet = 1; feet <= 10; feet++)
            {
                double metar = fc.ToMeter(feet);
                Console.WriteLine("{0} ft = {1:0.0000}m", feet, metar);
            }            
        }
    }
}
