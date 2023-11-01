#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.ConcreteConverter {
#if Mywork
    class KiloMeterConverter : Framework.ConverterBase {
        public override bool IsMyUnit(string name) {
            return name.ToLower() == "kilometer" || name == UnitName;
        }
        protected override double Ratio { get { return 1000.000; } }            //ゲッター
        public override string UnitName { get { return "キロメートル"; } }
    }
#elif Answer
#endif
}
