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

            //morning glory(あさがお)【250円】を追加

            Console.WriteLine( "ひまわりの価格は{0}円です。" , flowerDict[ "sunflower" ] );     //キー値でバリューを呼び出し
            Console.WriteLine( "チューリップの価格は{0}円です。" , flowerDict[ "tulip" ] );

            flowerDict.Add( "morning glory" , 250 );     //あさがおの追加

            Console.WriteLine( "あさがおの価格は{0}円です。" , flowerDict[ "morning glory" ] );

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

                var prefectures = new Dictionary< string , CityInfo >();
                string name = null;
                string capital = null;
                int population;
                string comment = "";

                Console.WriteLine( "県庁所在地の登録" );

                input:

                while ( true )
                {

                    Console.Write( "県名：" );
                    name = Console.ReadLine();      //県名の入力

                    if ( name == "999" ) break;

                    if( prefectures.ContainsKey( name ) )        //県名がもうある
                    {

                        Console.WriteLine( "既に県名が存在します" );
                        Console.WriteLine( "どうしますか？" );

                        Console.WriteLine( "U:上書き　S:スキップ" );

                        while( true )
                        {

                            Console.Write( ">" );
                            var choice = Console.ReadLine();

                            try
                            {

                                if ( choice == "U" )        //上書き
                                {

                                    Console.WriteLine( name + " の上書きを実行します。" );
                                    comment = "(上書き)";
                                    break;          //次の処理へ

                                }
                                else if( choice == "S" )        //スキップ
                                {

                                    Console.WriteLine( "スキップしました。" );
                                    goto input;

                                }
                                else
                                {
                                    throw new ArgumentException( "定義されていない指定です。" );
                                }

                            }
                            catch( Exception e )
                            {
                                Console.WriteLine( e.Message ); 
                            }
                            
                        }   
                        
                    }

                    //新規登録（上書き）
                    Console.Write( comment + "所在地：" );
                    capital = Console.ReadLine();       //所在地の入力

                    while ( true )
                    {

                        try
                        {

                            Console.Write( comment + "人口：" );
                            population = int.Parse( Console.ReadLine() );       //人口の入力
                            break;

                        }
                        catch ( Exception e )
                        {
                            Console.WriteLine( e.Message );
                        }

                    }

                    prefectures[ name ] = new CityInfo { City = capital , Population = population };
                    comment = "";

                }

                Console.WriteLine( "１：一覧表示 , ２：県名指定" );
                int pattern = int.Parse( Console.ReadLine() );

                switch ( pattern )
                {

                    case 1:         //一覧表示

                        foreach ( var prefecture in prefectures )
                        {
                            Console.WriteLine(" {0}【 {1} ( 人口：{2} 人 ) 】", prefecture.Key , prefecture.Value.City , prefecture.Value.Population );
                        }

                        break;

                    case 2:         //県名指定

                        Console.Write( "県名を入力：" );

                        try
                        {

                            Console.WriteLine( prefectures[ Console.ReadLine() ] + " です" );      //県名の検索

                        }
                        catch ( KeyNotFoundException )
                        {
                            throw new ArgumentException( "県名が見つかりませんでした。" );               
                        }
                        catch ( Exception )
                        {
                            throw new ArgumentException( "エラーが発生しました。" );
                        }

                        break;

                    default:
                        throw new ArgumentException( "数値の指定が不適切です。" );

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
            while ( true )
            {

                Console.Write("県名：");
                pref = Console.ReadLine();
                if ( pref == "999" ) break;

                Console.Write( "所在地；" );
                city = Console.ReadLine();

                //既に県名が登録済みか？
                if ( prefOfficeDict.ContainsKey( pref ) )
                {

                    Console.WriteLine( "既に県名が登録されています。" );
                    Console.Write( "上書きしますか？( y , n )：" );

                    if( Console.ReadLine() == "y" )
                    {
                        continue;
                    }

                }

                prefOfficeDict[ pref ] = city;        //登録処理

            }

            Console.WriteLine();
            Console.WriteLine( "１：一覧表示 , ２：県名指定" );
            Console.Write( ">" );
            var selected = Console.ReadLine();

            if ( selected == "1" )
            {

                //一覧表示
                foreach ( var item in prefOfficeDict )
                {
                    Console.WriteLine( "{0}({1})" , item.Key , item.Value );
                }

            }
            else
            {

                //県名指定表示
                Console.Write("県名を入力：");
                var inputPref = Console.ReadLine();

                Console.WriteLine("{0}です", prefOfficeDict[inputPref]);

            }

            #endregion

#endif

            #endregion

#endif

        }

    }

    class CityInfo {        //public はあったほうがいい　コンストラクタでもOK

        public string City { get; set; }           //都市
        public int Population { get; set; }        //人口

    }

}
