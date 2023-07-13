#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {

    public partial class Form1 : Form {

        //管理用のデータ
        BindingList< CarReport > CarReports = new BindingList< CarReport >();       //バインディングさせるリスト

        public Form1() {

            InitializeComponent();
            dgvCarReports.DataSource = CarReports;

        }

        private void btImageOpen_Click( object sender , EventArgs e ) {

            ofdImageFileOpen.ShowDialog();      //ダイアログが開かれる
            pbCarImage.Image = Image.FromFile( ofdImageFileOpen.FileName );     //開くとセットされる

        }

#if Mywork

        #region 自力

        private void Form1_Load( object sender , EventArgs e ) {

            dgvCarReports.Columns[ 5 ].Visible = false;     //画像項目非表示

            btModifiReport.Enabled = false;     //マスクする
            btDeleteReport.Enabled = false;
            authorNameNotInput.Visible = false;
            carNameNotInput.Visible = false;

        }

        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click( object sender , EventArgs e ) {

            var addCarReport = 
                new CarReport
                {

                    Date = dtpDate.Value.Date ,
                    Author = cbAuthor.Text ,
                    Maker = getSelectedMaker() ,
                    CarName = cbCarName.Text ,
                    Report = tbReport.Text ,
                    CarImage = pbCarImage.Image ,

                };

            if ( updateErrorMessage( addCarReport ) ) return;

            if( !cbAuthor.Items.Contains( cbAuthor.Text ) ){
                cbAuthor.Items.Add( cbAuthor.Text );
            }

            if ( !cbCarName.Items.Contains( cbCarName.Text ) )
            {
                cbCarName.Items.Add( cbCarName.Text );
            }

            CarReports.Add( addCarReport );

            //dtpDate.Value = ;
            cbAuthor.Text = "";
            CheckSelectedMaker();
            cbCarName.Text = "";
            tbReport.Text = "";
            pbCarImage.Image = null;

            openAccess();

        }

        public CarReport.MakerGroup getSelectedMaker() { 

            //var condition = ;

            //switch ( gbMaker.Controls.GetEnumerator(). )
            //{

            //    case "rbToyota" : return CarReport.MakerGroup.トヨタ;
            //    case "rbNissan" : return CarReport.MakerGroup.日産;

            //    default : return CarReport.MakerGroup.その他; 
                
            //}

            foreach ( var item in gbMaker.Controls )
            {

                if ( ( ( RadioButton )item ).Checked )
                {
                    
                    //tag = int.Parse( ( ( RadioButton )item ).Tag.ToString() );
                    //break;

                    return ( CarReport.MakerGroup )int.Parse( ( ( RadioButton )item ).Tag.ToString() );

                }

            }

            return CarReport.MakerGroup.その他;

        }

        //指定したメーカーのラジオボタンをセット
        public void CheckSelectedMaker() {

            foreach ( var item in gbMaker.Controls )
            {

                if( ( CarReport.MakerGroup )int.Parse( ( ( RadioButton )item ).Tag.ToString() ) == ( CarReport.MakerGroup )dgvCarReports.CurrentRow.Cells[ 2 ].Value )
                    ( ( RadioButton )item ).Checked = true;

            }

        }

        //削除ボタンイベントハンドラ
        private void btDeleteReport_Click( object sender , EventArgs e ) {

            //for文式
            //for ( int i = 0 ; i < dgvCarReports.RowCount ; i++ )
            //{

            //    if( dgvCarReports.Rows[ i ].Equals( dgvCarReports.SelectedRows ) )
            //        CarReports.RemoveAt( i );

            //}

            //要素数を調べる方式
            //if( CarReports.Count != 0 ) CarReports.RemoveAt( dgvCarReports.CurrentRow.Index );

            CarReports.RemoveAt( dgvCarReports.CurrentRow.Index );

            if( CarReports.Count == 0 ) blockAccess();       //要素なしのマスク処理


        }

        //レコードの選択時
        private void dgvCarReports_Click( object sender , EventArgs e ) {
        
            dtpDate.Value = ( DateTime )dgvCarReports.CurrentRow.Cells[ 0 ].Value;
            cbAuthor.Text = dgvCarReports.CurrentRow.Cells[ 1 ].Value.ToString();
            CheckSelectedMaker();
            cbCarName.Text = dgvCarReports.CurrentRow.Cells[ 3 ].Value.ToString();
            tbReport.Text = dgvCarReports.CurrentRow.Cells[ 4 ].Value.ToString();
            pbCarImage.Image = ( Image )dgvCarReports.CurrentRow.Cells[ 5 ].Value;

        }

        //更新ボタンイベントハンドラ
        private void btModifiReport_Click( object sender , EventArgs e ) {

            var target = dgvCarReports.CurrentRow.Index;
            var afterCarReport = 
                new CarReport
                {

                    Date = dtpDate.Value ,
                    Author = cbAuthor.Text ,
                    Maker = getSelectedMaker() ,
                    CarName = cbCarName.Text ,
                    Report = tbReport.Text ,
                    CarImage = pbCarImage.Image ,

                };

            if( updateErrorMessage( afterCarReport ) ) return;

            CarReports.RemoveAt( target );
            CarReports.Insert( target , afterCarReport );

        }

        //要素がない時の処理
        private void blockAccess() {

            btModifiReport.Enabled = false;
            btDeleteReport.Enabled = false;

        }

        //要素がない時の処理
        private void openAccess() {

            btModifiReport.Enabled = true;
            btDeleteReport.Enabled = true;

        }

        //エラーメッセージ表示
        private bool updateErrorMessage( CarReport carReport ) {

            if( carReport.Author == "" ) authorNameNotInput.Visible = true;
            else authorNameNotInput.Visible = false;
            if ( carReport.CarName == "" ) carNameNotInput.Visible = true;
            else carNameNotInput.Visible = false;

            if( authorNameNotInput.Visible || carNameNotInput.Visible ) return true;
            return false;

        }

        //終了メニュー選択時のイベントハンドラ
        private void 終了XToolStripMenuItem_Click( object sender , EventArgs e ) {

            Application.Exit();

        }

        private void バージョン情報ToolStripMenuItem_Click( object sender , EventArgs e ) {

            var vf = new VersionForm();
            //vf.Show();      //モードレスダイアログとして表示
            vf.ShowDialog();        //モーダルダイアログとして表示

        }

        #endregion

#elif Answer

        #region 模範解答

        private void Form1_Load( object sender , EventArgs e ) {

            dgvCarReports.Columns[ 5 ].Visible = false;     //画像項目非表示

            btModifiReport.Enabled = false;     //マスクする

            tsInfoText.Text = "ここにメッセージを入力してください。";     //メッセージの表示
            tsInfoText.Text = "";     //メッセージの表示

        }

        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click( object sender , EventArgs e ) {

            statusLabelDisp();      //ステータスラベルのテキスト非表示

            if( cbAuthor.Equals( "" ) )       //cbAuthor.Text == "" でも可
            {

                //tsInfoText.Text = "記録者を入力してください";
                statusLabelDisp( "記録者を入力してください" );
                return;

            }
            else if ( cbCarName.Text.Equals( "" ) )
            {

                //tsInfoText.Text = "車名を入力してください";
                statusLabelDisp( "車名を入力してください" );
                return;

            }
            //else
            //{
            //    statusLabelDisp( "" );      //表示なし
            //}

            var CarReport = new CarReport           //Saleインスタンスを生成
            {

                Date = dtpDate.Value ,
                Author = cbAuthor.Text ,
                Maker =  getSelectedMaker() ,
                CarName = cbCarName.Text ,
                Report = tbReport.Text ,
                CarImage = pbCarImage.Image ,

            };



            CarReports.Add( CarReport );

        }

        //ラジオボタンで選択されているメーカーを返却
        public CarReport.MakerGroup getSelectedMaker() { 

            //エラー
            //foreach ( var item in gbMaker.Controls )
            //{

            //    if( ( ( RadioButton ) item ).Checked ) 
            //    {
            //        return ( CarReport.MakerGroup )( ( RadioButton )item ).Tag;
            //    }

            //}

            //return CarReport.MakerGroup.その他;

            //めんどくさいが…

            //int tag = 0;

            foreach ( var item in gbMaker.Controls )
            {

                if ( ( ( RadioButton )item ).Checked )
                {
                    
                    //tag = int.Parse( ( ( RadioButton )item ).Tag.ToString() );
                    //break;

                    return ( CarReport.MakerGroup )int.Parse( ( ( RadioButton )item ).Tag.ToString() );

                }

            }

            //return ( CarReport.MakerGroup )tag;

            return CarReport.MakerGroup.その他;

            //これでもいい
            //if( rbToyota.Checked )
            //{
            //    return CarReport.MakerGroup.トヨタ;
            //}
            //else if( rbNissan.Checked )
            //{
            //    return CarReport.MakerGroup.日産;
            //}
            //else if( rbHonda.Checked )
            //{
            //    return CarReport.MakerGroup.ホンダ;
            //}
            //else if( rbSubaru.Checked )
            //{
            //    return CarReport.MakerGroup.スバル;
            //}
            //else if( rbSuzuki.Checked )
            //{
            //    return CarReport.MakerGroup.スズキ;
            //}
            //else if( rbDaihatsu.Checked )
            //{
            //    return CarReport.MakerGroup.ダイハツ;
            //}
            //else if ( rbImported.Checked )
            //{
            //    return CarReport.MakerGroup.輸入車;
            //}

            //return CarReport.MakerGroup.その他;

            //軽量化
            //if( rbToyota.Checked ) return CarReport.MakerGroup.トヨタ;
            //if( rbNissan.Checked ) return CarReport.MakerGroup.日産;
            //if( rbHonda.Checked ) return CarReport.MakerGroup.ホンダ;
            //if( rbSubaru.Checked ) return CarReport.MakerGroup.スバル;
            //if( rbSuzuki.Checked ) return CarReport.MakerGroup.スズキ;
            //if( rbDaihatsu.Checked ) return CarReport.MakerGroup.ダイハツ;
            //if ( rbImported.Checked ) return CarReport.MakerGroup.輸入車;

            //return CarReport.MakerGroup.その他;

        }

        public void setSelectedMaker( CarReport.MakerGroup makerGroup ) {

            switch ( makerGroup )
            {

                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;

                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;

                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;

                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;

                case CarReport.MakerGroup.スズキ:
                    rbSuzuki.Checked = true;
                    break;

                case CarReport.MakerGroup.ダイハツ:
                    rbDaihatsu.Checked = true;
                    break;

                case CarReport.MakerGroup.輸入車:
                    rbImported.Checked = true;
                    break;

                case CarReport.MakerGroup.その他:
                    rbOther.Checked = true;
                    break;

            }

        }

        //削除ボタンイベントハンドラ
        private void btDeleteReport_Click( object sender , EventArgs e ) {

            CarReports.RemoveAt( dgvCarReports.CurrentRow.Index );

        }

        //レコードの選択時
        private void dgvCarReports_Click( object sender , EventArgs e ) {

            //var data = dgvCarReports.CurrentRow.Cells[ 3 ].Value;       //[ i ] 列目を取り出す方法

            dtpDate.Value = ( DateTime )dgvCarReports.CurrentRow.Cells[ 0 ].Value;
            cbAuthor.Text = dgvCarReports.CurrentRow.Cells[ 1 ].Value.ToString();

            //var temp = dgvCarReports.CurrentRow.Cells[ 2 ].Value;
            //setSelectedMaker( ( CarReport.MakerGroup )temp );

            setSelectedMaker( ( CarReport.MakerGroup )dgvCarReports.CurrentRow.Cells[ 2 ].Value );

            cbCarName.Text = dgvCarReports.CurrentRow.Cells[ 3 ].Value.ToString();
            tbReport.Text = dgvCarReports.CurrentRow.Cells[ 4 ].Value.ToString();
            pbCarImage.Image = ( Image )dgvCarReports.CurrentRow.Cells[ 5 ].Value;


        }

        //更新ボタンイベントハンドラ
        private void btModifiReport_Click( object sender , EventArgs e ) {

            if( dgvCarReports.Rows.Count == 0 ) return;     //空の時のマスク処理

            //隠すと変更されるマジック的なことが起こります（描画処理）
            CarReports[ dgvCarReports.CurrentRow.Index ].Date = dtpDate.Value;
            CarReports[ dgvCarReports.CurrentRow.Index ].Author = cbAuthor.Text;
            CarReports[ dgvCarReports.CurrentRow.Index ].Maker = getSelectedMaker();
            CarReports[ dgvCarReports.CurrentRow.Index ].CarName = cbCarName.Text;
            CarReports[ dgvCarReports.CurrentRow.Index ].Report = tbReport.Text;
            CarReports[ dgvCarReports.CurrentRow.Index ].CarImage = pbCarImage.Image;

            dgvCarReports.Refresh();        //一覧更新

        }

        //ステータスラベルのテキスト表示・非表示
        private void statusLabelDisp( string msg = "" ) {       //オプション引数

            tsInfoText.Text = msg;

        }

        //終了メニュー選択時のイベントハンドラ
        private void 終了XToolStripMenuItem_Click( object sender , EventArgs e ) {

            Application.Exit();

        }


        #endregion

#endif

    }

}
