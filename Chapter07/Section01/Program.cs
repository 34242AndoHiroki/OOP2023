﻿using System;
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
            //応用編

            //ToDictionary() 
            List< CityInfo > list = new List< CityInfo >();
            var ciDict = list.ToDictionary( ci => ci.Population );      //引数をキーにしてディクショナリにできる



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
                int pattern;
                string target;

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

                while ( true )
                {

                    try
                    {

                        Console.Write( ">" );
                        pattern = int.Parse( Console.ReadLine() );
                        break;

                    }
                    catch ( Exception e )
                    {
                        Console.WriteLine( e.Message );
                    }

                }

                switch ( pattern )
                {

                    case 1:         //一覧表示

                        Console.WriteLine( "表示形式\n0：デフォルト　1：人口の降順　2：名前順" );

                        while ( true )
                        {

                            try
                            {

                                Console.Write( ">" );
                                pattern = int.Parse( Console.ReadLine() );
                                break;

                            }
                            catch ( Exception e )
                            {
                                Console.WriteLine( e.Message );
                            }

                        }

                        switch ( pattern )
                        {

                            case 0:

                                foreach ( var prefecture in prefectures )
                                {
                                    Console.WriteLine(" {0}【 {1} ( 人口：{2} 人 ) 】", prefecture.Key , prefecture.Value.City , prefecture.Value.Population );
                                }

                                break;

                            case 1:

                                prefectures.OrderByDescending( n => n.Value.Population ).ToList().ForEach( p => Console.WriteLine( " {0}【 {1} ( 人口：{2} 人 ) 】", p.Key , p.Value.City , p.Value.Population ) );
                                break;

                            case 2:

                                //prefectures.OrderByDescending( n => n.Value.Population ).ToList().ForEach( p => Console.WriteLine( " {0}【 {1} ( 人口：{2} 人 ) 】", p.Key , p.Value.City , p.Value.Population ) );
                                break;

                            default:
                                throw new ArgumentException( "数値の範囲外です。" );
                                
                        }

                        break;

                    case 2:         //県名指定

                        try
                        {

                            Console.Write( "県名を入力：" );
                            target = Console.ReadLine();

                            Console.WriteLine("【 {0} ( 人口：{1} 人 ) 】" , prefectures[ target ].City , prefectures[ target ].Population );      //県名の検索

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
                        throw new ArgumentException( "数値の範囲外です。" );

                }

            }
            catch ( Exception e )
            {
                Console.WriteLine( e.Message ); 
            }

            #endregion

#else

            #region 模範解答

            var prefOfficeDict = new Dictionary< string , CityInfo >();

            string pref;
            string city;
            int population;

            Console.WriteLine("県庁所在地の登録");
            while ( true )
            {

                Console.Write("県名：");
                pref = Console.ReadLine();
                if ( pref == "999" ) break;

                Console.Write( "所在地；" );
                city = Console.ReadLine();

                Console.Write( "人口：" );
                population = int.Parse( Console.ReadLine() );

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

                //登録処理
                prefOfficeDict[ pref ] = new CityInfo
                {
                    City = city ,
                    Population = population ,
                };

            }

            Console.WriteLine();
            Console.WriteLine( "１：一覧表示 , ２：県名指定" );
            Console.Write( ">" );
            var selected = Console.ReadLine();

            if ( selected == "1" )
            {



                //一覧表示
                foreach ( var item in prefOfficeDict.OrderByDescending( p => p.Value.Population ) )
                {
                    Console.WriteLine( "{0}【{1}(人口：{2}人)】)" , item.Key , item.Value.City , item.Value.Population );
                    //Console.WriteLine( item );      //KeyValuePairクラスの表示形式　やっちゃダメ
                }

            }
            else
            {

                //県名指定表示
                Console.Write("県名を入力：");
                var inputPref = Console.ReadLine();

                Console.WriteLine( "【{0}(人口：{1}人)】)", prefOfficeDict[ inputPref ].City , prefOfficeDict[ inputPref ].Population );

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
