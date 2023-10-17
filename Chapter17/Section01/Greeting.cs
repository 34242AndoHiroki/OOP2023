using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {

    class GreetingMorning : GreetingBase {       // GreetingBase を継承

        public string Getmessage() {
            return "おはよう";
        }

    }

    class GreetingAfternoon : GreetingBase {

        public string Getmessage() {
            return "こんにちは";
        }

    }

    class GreetingEvening : GreetingBase {

        public string Getmessage() {
            return "こんばんは";
        }

    }


}
