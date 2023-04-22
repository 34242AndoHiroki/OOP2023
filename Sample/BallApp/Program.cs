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

        List< SoccerBall > balls = new List< SoccerBall >();
        List< PictureBox > pbs = new List< PictureBox >();
        List< Timer > timers = new List< Timer >();

        static void Main(string[] args) {

            Application.Run(new Program());

        }

        public Program() {

            this.Size = new Size(800, 600);     //上2つをいっきにやってくれる
            this.BackColor = Color.Green;       //背景色を緑にする
            this.Text = "BallGame";     //左上にン名前を表示
            this.MouseClick += Program_MouseClick;

            moveTimer = new Timer();
            moveTimer.Interval = 1;     //タイマーのインターバル（ms）

            moveTimer.Tick += MoveTimer_Tick;

        }

        //マウスクリック時のイベントハンドラ
        private void Program_MouseClick(object sender, MouseEventArgs e)
        {

            //ボールインスタンス生成
            soccerBall = new SoccerBall( e.X - 25 , e.Y - 25 );
            pb = new PictureBox();       //画像を表示するコントロール
            pb.Image = soccerBall.Image;        //イメージの引っ張り出し
            pb.Location = new Point((int)soccerBall.PosX, (int)soccerBall.PosY);        //画像の位置　(int)はしゃあない
            pb.Size = new Size(50, 50);     //画像の表示サイズ
            pb.SizeMode = PictureBoxSizeMode.StretchImage;      //画像の表示モード

            pb.Parent = this;       //no form  form = this ！

            balls.Add( soccerBall );
            pbs.Add( pb );

            moveTimer.Start();      //タイマースタート

        }

        private void MoveTimer_Tick(Object sender, EventArgs e ) {

            for ( int i = 0 ; i < balls.Count ; i++ )
            {

                balls[ i ].Move();     //移動
                pbs[ i ].Location = new Point((int)balls[ i ].PosX, (int)balls[ i ].PosY);        //画像の位置

            }

        }
    }
}
