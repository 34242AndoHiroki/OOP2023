﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {

    class Program {

        static void Main(string[] args) {

            var greetings = new List< IGreeting >()      //親クラスですべてが入るようにしている
            {
                new GreetingMorning() ,
                new GreetingAfternoon() ,
                new GreetingEvening() ,
            };

            foreach ( var obj in greetings ) {

                string msg = obj.GetMessage();
                Console.WriteLine( msg );

                //Console.WriteLine( obj.GetMessage() );

            }

        }

    }

}
