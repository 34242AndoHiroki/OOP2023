using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {

    class Program {

        static void Main(string[] args) {

#if !true

            #region Dictionary参考

            //初期化
            var flowerDict = new Dictionary< string , int >()
            {

                [ "sunflower" ] = 400 ,             // [ キー ] = バリュー
                [ "pansy" ] = 300 ,
                [ "tulip" ] = 350 ,
                [ "rose" ] = 500 ,
                [ "dahila" ] = 450 ,

            };

#if !true

            #region 自力

            //moring glory(あさがお)【250円】を追加

            Console.WriteLine( "ひまわりの価格は{0}円です。" , flowerDict[ "sunflower" ] );     //キー値でバリューを呼び出し
            Console.WriteLine( "チューリップの価格は{0}円です。" , flowerDict[ "tulip" ] );

            flowerDict.Add( "moring glory" , 250 );     //あさがおの追加

            Console.WriteLine( "あさがおの価格は{0}円です。" , flowerDict[ "moring glory" ] );

            #endregion

#else

            #region 模範解答

            //moring glory(あさがお)【250円】を追加
            flowerDict[ "moring glory" ] = 250;     //配列と同じ
            //[ "moring glory" ] = 250;     //{}内での宣言の仕方
            //flowerDict[ 6 ] = 250;        //イメージ（配列）

            Console.WriteLine( "ひまわりの価格は{0}円です。" , flowerDict[ "sunflower" ] );
            Console.WriteLine( "チューリップの価格は{0}円です。" , flowerDict[ "tulip" ] );
            Console.WriteLine( "あさがおの価格は{0}円です。" , flowerDict[ "moring glory" ] );

            #endregion

#endif

            #endregion

#else

            #region 課題

#if true

            #region 自力

            try
            {

                var prefecturs = new Dictionary< string , string >();

                Console.WriteLine( "県庁所在地の登録" );

                Console.Write( "県名：" );
                var name = Console.ReadLine();      //県名の入力

                while ( name != "999" )
                {

                    if( prefecturs.ContainsKey( name ))        //県名がもうある
                    {
                        Console.WriteLine( "既に県名が存在します" );
                    }
                    else        //新規県名
                    {

                        Console.Write( "所在地：" );
                        var capital = Console.ReadLine();       //所在地の入力

                        prefecturs[ name ] = capital;

                    }

                    Console.Write( "県名：" );
                    name = Console.ReadLine();      //県名の入力

                }

                Console.Write( "県名を入力：" );

                try
                {

                    Console.WriteLine( prefecturs[ Console.ReadLine() ] + " です" );      //県名の検索

                }
                catch ( KeyNotFoundException )
                {
                    throw new ArgumentException( "県名が見つかりませんでした。" );               
                }
                catch ( Exception )
                {
                    throw new ArgumentException( "エラーが発生しました。" );
                }

            }
            catch ( Exception e )
            {
                Console.WriteLine( e.Message ); 
            }

            #endregion

#else

            #region 模範解答

            var prefOfficeDict = new Dictionary< string , string >();

            string pref;
            string city;

            Console.WriteLine("県庁所在地の登録");
            Console.Write( "県名：" );
            while ( true )
            {

                pref = Console.ReadLine();
                if ( pref == "999" ) break;

                Console.Write( "所在地；" );
                city = Console.ReadLine();

                prefOfficeDict[ pref ] = city;

                Console.Write( "県名：" );

            }

            Console.Write( "県名を入力：" );
            var inputPref = Console.ReadLine();

            Console.WriteLine( "{0}です" , prefOfficeDict[ inputPref ] );

            #endregion

#endif

            #endregion

#endif

        }

    }

}
