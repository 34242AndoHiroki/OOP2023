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
 
                //var nodes = xdoc.Root.Descendants( "item" ).Descendants( "title" );
 
                lbRssTitle.Items.Clear();
 
                foreach ( var node in nodes ) {
                    lbRssTitle.Items.Add( node.Title );
                }
 
                AddItems( cbUrl.Text );
 
            }
 
        }
 
        //private void lbRssTitle_DragDrop( object sender , DragEventArgs e ) {
 
        //    //var dropFiles = e.Data.GetData();
 
        //}
 
        //private void lbRssTitle_DragEnter( object sender , DragEventArgs e ) {
 
 
        //}
 
        //private void lbRssTitle_MouseDown(object sender, MouseEventArgs e) {
 
        //    //Point p = Control.MousePosition;

        //    //p = lbRssTitle.PointToClient(p);//マウスの位置をクライアント座標に変換

        //    //int ind = lbRssTitle.IndexFromPoint(p);//マウス下のＬＢのインデックスを得る

        //    //if (ind > -1) {

        //    //    lbRssTitle.DoDragDrop(lbRssTitle.Items[ind].ToString(), DragDropEffects.Copy);//ドラッグスタート

        //    //}
 
        //}
 
        private void lbRssTitle_Click( object sender , EventArgs e ) {
 
            if( lbRssTitle.SelectedItem == null ) return;
 
            wbBrowser.Navigate( ( nodes[ lbRssTitle.SelectedIndex ] ).Link );
 
        }
 
        private void AddItems( string text ) {
            
            //Linkがすでにあれば追加しない
            if( cbUrl.Items.Cast< ItemData >().Select( i => i.Link ).Contains( text ) ) return;

            var it = new ItemData { Title = cbUrl.Text , Link = cbUrl.Text };

            cbUrl.Items.Add( it );
 
        }

        private void btMyFavorite_Click( object sender , EventArgs e ) {

            if ( cbUrl.Text == "" ) {        //マスク処理

                MessageBox.Show( "URLが入力されていません。" );
                return;

            }

            cbFavorites.Items.Add( new ItemData { Title = tbFavoriteName.Text , Link = cbUrl.Text } );

        }

        //最初からデフォルトのリンクを用意
        private void SetTopics() {

            cbTopics.Items.Add( new ItemData { Title = "主要", Link = "https://news.yahoo.co.jp/rss/topics/top-picks.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "国内", Link = "https://news.yahoo.co.jp/rss/topics/domestic.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "国際", Link = "https://news.yahoo.co.jp/rss/topics/world.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "経済", Link = "https://news.yahoo.co.jp/rss/topics/business.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "エンタメ", Link = "https://news.yahoo.co.jp/rss/topics/entertainment.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "スポーツ", Link = "https://news.yahoo.co.jp/rss/topics/sports.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "IT", Link = "https://news.yahoo.co.jp/rss/topics/sports.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "科学", Link = "https://news.yahoo.co.jp/rss/topics/science.xml" } );
            cbTopics.Items.Add( new ItemData { Title = "地域", Link = "https://news.yahoo.co.jp/rss/topics/local.xml" } );

        }

        private void cbUrl_SelectedIndexChanged( object sender , EventArgs e ) {

            cbUrl.Text = ( ( ItemData )cbUrl.Items[ cbUrl.SelectedIndex ] ).Link;

        }

        private void cbTopics_SelectedIndexChanged( object sender , EventArgs e ) {

            cbUrl.Text = ( ( ItemData )cbTopics.Items[ cbTopics.SelectedIndex ] ).Link;

        }

        private void cbFavorites_SelectedIndexChanged( object sender , EventArgs e ) {

            cbUrl.Text = ( ( ItemData )cbFavorites.Items[ cbFavorites.SelectedIndex ] ).Link;

        }

        private void FavoritePrint( ItemData data ) {



        }



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