using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {

#if true

            #region 自力

            var prefOfficeDict = new Dictionary< string , List< CityInfo > >();

            string pref;
            string city;
            int population;

            Console.WriteLine( "県庁所在地の登録" );

            input:

            while ( true )
            {
                        
                Console.Write( "都市：" );
                pref = Console.ReadLine();
                if ( pref == "999" ) break;

                Console.Write( "所在地：" );
                city = Console.ReadLine();

                Console.Write( "人口：" );
                population = int.Parse( Console.ReadLine() );

                //既に県名が登録済みか？
                if ( prefOfficeDict.ContainsKey( pref ) )
                {

                    foreach ( var info in prefOfficeDict[ pref ] )
                    {

                        if ( city.Equals( info.City ) )
                        {

                            Console.WriteLine( "既に市町村名が登録されています。" );
                            Console.Write( "上書きしますか？( y , n )：" );

                            if( Console.ReadLine() == "y" )
                            {
                                info.Population = population;
                            }

                            goto input;

                        }

                    }

                }
                else
                {
                    prefOfficeDict.Add( pref , new List< CityInfo >() );
                }

                //登録処理
                prefOfficeDict[ pref ].Add( 
                new CityInfo
                {
                    City = city ,
                    Population = population ,
                } 
                );

            }

            Console.WriteLine();
            Console.WriteLine( "１：一覧表示 , ２：県名指定" );
            Console.Write( ">" );
            var selected = Console.ReadLine();

            if ( selected == "1" )
            {

                //一覧表示
                foreach ( var list in prefOfficeDict )
                {

                    foreach ( var item in list.Value )
                    {
                        Console.WriteLine( "{0}【 {1} ( 人口：{2} 人 ) 】)" , list.Key , item.City , item.Population );
                    }

                }

            }
            else
            {

                //県名指定表示
                Console.Write( "県名を入力：" );
                var inputPref = Console.ReadLine();

                foreach ( var item in prefOfficeDict[ inputPref ] )
                {
                    Console.WriteLine( "{0} 【 {1} ( 人口：{2} 人 ) 】)", inputPref , item.City , item.Population );
                }


            }

            #endregion

#else

            #region 模範解答

            var prefDict = new Dictionary< string , List< CityInfo > >();

            string pref;
            string city;
            int population;

            Console.WriteLine( "県庁所在地の登録" );
            while ( true )
            {

                Console.Write( "都市：" );
                pref = Console.ReadLine();
                if ( pref == "999" ) break;

                Console.Write( "市町村；" );
                city = Console.ReadLine();

                Console.Write( "人口：" );
                population = int.Parse( Console.ReadLine() );

                //市町村情報インスタンスの作成
                var cityInfo = new CityInfo
                {
                    City = city,
                    Population = population,
                };

                //これは冗長
                ////既に県名が登録済みか？
                //if ( prefDict.ContainsKey( pref ) )
                //{

                //    //Console.WriteLine( "既に県名が登録されています。" );
                //    //Console.Write( "上書きしますか？( y , n )：" );

                //    //if( Console.ReadLine() == "y" )
                //    //{
                //    //    continue;
                //    //}

                //    //List< CityInfo >が存在するため add で市町村データを追加
                //    prefDict[ pref ].Add( cityInfo );

                //}
                //else
                //{

                //    //List< CityInfo >が存在しないため List を作成（new）して市町村データを追加
                //    //prefDict[ pref ] = new List< CityInfo >;      これでもいいが...

                //    prefDict[ pref ] = new List< CityInfo > { cityInfo }; 

                //}

                if ( !prefDict.ContainsKey( pref ) )
                {
                    prefDict[ pref ] = new List< CityInfo >();      //既に県名が未登録ならリスト作成
                }

                prefDict[ pref ].Add( cityInfo );

                //登録処理
                //prefOfficeDict[ pref ] = new CityInfo
                //{
                //    City = city ,
                //    Population = population ,
                //};

            }

            Console.WriteLine();
            Console.WriteLine( "１：一覧表示 , ２：県名指定" );
            Console.Write( ">" );
            var selected = Console.ReadLine();

            //Value がリストでない場合
            //if ( selected == "1" )
            //{



            //    //一覧表示
            //    foreach ( var item in prefDict.OrderByDescending( p => p.Value.Population ) )
            //    {
            //        Console.WriteLine( "{0}【{1}(人口：{2}人)】)" , item.Key , item.Value.City , item.Value.Population );
            //        //Console.WriteLine( item );      //KeyValuePairクラスの表示形式　やっちゃダメ
            //    }

            //}
            //else
            //{

            //    //県名指定表示
            //    Console.Write("県名を入力：");
            //    var inputPref = Console.ReadLine();

            //    Console.WriteLine( "【{0}(人口：{1}人)】)", prefDict[ inputPref ].City , prefDict[ inputPref ].Population );

            //}

            if ( selected == "1" )
            {

                foreach ( var prefData in prefDict )
                {

                    foreach ( var cityData in prefData.Value )
                    {

                        //Console.WriteLine( "【{0}(人口：{1}人)】)" , cityData.Key , cityData.Value.City , cityData.Value.Population );      //Valueいらない
                        Console.WriteLine( "【{0}(人口：{1}人)】)" , prefData.Key , cityData.City , cityData.Population );

                    }

                }

            }
            else
            {

                //県名指定表示
                Console.Write( "県名を入力：" );
                var inputPref = Console.ReadLine();

                foreach ( var cityData in prefDict[ inputPref ] )
                {
                    Console.WriteLine( "{0}【{1}(人口：{2}人)】)" , inputPref , cityData.City , cityData.Population );
                }

                //Console.WriteLine( "【{0}(人口：{1}人)】)" , prefDict[ inputPref ].City , prefDict[ inputPref ].Population );       //間違い　List だし...

            }

            #endregion

#endif

        }

    }

    class CityInfo {        //public はあったほうがいい　コンストラクタでもOK

        public string City { get; set; }           //都市
        public int Population { get; set; }        //人口

    }

}

