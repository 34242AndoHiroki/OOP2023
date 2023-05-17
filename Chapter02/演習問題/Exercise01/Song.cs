using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Song {

#if false
    #region My
        #region １．
        //歌のタイトル
        public string Title { get; set; }
        //アーティスト名
        public string ArtistName { get; set; }
        //演奏時間、単位は秒
        public int Length { get; set; }
        #endregion

        #region ２．
        public Song(string title, string artistName, int length) {
            this.Title = title;
            this.ArtistName = artistName;
            this.Length = length;
        }
        #endregion
    #endregion
#else
    #region 模範解答

        //自動実装プロパティ
        public string Title { get; set; }       //歌のタイトル
        public string ArtistName { get; set; }      //アーティスト名
        public int Length { get; set; }      //演奏時間（秒）

        //2.1.2
        public Song( string title , string artistname , int length ) {      //Mainの呼び出しに合わせる
            Title = title;          //Javaだと this.Title = this.setTitle( title ) とかする
            ArtistName = artistname;
            Length = length;
        }
    #endregion
#endif

    }
}
