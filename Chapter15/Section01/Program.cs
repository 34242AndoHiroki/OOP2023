using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {

    class Program {

        static void Main( string[] args ) {

            //MaximumPrice();
            //MostShortTitleBook();
            //MostShortTitleBook2();
            //GroupBySample();
            GroupBySample2();
            ToLookupSample();

        }

        //15-2
        public static void MaximumPrice() {

            //var price = Chapter15.Library ... namespace がもともと chapter15 だったら
            var price = Library.Books.Where( b => b.CategoryId == 1 ).Max( b => b.Price );
            Console.WriteLine( price );

        }

        //15-3
        public static void MostShortTitleBook() {

            var min = Library.Books
                             .Min( x => x.Title.Length );

            var book = Library.Books
                              .First( b => b.Title.Length == min );

            Console.WriteLine( book );

        }

        //上のやつを一つにまとめてやる方式
        public static void MostShortTitleBook2() {

            var book = Library.Books
                              .First( b => b.Title.Length ==
                                          Library.Books.Min( x => x.Title.Length ) );       //毎度実行するから処理速度は落ちる

            Console.WriteLine( book );

        }

        //15-8
        public static void GroupBySample() {

            var groups = Library.Books
                                .GroupBy( b => b.PublishedYear )
                                .OrderBy( g => g.Key );

            foreach ( var g in groups ) {

                Console.WriteLine( $"{ g.Key }年" );

                foreach ( var book in g ) {
                    Console.WriteLine( $"  { book }" );
                }

            }

        }

        //List 15-9
        public static void GroupBySample2() {

            var selected = Library.Books
                                  .GroupBy( b => b.PublishedYear )      //それぞれの年度で
                                  .Select( group => group.OrderByDescending( b => b.Price )         //金額が高い順に
                                                        .First() )          //最初の要素を
                                  .OrderBy( o => o.PublishedYear );         //年度順に

            foreach ( var book in selected ) {
                Console.WriteLine( $"{ book.PublishedYear }年 { book.Title } ( { book.Price } )" );
            }

        }


        //List 15-10
        public static void ToLookupSample() {

            var lookup = Library.Books
                                .ToLookup( b => b.PublishedYear );      // Lookup(キーでグルーピングされた Dictionary 的なやつ) にする

            var books = lookup[ 2014 ];     // 2014年のみ。 [ キー ]で指定

            foreach ( var book in books ) {
                Console.WriteLine( book );
            }

        }

    }

}
