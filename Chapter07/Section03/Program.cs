using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {

    class Program {

        static void Main(string[] args) {

            //ドライバ
            //new Abbreviations();        //動きの確認

            var abbrs = new Abbreviations();

            abbrs.Add( "IOC" , "国際オリンピック委員会" );
            abbrs.Add( "NPT" , "核兵器不拡散条約" );        //核拡散防止条約？

            //インデクサの利用例
            var names = new[] { "WHO" , "FIFA" , "NPT" };

            foreach ( var name in names )
            {

                var fullname = abbrs[ name ];

                if( fullname == null )
                    Console.WriteLine( "{0}は見つかりません" , name );
                else
                    Console.WriteLine( "{0} = {1}" , name , fullname );

            }

            Console.WriteLine();        //改行

            //ToAbbreviationsメソッドの利用例
            var japanese = "東南アジア諸国連合";
            var abbreviation = abbrs.ToAbbreviation( japanese );

            if( abbreviation == null )
                    Console.WriteLine( "{0}は見つかりません" , japanese );
            else
                Console.WriteLine( "{0} = {1}" , japanese , abbreviation );

            Console.WriteLine();        //改行

            //FindAllメソッドの利用例
            foreach ( var item in abbrs.FindAll( "国際" ) )
            {
                Console.WriteLine( "{0} = {1}" , item.Key , item.Value );
            }

            Console.WriteLine();        //改行

        }

    }

}
