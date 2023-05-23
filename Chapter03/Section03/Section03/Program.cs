using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {

    class Program {

        static void Main(string[] args) {

            var list = new List< string > {
               "Tokyo" , "New Delhi" , "Bangkok" , "London" , "Paris" , "Berlin" , "Canberra" , "Hong Kong" ,
            };


            //var exists = list.Exists( s => s[ 0 ] == 'A' );     //いじって確認してみて

            //Console.WriteLine( exists );


            //var name = list.Find( s => s.Length == 6 );

            //Console.WriteLine( name );


            //var index = list.FindIndex( s => s == "Canberra" );

            //Console.WriteLine( index );


            //var names = list.FindAll( s => s.Length <= 5 );

            //names.ForEach( s => Console.WriteLine( s ) );
            //names.ForEach( Console.WriteLine );     //これも上のと同じ


            //Console.WriteLine( names );       // List< string > 型

            //foreach( var name in names )      //
            //{
            //    Console.WriteLine( name );
            //}


            var names = list.ConvertAll( s => s.ToLower() );

            names.ForEach( s => Console.WriteLine( s ) );

        }

    }

}

