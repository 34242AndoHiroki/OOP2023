#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {

    public partial class Form1 : Form {

        //管理用のデータ
        BindingList< CarReport > CarReports = new BindingList< CarReport >();       //バインディングさせるリスト

        //設定情報保存用オブジェクト
        Settings settings = new Settings();

        public Form1() {

            InitializeComponent();
            dgvCarReports.DataSource = CarReports;

        }

        private void btImageOpen_Click( object sender , EventArgs e ) {

            if( ofdImageFileOpen.ShowDialog() == DialogResult.OK )      //ダイアログが開かれる、xボタン対策
            {

                //ofdImageFileOpen.ShowDialog();      //ダイアログが開かれる
                pbCarImage.Image = Image.FromFile( ofdImageFileOpen.FileName );     //開くとセットされる

            }

        }

#if Mywork

        #region 自力

        private int mode = 0;

        private void Form1_Load( object sender , EventArgs e ) {

            dgvCarReports.Columns[ 5 ].Visible = false;     //画像項目非表示

            btModifiReport.Enabled = false;     //マスクする
            btDeleteReport.Enabled = false;
            authorNameNotInput.Visible = false;
            carNameNotInput.Visible = false;

            //設定ファイルを逆シリアル化して背景を設定
            using ( var reader = XmlReader.Create( "settings.xml" ) )
            {

                var serializer = new XmlSerializer( typeof( Settings ) );
                settings = serializer.Deserialize( reader ) as Settings;
                //settings = ( Settings )serializer.Deserialize( reader );

                try
                {

                    BackColor = Color.FromArgb( settings.MainFormColor );

                }
                catch ( Exception )
                {

                    BackColor = Color.AliceBlue;    //エラーはデフォルトの色で

                }

            }

        }

        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click( object sender , EventArgs e ) {

            var addCarReport =
                new CarReport
                {

                    Date = dtpDate.Value.Date,
                    Author = cbAuthor.Text,
                    Maker = getSelectedMaker(),
                    CarName = cbCarName.Text,
                    Report = tbReport.Text,
                    CarImage = pbCarImage.Image,

                };

            if ( updateErrorMessage( addCarReport ) ) return;

            if ( !cbAuthor.Items.Contains( cbAuthor.Text ) )
            {
                cbAuthor.Items.Add(cbAuthor.Text);
            }

            if ( !cbCarName.Items.Contains( cbCarName.Text ) )
            {
                cbCarName.Items.Add( cbCarName.Text );
            }

            CarReports.Add( addCarReport );

            noSelect();

        }

        private void noSelect() {

            //dtpDate.Value = ;
            cbAuthor.Text = "";
            nullSelectedMaker();
            cbCarName.Text = "";
            tbReport.Text = "";
            pbCarImage.Image = null;
            dgvCarReports.ClearSelection();

        }

        public CarReport.MakerGroup getSelectedMaker() { 

            switch ( int.Parse( ( string )gbMaker.Controls.Cast< RadioButton >().FirstOrDefault( rb => rb.Checked )?.Tag ?? "-1" ) )
            {

                case 0 : return CarReport.MakerGroup.トヨタ;
                case 1 : return CarReport.MakerGroup.日産;
                case 2 : return CarReport.MakerGroup.ホンダ;
                case 3 : return CarReport.MakerGroup.スバル;
                case 4 : return CarReport.MakerGroup.スズキ;
                case 5 : return CarReport.MakerGroup.ダイハツ;
                case 6 : return CarReport.MakerGroup.輸入車;

                default : return CarReport.MakerGroup.その他; 
                
            }

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

            noSelect();


        }

        //レコードの選択時
        private void dgvCarReports_Click( object sender , EventArgs e ) {
        
            dtpDate.Value = ( DateTime )dgvCarReports.CurrentRow.Cells[ 0 ].Value;
            cbAuthor.Text = dgvCarReports.CurrentRow.Cells[ 1 ].Value.ToString();
            CheckSelectedMaker();
            cbCarName.Text = dgvCarReports.CurrentRow.Cells[ 3 ].Value.ToString();
            tbReport.Text = dgvCarReports.CurrentRow.Cells[ 4 ].Value.ToString();
            pbCarImage.Image = ( Image )dgvCarReports.CurrentRow.Cells[ 5 ].Value;

            openAccess();

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

        private void nullSelectedMaker() {

            rbToyota.Checked = false;
            rbNissan.Checked = false;
            rbHonda.Checked = false;
            rbSubaru.Checked = false;
            rbSuzuki.Checked = false;
            rbDaihatsu.Checked = false;
            rbImported.Checked = false;
            rbOther.Checked = false;

        }

        private void カラーToolStripMenuItem_Click( object sender , EventArgs e ) {

            var cd = new ColorDialog();

            if ( cd.ShowDialog() == DialogResult.OK )
            {

                this.BackColor = cd.Color;
                settings.MainFormColor = BackColor.ToArgb();

            }

        }

        private void 編集EToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void btImageDelete_Click( object sender , EventArgs e ) {

            pbCarImage.Image = null;

        }

        private void btScaleChange_Click( object sender , EventArgs e ) {

            pbCarImage.SizeMode = ( PictureBoxSizeMode )( mode++ % 5 );        // = ナシは mode オーバーフローのもと

        }

        private void Form1_FormClosed( object sender , FormClosedEventArgs e ) {

            using ( var writer = XmlWriter.Create( "settings.xml" ) )       //xml ファイルに書き込む
            {

                var serializer = new XmlSerializer( settings.GetType() );
                serializer.Serialize( writer , settings );

            }

        }

        #endregion

#elif Answer

        #region 模範解答

        //private uint mode;       //クラス変数
        private PictureBoxSizeMode mode;

        private void Form1_Load( object sender , EventArgs e ) {

            authorNameNotInput.Visible = false;
            carNameNotInput.Visible = false;


            dgvCarReports.Columns[ 5 ].Visible = false;     //画像項目非表示

            btModifiReport.Enabled = false;     //修正ボタン無効　マスクする
            btDeleteReport.Enabled = false;     //削除ボタン無効

            //tsInfoText.Text = "ここにメッセージを入力してください。";     //メッセージの表示
            //tsInfoText.Text = "";     //メッセージの非表示

            //設定ファイルを逆シリアル化して背景を設定
            using ( var reader = XmlReader.Create( "settings.xml" ) )
            {

                var serializer = new XmlSerializer( typeof( Settings ) );
                settings = serializer.Deserialize( reader ) as Settings;        // as : 参照のキャスト
                //settings = ( Settings )serializer.Deserialize( reader );        //多分エラー
                BackColor = Color.FromArgb( settings.MainFormColor );

            }

        }

        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click( object sender , EventArgs e ) {

            statusLabelDisp();      //ステータスラベルのテキスト非表示

            if ( cbAuthor.Equals( "" ) )       //cbAuthor.Text == "" でも可
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
                Maker = getSelectedMaker() ,
                CarName = cbCarName.Text ,
                Report = tbReport.Text ,
                CarImage = pbCarImage.Image ,

            };

            CarReports.Add( CarReport );

            //btModifiReport.Enabled = true;

            //メソッド化するべき
            //if ( !cbAuthor.Items.Contains( cbAuthor.Text ) )
            //{
            //    cbAuthor.Items.Add( cbAuthor.Text );
            //}

            setCbAuthor( cbAuthor.Text );      //記録者コンボボックスの履歴登録処理
            setCbCarName( cbCarName.Text );    //車名コンボボックスの履歴登録処理

            editItemsClear();       //項目クリア処理

        }

        //記録者コンボボックスの履歴登録処理
        private void setCbAuthor( string author ) {

            if ( !cbAuthor.Items.Contains( author ) )
            {
                cbAuthor.Items.Add( author );
            }

        }
        
        //車名コンボボックスの履歴登録処理
        private void setCbCarName( string carname ) {

            if ( !cbCarName.Items.Contains( carname ) )
            {
                cbCarName.Items.Add( carname );
            }

        }


        //項目クリア処理
        private void editItemsClear() {

            cbAuthor.Text = "";
            setSelectedMaker( CarReport.MakerGroup.トヨタ );
            cbCarName.Text = "";
            tbReport.Text = "";
            pbCarImage.Image = null;

            dgvCarReports.ClearSelection();     //選択解除

            btModifiReport.Enabled = false;     //修正ボタン
            btDeleteReport.Enabled = false;     //削除ボタン


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

            editItemsClear();

        }

        //レコードの選択時
        private void dgvCarReports_Click( object sender , EventArgs e ) {

            //int count = dgvCarReports.RowCount;

            if ( dgvCarReports.Rows.Count != 0 )
            {

                //var data = dgvCarReports.CurrentRow.Cells[ 3 ].Value;       //[ i ] 列目を取り出す方法

                dtpDate.Value = ( DateTime )dgvCarReports.CurrentRow.Cells[ 0 ].Value;
                cbAuthor.Text = dgvCarReports.CurrentRow.Cells[ 1 ].Value.ToString();

                //var temp = dgvCarReports.CurrentRow.Cells[ 2 ].Value;
                //setSelectedMaker( ( CarReport.MakerGroup )temp );

                setSelectedMaker( ( CarReport.MakerGroup )dgvCarReports.CurrentRow.Cells[ 2 ].Value );

                cbCarName.Text = dgvCarReports.CurrentRow.Cells[ 3 ].Value.ToString();
                tbReport.Text = dgvCarReports.CurrentRow.Cells[ 4 ].Value.ToString();
                pbCarImage.Image = ( Image )dgvCarReports.CurrentRow.Cells[ 5 ].Value;

                btModifiReport.Enabled = true;     //修正ボタン有効
                btDeleteReport.Enabled = true;     //削除ボタン有効

            }

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

        private void btImageDelete_Click( object sender , EventArgs e ) {

            pbCarImage.Image = null;

        }

        private void カラーToolStripMenuItem_Click( object sender , EventArgs e ) {

            //キャンセルすると黒になる
            //cdColor.ShowDialog();
            //BackColor = cdColor.Color;

            if( cdColor.ShowDialog() == DialogResult.OK )       //キャンセル対策
            {

                BackColor = cdColor.Color;      //this.なしでもOK
                settings.MainFormColor = cdColor.Color.ToArgb();        // . のインテリセンスで一番上に出てくる

            }

        }

        private void btScaleChange_Click( object sender , EventArgs e ) {

            //一例
            //pbCarImage.SizeMode = PictureBoxSizeMode.StretchImage;

            //変化なし
            //int mode = 0;
            //pbCarImage.SizeMode = ( PictureBoxSizeMode )mode;
            //mode++;

            //正解
            //if( mode > 4 ) mode = 0;

            //pbCarImage.SizeMode = ( PictureBoxSizeMode )mode;

            //mode = mode < 5 ? ++mode : 0 ;      //mode++だと変化なし
            //pbCarImage.SizeMode = ( PictureBoxSizeMode )mode;

            //mode++;      //mode++ で値の上書き
            //pbCarImage.SizeMode = ( PictureBoxSizeMode )( mode % 5 );

            //2番のモードをスキップ（ AutoSizeキラー ）
            //mode = mode < 4  ? ( ( mode == 1 ) ? 3 : ++mode ) : 0 ;     //AutoSize(2)を除外
            //pbCarImage.SizeMode = ( PictureBoxSizeMode )mode ;

            //そもそも mode の型も最初から PictureBoxSizeMode にしちゃう方式
            mode = mode < PictureBoxSizeMode.Zoom ? 
                ( ( mode == PictureBoxSizeMode.StretchImage ) ? PictureBoxSizeMode.CenterImage : ++mode)       //AutoSize(2)を除外
                                                            : PictureBoxSizeMode.Normal ; 

        }

        private void Form1_FormClosed( object sender , FormClosedEventArgs e ) {

            //設定ファイルのシリアル化
            using ( var writer = XmlWriter.Create( "settings.xml" ) )       //xml ファイルに書き込む
            {

                var serializer = new XmlSerializer( settings.GetType() );
                serializer.Serialize( writer , settings );

            }

        }


        #endregion

#endif

    }

}
