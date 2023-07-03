using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            var dateTime = new DateTime(2019, 1, 15, 19, 48, 32);
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
            DisplayDatePattern3_2(dateTime);

        }

#if !true
        #region 自力
        private static void DisplayDatePattern1(DateTime dateTime) {        // ヒント：P.208
            //2019/1/15 19:48
            Console.WriteLine(dateTime.ToString("g"));

        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            //2019年01月15日 19時48分32秒
            Console.WriteLine(dateTime.ToString("D") + dateTime.ToString(" HH時mm分ss秒"));
        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            //平成31年 1月15日(火曜日)
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            Console.WriteLine(dateTime.ToString("ggyy年 M月d日(dddd)",culture));
        }

        private static void DisplayDatePattern3_2(DateTime dateTime) {

        }
        #endregion
#else
        #region 模範解答
        private static void DisplayDatePattern1(DateTime dateTime) {
            //2019/1/15 19:48
            var str = string.Format("{0:yyyy/MM/dd HH:mm}",dateTime);
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            //2019年01月15日 19時48分32秒
            var str = dateTime.ToString("yyyy年MM月dd日 HH時mm分ss秒");
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            //平成31年 1月15日(火曜日)
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var datestr = dateTime.ToString("ggyy", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);

            var str = string.Format("{0}年{1,1}月{2,2}日({3})",datestr,dateTime.Month, dateTime.Day, dayOfWeek);
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern3_2(DateTime dateTime) {      //DisplayDatePattern3 の別のやり方
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var dateStr = dateTime.ToString("ggyy年 M月d日(dddd)", culture);
            //ゼロサプレスを実施（不要なゼロを取り除く）
            var str = Regex.Replace(dateStr, @"0(\d)", "$1");
            Console.WriteLine(str);
        }
        #endregion
#endif

    }
}
