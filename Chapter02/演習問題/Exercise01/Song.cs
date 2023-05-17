using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Song {

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

    }
}
