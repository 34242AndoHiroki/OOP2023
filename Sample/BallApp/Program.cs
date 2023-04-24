using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;     //Javaだと import System.Windows.Forms.Formか*;
using System.Drawing;

namespace BallApp {
    class Program : Form {      //A : B = AはBを継承

        private Timer moveTimer;        //タイマー用
        private SoccerBall soccerBall;
        private PictureBox pb;       //画像を表示するコントロール

        private List<SoccerBall> balls = new List<SoccerBall>();      //ボールインスタンス格納用　同じことを書いてる
        ///private var balls = new List<>();        //型推論型　ここでは無理　メソッド内でやって
        private List<PictureBox> pbs = new List<PictureBox>();  //表示用

        static void Main(string[] args) {

            Application.Run(new Program());

        }

        public Program() {

            //Form form = new Form();     //Formを新規作成
            //System.Windows.Forms.Form form = new System.Windows.Forms.Form();     // 長い

            //this.Width = 1200;  //幅プロパティ    Javaでいうメンバ変数
            //this.Height = 800;  //高さプロパティ
            this.Size = new Size(800, 600);     //上2つをいっきにやってくれる
            this.BackColor = Color.Green;       //背景色を緑にする
            this.Text = "BallGame";     //左上にン名前を表示
            this.MouseClick += Program_Mouseclick;

            //form.Show();      //フォームを表示　Run使えば勝手にこれやってくれる
            //this.ShowDialog();      //フォームのダイアログを表示　Run使えば勝手にこれやってくれる

            moveTimer = new Timer();
            moveTimer.Interval = 1;     //タイマーのインターバル（ms）
            moveTimer.Start();      //タイマースタート
            moveTimer.Tick += MoveTimer_Tick;       //デリゲート登録

            

        }

        //マウスクリック時のイベントハンドラ
        private void Program_Mouseclick( object sender , MouseEventArgs e ) {

            //ボールインスタンス生成
            soccerBall = new SoccerBall( e.X - 25 , e.Y - 25 );       //座標をもらう
            pb = new PictureBox();       //画像を表示するコントロール
            pb.Image = soccerBall.Image;        //イメージの引っ張り出し
            pb.Location = new Point((int)soccerBall.PosX, (int)soccerBall.PosY);        //画像の位置　(int)はしゃあない
            pb.Size = new Size(50, 50);     //画像の表示サイズ
            pb.SizeMode = PictureBoxSizeMode.StretchImage;      //画像の表示モード
            pb.Parent = this;       //no form  form = this ！

            balls.Add(soccerBall);
            pbs.Add(pb);

            moveTimer.Start();      //タイマースタート

        }

        //タイマータイムアウト時のイベントハンドラ
        private void MoveTimer_Tick(Object sender, EventArgs e ) {

            for (int i = 0; i < balls.Count; i++)
            {

                balls[i].Move();     //移動
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);        //画像の位置

            }


        }
    }
}
