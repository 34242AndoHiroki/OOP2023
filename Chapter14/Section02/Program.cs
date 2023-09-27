//#define HTTP通信
#define 非同期処理

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {

    class Program {

#if HTTP通信

        static void Main( string[] args ) {

            //これだけで通信ができる（非推奨の方法）
            var wc = new WebClient();       //ここ変えるだけでできる
            wc.Encoding = Encoding.UTF8;       //ASCII だと日本語が文字化けする
            var html = wc.DownloadString( "https://visualstudio.microsoft.com/ja/" );       //URL
            Console.WriteLine( html );      //ページのハイパーテキストを表示

        }

#elif 非同期処理

        static void Main( string[] args ) {

            var wc = new WebClient();
            var url = new Uri( "https://www.rimarts.jp/downloads/B2/bk28104j.zip" );
            var filename = @"C:\temp\example.zip";
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;       //デリゲート登録
            wc.DownloadFileCompleted += wc_DownloadFileCompleted;
            wc.DownloadFileAsync( url , filename );
            Console.ReadLine();

        }

        static void wc_DownloadProgressChanged( object sender , DownloadProgressChangedEventArgs e ) {

            Console.WriteLine( "{0}% {0}/{1}" , e.ProgressPercentage ,
                              e.BytesReceived , e.TotalBytesToReceive );

        }

        static void wc_DownloadFileCompleted( object sender , System.ComponentModel.AsyncCompletedEventArgs e ) {       //完了時に呼ばれるメソッド

            Console.WriteLine( "ダウンロード完了" );

        }

#endif

    }

}
