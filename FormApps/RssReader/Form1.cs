//#define Mywork
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

        private void btGet_Click( object sender , EventArgs e ) {

            if( tbUrl.Text == "" ) return;

            using ( var wc = new WebClient() ) {

                var url = wc.OpenRead( tbUrl.Text /*"https://news.yahoo.co.jp/rss/media/kurumans/all.xml"*/ );

                XDocument xdoc = XDocument.Load( url );

                //cbUrl.Items = 

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
