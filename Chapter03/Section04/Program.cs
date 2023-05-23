using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {

    class Program {

        static void Main(string[] args) {

            var names = new List< string > {

               "Tokyo" , "New Delhi" , "Bangkok" , "London" , "Paris" , "Berlin" , "Canberra" , "Hong Kong" ,

            };

            //var data = names.Find( s => s.Length <= 5 );      //　string型
            //var data = names.FindAll( s => s.Length <= 5 );       // List< string >型
            //var query = names.Where( s => s.Length <= 5 );        //IEnumerable< string >型

            //IEnumerable< string > query = names.Where( s => s.Length <= 5 ).Select( s => s.ToLower() );       //小文字をセレクト

            var query = names.Select( s => s.Length );      //文字列長をセレクト
            //var query = names.Where( s => s.Length );      //条件ではない

            foreach ( var s in names )
            {
                Console.WriteLine( s );
            }

        }

    }

}
