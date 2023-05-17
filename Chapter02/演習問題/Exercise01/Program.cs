﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            #region ３．
            //2.1.3
            var songs = new Song[] {

                new Song( "Let it be" , "The Beatles" , 243 ) ,
                new Song( "Bridge Over Troubled Water" , "Simon & Garfunkel" , 293) ,
                new Song( "Close To You" , "Carpenters" , 276 ) ,
                new Song( "Honesty" , "Billy Joel" , 231 ) ,
                new Song( "I Will Always Love You" , "Whitney Houston" , 273 ) ,

            };

            PrintSongs(songs);

            var lists = new List<Song>();
            lists.Add(new Song("Let it be", "The Beatles", 243));
            lists.Add(new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293));
            lists.Add(new Song("Close To You", "Carpenters", 276));
            lists.Add(new Song("Honesty", "Billy Joel", 231));
            lists.Add(new Song("I Will Always Love You", "Whitney Houston", 273));

            PrintSongs(lists);
            #endregion

        }

        #region ４．
        public static void PrintSongs(IEnumerable<Song> songs) {
            foreach (Song song in songs)
            {
                Console.WriteLine("タイトル：{0}", song.Title);
                Console.WriteLine("作者：{0}", song.ArtistName);
                Console.WriteLine("演奏時間：{0:00}:{1:00}", (song.Length / 60), (song.Length % 60));
                Console.WriteLine();        //改行
            }
        }
        #endregion

    }
}
