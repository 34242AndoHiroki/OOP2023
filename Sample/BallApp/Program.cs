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

            //form.Show();      //フォームを表示　Run使えば勝手にこれやってくれる
            //this.ShowDialog();      //フォームのダイアログを表示　Run使えば勝手にこれやってくれる

            //ボールインスタンス
            soccerBall = new SoccerBall();
            pb = new PictureBox();       //画像を表示するコントロール
            pb.Image = soccerBall.Image;        //イメージの引っ張り出し
            pb.Location = new Point((int)soccerBall.PosX, (int)soccerBall.PosY);        //画像の位置　(int)はしゃあない
            pb.Size = new Size(50, 50);     //画像の表示サイズ
            pb.SizeMode = PictureBoxSizeMode.StretchImage;      //画像の表示モード

            pb.Parent = this;       //no form  form = this ！

            moveTimer = new Timer();
            moveTimer.Interval = 1;     //タイマーのインターバル（ms）
            moveTimer.Start();      //タイマースタート
            moveTimer.Tick += MoveTimer_Tick;

            

        }

        private void MoveTimer_Tick(Object sender, EventArgs e ) {

            soccerBall.Move();     //移動
            pb.Location = new Point((int)soccerBall.PosX, (int)soccerBall.PosY);        //画像の位置

        }
    }
}
