using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
#if !true
        #region 自力
        static void Main(string[] args) {

            var now = DateTime.Now;
            var date = new DateTime(2017, 4, 30);

            foreach (var dow in Enum.GetValues(typeof(DayOfWeek)))
            {
                var nextNowDay = NextDay(now, (DayOfWeek)dow);
                var nowStr = string.Format("{0:yyyy/MM/dd(ddd)}", nextNowDay);
                Console.WriteLine(nowStr);
            }

            foreach (var dow in Enum.GetValues(typeof(DayOfWeek)))
            {
                var nextDay = NextDay(date, (DayOfWeek)dow);
                var dateStr = string.Format("{0:yyyy/MM/dd(ddd)}", nextDay);
                Console.WriteLine(dateStr);
            }

        }

        public static DateTime NextDay(DateTime date , DayOfWeek dayOfWeek) {
            return date.AddDays(7 + (int)dayOfWeek - (int)(date.DayOfWeek));
        }
        #endregion
#else
        #region 模範解答
        static void Main(string[] args) {

            //列挙型をとってくる方法
            //foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek)))
            //{
            //    Console.WriteLine(dayofweek);
            //}

            var dt = DateTime.Now;

            //出力の考え方（模索的）
            //Console.WriteLine(dt);      //2023/07/03 14:07:44
            //Console.WriteLine("{0} {1}",dt.Year , dt.Month);     //2023 7
            //Console.WriteLine("{0:yyyy/MM/dd}",dt);     //2023/07/03
            //Console.WriteLine("{0:yyyy/MM/dd(ddd)}", dt);       //2023/07/03(月)

            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine("{0:yy/MM/dd}の次週の{1}", dt, dayofweek);        //キャスト不要
                Console.WriteLine("{0:yy/MM/dd}", NextWeek(dt, (DayOfWeek)dayofweek));      //キャスト必要
            }


        }

        public static DateTime NextWeek(DateTime date, DayOfWeek dayOfWeek) {
            var nextweek = date.AddDays(7);     //1週間後
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);      //1週間後の曜日の調整
            //if (days <= 0) days += 7;     //いらない
            return nextweek.AddDays(days);
        }
        #endregion
#endif

    }
}
