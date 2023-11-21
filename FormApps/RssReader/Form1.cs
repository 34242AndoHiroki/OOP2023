#define Mywork
#define Answer
 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace RssReader {
 
    public partial class Form1 : Form {
 
#if Mywork
 
        List< ItemData > nodes;
        bool isFavoriteSelected = false;
 
        public Form1() {
            InitializeComponent();
        }
 
        #region 自力

        private void Form1_Load( object sender , EventArgs e ) {
            SetTopics();
        }

 
        private void btGet_Click( object sender , EventArgs e ) {
 
            if( cbUrl.Text == "" ) return;      //マスク処理
 
            using ( var wc = new WebClient() ) {
 
                Stream url = null;
 
                try {
                    url = wc.OpenRead( cbUrl.Text );
                }
                catch ( Exception ex ) {
 
                    MessageBox.Show( ex.Message );
                    return;
 
                }
 
                XDocument xdoc = XDocument.Load( url );
 
                nodes = xdoc.Root.Descendants( "item" )
                                            .Select( x => new ItemData
                                                {
                                                    Title = x.Element( "title" ).Value ,
                                                    Link = x.Element( "link" ).Value    
                                                } ).ToList();
 
                lbRssTitle.Items.Clear();
 
                foreach ( var node in nodes ) {
                    lbRssTitle.Items.Add( node.Title );
                }
 
                AddItems( cbUrl.Text );
 
            }
 
        }

 
        private void lbRssTitle_Click( object sender , EventArgs e ) {
 
            if( lbRssTitle.SelectedItem == null ) return;
 
            wbBrowser.Navigate( ( nodes[ lbRssTitle.SelectedIndex ] ).Link );
 
        }

 
        private void AddItems( string text ) {
            
            //Linkがすでにあれば追加しない
            if( cbUrl.Items.Cast< ItemData >().Select( i => i.Link ).Contains( text ) ) return;

            cbUrl.Items.Add( new ItemData { Title = cbUrl.Text , Link = cbUrl.Text } );
 
        }


        private void btMyFavorite_Click( object sender , EventArgs e ) {

            if ( btMyFavorite.Text == "☆お気に入り追加" ) {

                //マスク処理
                if ( cbUrl.Text == "" ) {

                    MessageBox.Show( "URLが入力されていません。" );
                    return;

                }

                if ( tbFavoriteName.Text == "" ) {

                    MessageBox.Show( "名前が入力されていません。" );
                    return;

                }

                if ( Regex.IsMatch( tbFavoriteName.Text , @"^\s+$" ) ) {       //空白記号のみ

                    MessageBox.Show( "空白文字のみの名前は指定できません。" );
                    return;

                }

                if ( cbFavorites.Items.Cast< ItemData >().Select( i => i.Title ).Contains( tbFavoriteName.Text ) ) {         //すでに同じ Title があった場合

                    MessageBox.Show( "既に同じタイトル名を登録しています。" );
                    return;

                }

                //追加処理
                cbFavorites.Items.Add( new ItemData { Title = tbFavoriteName.Text , Link = cbUrl.Text } );
                MessageBox.Show( "お気に入りに追加しました。" );

            }
            else if ( btMyFavorite.Text == "名前を変更" /*&& tbFavoriteName.Text != ( cbFavorites.Items[ cbFavorites.SelectedIndex ] as ItemData ).Title*/ )     //名前の変更
            {

                //( ( ItemData )( cbFavorites.Items[ cbFavorites.SelectedIndex ] ) ).Title = tbFavoriteName.Text;
                cbFavorites.Items.Insert( cbFavorites.SelectedIndex , new ItemData { Title = tbFavoriteName.Text , Link = ( cbFavorites.Items[ cbFavorites.SelectedIndex ] as ItemData ).Link } );
                cbFavorites.Items.RemoveAt( cbFavorites.SelectedIndex );

                MessageBox.Show( "名前を変更しました。" );
                btMyFavorite.Text = "★お気に入り解除";

            }
            else        //"★お気に入り解除"
            {

                if( cbFavorites.SelectedIndex == -1 ) 
                {

                    MessageBox.Show( "お気に入りの項目を選択してください。" );
                    return;

                }
                else
                {

                    cbFavorites.Items.RemoveAt( cbFavorites.SelectedIndex );        //お気に入り解除

                    MessageBox.Show( "お気に入りから解除しました。" );

                    tbFavoriteName.Text = "";
                    btMyFavorite.Text = "☆お気に入り追加";

                    if( cbFavorites.Items.Count == 0 ) cbFavorites.Text = "";       //なかったときのマスク処理

                }

            }

        }


        //最初からデフォルトのリンクを用意
        private void SetTopics() {

            cbTopics.Items.Add( new ItemData { Title = "主要", Link = "https://news.yahoo.co.jp/rss/topics/top-picks.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "国内", Link = "https://news.yahoo.co.jp/rss/topics/domestic.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "国際", Link = "https://news.yahoo.co.jp/rss/topics/world.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "経済", Link = "https://news.yahoo.co.jp/rss/topics/business.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "エンタメ", Link = "https://news.yahoo.co.jp/rss/topics/entertainment.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "スポーツ", Link = "https://news.yahoo.co.jp/rss/topics/sports.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "IT", Link = "https://news.yahoo.co.jp/rss/topics/it.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "科学", Link = "https://news.yahoo.co.jp/rss/topics/science.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "地域", Link = "https://news.yahoo.co.jp/rss/topics/local.xml" } );

        }


        private void cbUrl_SelectedIndexChanged( object sender , EventArgs e ) {

            ToNotFavoriteUpdate( ( ItemData )cbUrl.Items[ cbUrl.SelectedIndex ] );
            OtherSelected();

        }


        private void cbTopics_SelectedIndexChanged( object sender , EventArgs e ) {

            ToNotFavoriteUpdate( ( ItemData )cbTopics.Items[ cbTopics.SelectedIndex ] );
            OtherSelected();

        }


        private void cbFavorites_SelectedIndexChanged( object sender , EventArgs e ) {

            ToFavoriteUpdate( ( ItemData )cbFavorites.Items[ cbFavorites.SelectedIndex ] );
            cbFavoriteSelected();

        }


        public void ToNotFavoriteUpdate( ItemData data ) {

            cbUrl.Text = data.Link;
            tbFavoriteName.Text = "";
            btMyFavorite.Text = "☆お気に入り追加";

        }


        public void ToFavoriteUpdate( ItemData data ) {

            cbUrl.Text = data.Link;
            tbFavoriteName.Text = data.Title;
            btMyFavorite.Text = "★お気に入り解除";

        }

        private void tbFavoriteName_TextChanged( object sender, EventArgs e ) {

            if( isFavoriteSelected ) btMyFavorite.Text = "名前を変更";

        }

        private void OtherSelected() => isFavoriteSelected = false;
        private void cbFavoriteSelected() => isFavoriteSelected = true;


        #endregion

#elif Answer
 
        #region 模範解答
 
        List< ItemData > ItemDatas = new List< ItemData >();        //IEnumerable<>はインターフェースだから使えない
 
        public Form1() {

            InitializeComponent();

        }
 
        private void btGet_Click( object sender , EventArgs e ) {
 
            if ( tbUrl.Text == "" ) return;
 
            lbRssTitle.Items.Clear();       //リストボックスクリア
 
            using ( var wc = new WebClient() ) {
 
                var url = wc.OpenRead( tbUrl.Text );

                XDocument xdoc = XDocument.Load( url );
 
                var ItemDatas = xdoc.Root.Descendants( "item" )       //要素を持ってくる条件

                                            .Select( x => new ItemData

                                                {

                                                    Title = ( string )x.Element( "title" ) ,           //明示的なキャストだから ToString() よりもキャスト

                                                    Link = ( string )x.Element( "link" ) ,

                                                } ).ToList();

                //var nodes = xdoc.Root.Descendants( "item" ).Descendants( "title" );
 
                foreach ( var node in ItemDatas) {         //ここで解析
 
                    lbRssTitle.Items.Add( node.Title );
 
                }
 
            }
 
        }
 
        private void lbRssTitle_Click( object sender , EventArgs e ) {
 
            if( lbRssTitle.SelectedIndex == -1 ) return;
 
            wbBrowser.Navigate( ItemDatas[ lbRssTitle.SelectedIndex ].Link );
 
        }
 
        #endregion
 
#endif

    }
 
}

/*  URL
車
https://news.yahoo.co.jp/rss/media/kurumans/all.xml
*/