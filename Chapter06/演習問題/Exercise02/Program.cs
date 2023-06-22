﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            var books = new List<Book> {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            Exercise2_1(books);
            Console.WriteLine("-----");

            Exercise2_2(books);

            Console.WriteLine("-----");

            Exercise2_3(books);
            Console.WriteLine("-----");

            Exercise2_4(books);
            Console.WriteLine("-----");

            Exercise2_5(books);
            Console.WriteLine("-----");

            Exercise2_6(books);

            Console.WriteLine("-----");

            Exercise2_7(books);

        }

#if !true
        #region 自力
        private static void Exercise2_1(List<Book> books) {
            var select = books.Where(b => b.Title.Contains("ワンダフル・C#ライフ"));

            foreach (var book in select)
            {
                Console.WriteLine("価格：{0}　ページ数：{1}", book.Price, book.Pages);
            }
        }

        private static void Exercise2_2(List<Book> books) {
            Console.WriteLine(books.Where(b => b.Title.Contains("C#")).Count());
        }

        private static void Exercise2_3(List<Book> books) {
            Console.WriteLine(books.Where(b => b.Title.Contains("C#")).Average(b => b.Pages));
        }

        private static void Exercise2_4(List<Book> books) {
            Console.WriteLine(books.Where(b => b.Price >= 4000).FirstOrDefault().Title);
        }

        private static void Exercise2_5(List<Book> books) {
            Console.WriteLine(books.Where(b => b.Price < 4000).Max(b => b.Pages));
        }

        private static void Exercise2_6(List<Book> books) {
            //一行完結型
            books.Where(b => b.Pages >= 400).OrderByDescending(b => b.Price).ToList().ForEach(b => Console.WriteLine("{0}：{1}", b.Title, b.Price));

            //利点を生かす
            //var select = books.Where(b => b.Pages >= 400).OrderByDescending(b => b.Price);

            //foreach (var book in select)
            //{
            //    Console.WriteLine("{0}：{1}", book.Title, book.Price);
            //}
        }

        private static void Exercise2_7(List<Book> books) {
            books.Where(b => b.Title.Contains("C#") && b.Pages <= 500).ToList().ForEach(b => Console.WriteLine(b.Title));
        }
        #endregion
#else
        #region 模範解答
        private static void Exercise2_1(List<Book> books) {
            var book = books.Where(b => b.Title == "ワンダフル・C#ライフ");
            foreach(var item in book)
            {
                Console.WriteLine("{0} {1}",item.Price , item.Pages);
            }

            //最初に見つかったものだけを対象にする
            //var book = books.FirstOrDefault(b => b.Title == "ワンダフル・C#ライフ");
            //if(book != null)      //例外対策もしなきゃいけない
            //{
            //    Console.WriteLine("{0} {1}", book.Price, book.Pages);
            //}
        }

        private static void Exercise2_2(List<Book> books) {
            var count = books.Count(b=>b.Title.Contains("C#"));     // == だと "C#" じゃないと引っかからない
            Console.WriteLine(count);
        }

        private static void Exercise2_3(List<Book> books) {
            var count = books.Where(b => b.Title.Contains("C#")).Average(b => b.Pages);
            Console.WriteLine(count);
        }

        private static void Exercise2_4(List<Book> books) {
            var book = books.FirstOrDefault(b => b.Price >= 4000);
            if(book != null) 
            {
                Console.WriteLine(book.Title);
            }
                
        }

        private static void Exercise2_5(List<Book> books) {
            var pages = books.Where(b => b.Price < 4000).Max(b => b.Pages);     // Max() と書かないように。「何を」をしっかりする
            Console.WriteLine(pages);
        }

        private static void Exercise2_6(List<Book> books) {
            var selected = books.Where(b => b.Pages >= 400).OrderByDescending(b => b.Price);

            foreach (var book in selected)
            {
                Console.WriteLine("{0} {1}", book.Title, book.Price);
            }
        }

        private static void Exercise2_7(List<Book> books) {
            var selected = books.Where(b => b.Title.Contains("C#") && b.Pages <= 500);      //var selected = books.Where(b => b.Title.Contains("C#") && b.Pages <= 500);       ×
                                                                                            //b => ... b はすべてに渡される
            foreach (var book in selected)
            {
                Console.WriteLine(book.Title);
            }
        }
        #endregion
#endif
    }


    class Book {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
    }
}
