using System;
using System.Data.Entity;
using System.Linq;

//定義以外はすべて自動生成
namespace CarReportSystem.Models {

    public class BooksDbContext : DbContext {       // BooksDbContext 経由で Books 、Authors にアクセスする

        // コンテキストは、アプリケーションの構成ファイル (App.config または Web.config) から 'BooksDbContext' 
        // 接続文字列を使用するように構成されています。既定では、この接続文字列は LocalDb インスタンス上
        // の 'CarReportSystem.Models.BooksDbContext' データベースを対象としています。 
        // 
        // 別のデータベースとデータベース プロバイダーまたはそのいずれかを対象とする場合は、
        // アプリケーション構成ファイルで 'BooksDbContext' 接続文字列を変更してください。

        public BooksDbContext()     //コンストラクタ

            : base( "name=BooksDbContext" ) {

        }

        // モデルに含めるエンティティ型ごとに DbSet を追加します。Code First モデルの構成および使用の
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=390109 を参照してください。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        #region 定義

        //自動生成外
        // BooksDbContext 経由で Books 、Authors にアクセスする
        public DbSet< Book > Books { get; set; }
        public DbSet< Author > Authors { get; set; }

        #endregion

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

}