using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {

    abstract class GreetingBase {           // abstract で抽象化

        public virtual string GetMessage() {        // virtual で抽象化クラスのメソッド宣言
            return "";
        }

        //public abstract string GetMessage();      //実装しないと怒られるタイプ

    }

}
