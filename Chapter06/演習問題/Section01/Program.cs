//#define No1
//#define No2
//#define No3
//#define No4
#define No5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {

    class Program {

        static void Main(string[] args) {

            var numbers = new List< int > { 9 , 7 , 5 , 4 , 2 , 5 , 4 , 0 , 4 , 1 , 0 , 4 };

            Console.WriteLine( numbers.Average() );       //平均を求める


            var books = Books.GetBooks();       //本を取得

            Console.WriteLine( books.Average( x => x.Price ) );     //価格の平均
            Console.WriteLine( books.Average( x => x.Pages ) );     //ページの平均

            Console.WriteLine( books.Max( x => x.Pages ) );     //最大ページ数
            Console.WriteLine( books.Max( x => x.Price ) );     //最大価格

            Console.WriteLine( "-------------" );

#if No1

            //500円以上の本のタイトルをすべて出力

#if !true

            #region 自力

            books.Where( x => x.Price >= 500 ).Select( x => x.Title ).ToList().ForEach( Console.WriteLine );
            //books.Where( x => x.Price >= 500 ).Select( x => x ).ToList().ForEach( Console.WriteLine );

            books.Where( x => x.Price >= 500 ).Select( x => x ).OrderBy( x => x.Price ).ToList().ForEach( x => Console.WriteLine( "{0}：{1}円" , x.Title, x.Price ) );
            
            #endregion

#else

            #region 模範解答

            var booksObj = books.Where( x => x.Price >= 500 );

            foreach( var book in booksObj )
            {
                Console.WriteLine( "{0}：{1}円" , book.Title , book.Price );
            }

            #endregion

#endif

#elif No2

        //500円以上の本の価格を降順に出力

#if !true

            #region 自力

                //books.Where( x => x.Price >= 500 ).Select( x => x.Title ).ToList().ForEach( Console.WriteLine );

                books.Where( x => x.Price >= 500 ).Select( x => x ).OrderBy( x => x.Price ).ToList().ForEach( x => Console.WriteLine( "{0}：{1}円" , x.Title, x.Price ) );
            
            #endregion

#else

            #region 模範解答

                var booksObj = books.Where( x => x.Price >= 500 ).OrderByDescending( x => x.Price );

                foreach( var book in booksObj )
                {
                    Console.WriteLine( "{0}：{1}円" , book.Title , book.Price );
                }

            #endregion

#endif

#elif No3

#if !true

            #region 自力

                books.Where( x => x.Price >= 500 ).Select( x => x.Title ).ToList().ForEach( Console.WriteLine );
                //books.Where( x => x.Price >= 500 ).Select( x => x ).ToList().ForEach( Console.WriteLine );

                books.Where( x => x.Price >= 500 ).Select( x => x ).OrderBy( x => x.Price ).ToList().ForEach( x => Console.WriteLine( "{0}：{1}円" , x.Title, x.Price ) );
            
            #endregion

#else

            #region 模範解答

                var booksObj = books.Where(x => x.Title.Contains( "物語" ) );

                foreach (var book in booksObj)
                {
                    Console.WriteLine( "{0}：{1}円" , book.Title , book.Price );
                }

            #endregion

#endif

#elif No4

            //タイトルに「物語」が含まれている書籍の平均ページ数

#if !true

            #region 自力

            Console.WriteLine( "平均：{0}円" , books.Where( x => x.Title.Contains( "物語" ) ).Average( x => x.Pages ) );

            #endregion

#else

            #region 模範解答

            var booksObj = books.Where( x => x.Title.Contains( "物語" ) ).Average( x => x.Pages );
            Console.WriteLine( "平均：{0}円" , booksObj );

            #endregion

#endif

#elif No5

            //タイトルが長い順

#if !true

            #region 自力

            books.OrderByDescending( x => x.Title.Length ).ToList().ForEach( x => Console.WriteLine( x.Title ) );

            #endregion

#else

            #region 模範解答

            var longTitlebooks = books.OrderByDescending( x => x.Title.Length );        // x => x.Title だと名前がASCIIコード順に整列される

            foreach ( var book in books )
            {
                Console.WriteLine( "{0} {1}" , book.Title , book.Price );
            }

            #endregion

#endif

#endif

        }

    }

}
