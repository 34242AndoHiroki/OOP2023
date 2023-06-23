﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {

#if true

            #region 自力

            var prefOfficeDict = new Dictionary< string , CityInfo >();

            string pref;
            string city;
            int population;

            Console.WriteLine( "県庁所在地の登録" );
            while ( true )
            {

                Console.Write( "都市：" );
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

#else

            #region 模範解答

            var prefOfficeDict = new Dictionary< string , CityInfo >();

            string pref;
            string city;
            int population;

            Console.WriteLine( "県庁所在地の登録" );
            while ( true )
            {

                Console.Write( "都市：" );
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

        }

    }

    class CityInfo {        //public はあったほうがいい　コンストラクタでもOK

        public string City { get; set; }           //都市
        public int Population { get; set; }        //人口

    }

}

