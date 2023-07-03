using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise03 {
#if true
    #region 自力
    class Program {
        static void Main(string[] args) {

            var tw = new TimeWatch();
            tw.Start();
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            Console.WriteLine("処理時間は{0}ミリ秒でした", duration.TotalMilliseconds);

        }
    }

    class TimeWatch {

        DateTime start;

        public void Start() {
            start = DateTime.Now;
        }

        public TimeSpan Stop() => DateTime.Now - start;

    }
    #endregion
#else
    #region 模範解答
    class Program {
        static void Main(string[] args) {
            var tw = new TimeWatch();
            tw.Start();         //スタートするからStart()は必要
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();      //ストップするからStop()は必要　時間差も欲しい
            Console.WriteLine("処理時間は{0}ミリ秒でした",duration.TotalMilliseconds);
        }
    }

    class TimeWatch {

        private DateTime _time;

        public void Start() {
            _time = DateTime.Now;
        }

        public TimeSpan Stop() {
            return DateTime.Now - _time;
        }

    }

    #endregion
#endif

}
