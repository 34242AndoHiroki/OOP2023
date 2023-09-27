﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section04 {

    class Program {

        static void Main( string[] args ) {

            //OpenReadSample();

            var results = GetWeatherReportFromYahoo( 4610 );        //4610:横浜      4210:前橋     4620:小田原

            foreach ( var s in results ) {
                Console.WriteLine( s );
            }

            Console.WriteLine();

        }

        //List 14-18
        private static void OpenReadSample() {

            var wc = new WebClient();       //非推奨らしい HttpClient をお勧めしてるらしい

            using ( var stream = wc.OpenRead( @"http://gihyo.jp/book/list" ) )     //逐語的リテラル

            using ( var sr = new StreamReader( stream , Encoding.UTF8 ) ) {

                string html = sr.ReadToEnd();
                Console.WriteLine( html );

            }

        }

        //List 14-19
        private static IEnumerable< string > GetWeatherReportFromYahoo( int cityCode ) {        //yieldだと戻り値は int か IEnumerable<>

            using ( var wc = new WebClient() ) {

                wc.Headers.Add( "Content-type" , "charset=UTF-8" );
                var uriString = string.Format( @"https://news.yahoo.co.jp/rss/topics/it.xml", cityCode );     // URLを変えるといろいろ変わる
                var url = new Uri( uriString );
                var stream = wc.OpenRead( url );

                XDocument xdoc = XDocument.Load( stream );
                var nodes = xdoc.Root.Descendants( "title" );       //タイトルとってくる

                foreach ( var node in nodes ) {         //ここで解析

                    string s = Regex.Replace( node.Value , "【|】" , "" );
                    yield return node.Value;        //yield: １行ずつリターンする

                }

            }

        }

    }

}
