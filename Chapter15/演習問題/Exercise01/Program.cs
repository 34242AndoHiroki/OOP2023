#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

#if Mywork
        #region 自力
        private static void Exercise1_2() {
            var max = Library.Books.Max(b => b.Price);
            var books = Library.Books.Where(b => b.Price == max).Select(b => b);

            foreach (var book in books) {
                Console.WriteLine($"発行年：{book.PublishedYear}, カテゴリ：{book.CategoryId},価格：{book.Price},タイトル{book.Title}");
            }
            
            //Library.Books.Where(b => b.Price == Library.Books.Max(b0 => b0.Price)).Select(b => b).ToList().ForEach(b => Console.WriteLine($"発行年：{b.PublishedYear}, カテゴリ：{b.CategoryId},価格：{b.Price},タイトル{b.Title}"));

        }

        private static void Exercise1_3() {
            var counts = Library.Books.GroupBy(b => b.PublishedYear).Select(g => (g.Key, g.Count())).OrderBy(g => g.Key);

            foreach (var count in counts)
                Console.WriteLine($"{count.Key}年 {count.Item2}冊");

            //Library.Books.GroupBy(b => b.PublishedYear).Select(g => (g.Key, g.Count())).OrderBy(g=>g.Key).ToList().ForEach(g =>Console.WriteLine($"{g.Key}年 {g.Item2}冊"));
        }

        private static void Exercise1_4() {
            var sorted = Library.Books.OrderByDescending(b => b.PublishedYear).ThenByDescending(b => b.Price)
                            .Join(Library.Categories, b => b.CategoryId, c => c.Id,
                                 (b, c) => new {
                                     Title = b.Title,
                                     CategoryName = c.Name ,
                                     Price = b.Price,
                                     PublishedYear = b.PublishedYear,
                                 });

            foreach (var book in sorted) {
                Console.WriteLine($"{book.PublishedYear}年 {book.Price}円 {book.Title}({book.CategoryName})");
            }

            //Library.Books.OrderByDescending(b => b.PublishedYear).ThenByDescending(b => b.Price)
            //                .Join(Library.Categories, b => b.CategoryId, c => c.Id,
            //                     (b, c) => new {
            //                         Title = b.Title,
            //                         CategoryName = c.Name,
            //                         Price = b.Price,
            //                         PublishedYear = b.PublishedYear,
            //                     })
            //                .ToList().ForEach(b => Console.WriteLine($"{b.PublishedYear}年 {b.Price}円 {b.Title}({b.CategoryName})"));
        }

        private static void Exercise1_5() {
            var titles = Library.Books.Where(b => b.PublishedYear == 2016).Distinct()
                            .Join(Library.Categories, b => b.CategoryId, c => c.Id,
                                (b, c) => new {
                                    CategoryName = c.Name
                                }).Distinct();

            foreach (var title in titles) {
                Console.WriteLine(title.CategoryName);
            }

            //Library.Books.Where(b => b.PublishedYear == 2016).Distinct()
            //                .Join(Library.Categories, b => b.CategoryId, c => c.Id,
            //                    (b, c) => new {
            //                        CategoryName = c.Name
            //                    }).Distinct().ToList().ForEach(c => Console.WriteLine(c.CategoryName));
        }

        private static void Exercise1_6() {
            var groups = Library.Books.OrderBy(b => b.Title)
                            .Join(Library.Categories, b => b.CategoryId, c => c.Id,
                                (b, c) => new {
                                    Title = b.Title,
                                    CategoryName = c.Name,
                                }).GroupBy(b => b.CategoryName).OrderBy(g => g.Key);

            foreach (var group in groups) {
                Console.WriteLine($"#{group.Key}");
                foreach (var book in group) {
                    Console.WriteLine($"　{book.Title}");
                }
            }

        }

        private static void Exercise1_7() {
            var developGroup = Library.Books.Where(b => b.CategoryId == 1).ToLookup(b => b.PublishedYear).OrderBy(g => g.Key);

            foreach (var group in developGroup) {
                Console.WriteLine($"#{group.Key}年");
                foreach (var book in group) {
                    Console.WriteLine($"　{book.Title}");
                }
            } 
        }

        private static void Exercise1_8() {
            var groups = Library.Categories.GroupJoin(Library.Books, c => c.Id, b => b.CategoryId,
                        (c, books) => new {
                            CategoryName = c.Name,
                            Count = books.Count(),
                        }).Where(g => g.Count >= 4).Select(g => g);

            foreach (var group in groups) {
                Console.WriteLine(group.CategoryName);
            }

            //Library.Categories.GroupJoin(Library.Books, c => c.Id, b => b.CategoryId,
            //           (c, books) => new {
            //               CategoryName = c.Name,
            //               Count = books.Count(),
            //           }).Where(g => g.Count >= 4).Select(g => g).ToList().ForEach(g => Console.WriteLine(g.CategoryName));
        }
        #endregion
#elif Answer
        #region 模範解答
        private static void Exercise1_2() {
            var max = Library.Books.Max(b => b.Price);
            var books = Library.Books.Where(b => b.Price == max);
            //Console.WriteLine(book);      //結果が一件の場合

            foreach (var book in books) {
                Console.WriteLine(book);
            }
        }

        private static void Exercise1_3() {
            var query = Library.Books.GroupBy(b => b.PublishedYear)
                                    .Select(g => new { PublishYear = g.Key, Count = g.Count() })
                                    .OrderBy(x => x.PublishYear);

            foreach (var item in query) {
                Console.WriteLine("{0}年 {1}冊",item.PublishYear ,item.Count);
            }
        }

        private static void Exercise1_4() {
            var query = Library.Books
                            .Join(Library.Categories,
                            book => book.CategoryId,
                            category => category.Id,
                            (book, category) => new {
                                book.PublishedYear,         //もともとの Books にある項目は指定しなくても大丈夫
                                book.Price,
                                book.Title,
                                CategoryName = category.Name,       //新たな Categories は指定がないとエラー
                            })
                            .OrderByDescending(x => x.PublishedYear)
                            .ThenByDescending(x => x.Price);

            foreach (var item in query) {
                Console.WriteLine("{0}年 {1}円 ({2})",
                                  item.PublishedYear,
                                  item.Price,
                                  item.Title,
                                  item.CategoryName
                                 );
            }
        }

        private static void Exercise1_5() {
            var query = Library.Books
                            .Where(b => b.PublishedYear == 2016)        // 2016年 のものの絞り込み
                            .Join(
                                Library.Categories,
                                book => book.CategoryId, category => category.Id,
                                (book, category) => category.Name)          //使うのは名前のみだから name のみで大丈夫
                            .Distinct();

            foreach (var name in query) {
                Console.WriteLine(name);
            }
        }

        private static void Exercise1_6() {
            var query = Library.Books
                .Join(Library.Categories,
                    book => book.CategoryId,
                    category => category.Id,
                    (book, category) => new {
                        book.PublishedYear,
                        book.Price,
                        book.Title,
                        CategoryName = category.Name,
                    })
                .GroupBy(x => x.CategoryName)
                .OrderBy(x => x.Key);

            foreach (var group in query) {
                Console.WriteLine("#{0}",group.Key);
                foreach (var item in group) {
                    Console.WriteLine(" {0}",item.Title);
                }
            }
        }

        private static void Exercise1_7() {
            
        }

        private static void Exercise1_8() {

        }
        #endregion
#endif


    }
}
