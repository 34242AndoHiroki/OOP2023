using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;     //Javaだと import System.Windows.Forms.Formか*;
using System.Drawing;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace BallApp {
    class Program : Form {      //A : B = AはBを継承

        Bar bar;            //Barインスタンス格納用
        PictureBox pbBar;       //Bar表示用

        private Timer moveTimer;        //タイマー用

        //Listコレクション
        private List<Obj> balls = new List<Obj>();      //ボールインスタンス格納用　同じことを書いてる
        private List<PictureBox> pbs = new List<PictureBox>();  //表示用

        //private int soccerBallCount = 0, tennisBallCount = 0;
        //private int count = 0, count1 = 0;        //こういうの論外

        //private int ballCount = 0;      //変数利用式

        static void Main(string[] args) {

            Application.Run(new Program());

        }

        public Program() {

            //フォーム
            this.Size = new Size(800, 600);     //上2つをいっきにやってくれる
            this.BackColor = Color.Green;       //背景色を緑にする
            //this.Text = "BallGame：" + ( ++ballCount );     //後置　ballCount++　だとおかしい

            this.Text = Comment(SoccerBall.Count, TennisBall.Count);       //インスタンス数え上げ方式

            this.MouseClick += Program_Mouseclick;
            this.KeyDown += Program_KeyDown;        //タブキーで自動挿入

            //Barインスタンス生成
            bar = new Bar(370, 550);
            pbBar = new PictureBox();
            pbBar.Image = bar.Image;
            pbBar.Location = new Point( ( int )bar.PosX , ( int )bar.PosY );
            pbBar.Size = new Size( 150 , 10 );
            pbBar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBar.Parent = this;


            moveTimer = new Timer();
            moveTimer.Interval = 1;     //タイマーのインターバル（ms）
            moveTimer.Start();      //タイマースタート
            moveTimer.Tick += MoveTimer_Tick;       //デリゲート登録

        }


        //キーが押された時のイベントハンドラ
        private void Program_KeyDown(object sender, KeyEventArgs e) {

            bar.Move(e.KeyData);        //e = Keys型 = Enum
            pbBar.Location = new Point((int)bar.PosX, (int)bar.PosY);


        }

        //マウスクリック時のイベントハンドラ
        private void Program_Mouseclick(object sender, MouseEventArgs e) {

            //ボールインスタンス生成
            pbs.Add(new PictureBox());

            if (e.Button == MouseButtons.Left)     //左クリック
            {

                balls.Add(new SoccerBall(e.X - 25, e.Y - 25));
                pbs[pbs.Count - 1].Size = new Size(50, 50);     //画像の表示サイズ

                SoccerBall.Count++;

            }
            else
            {

                balls.Add(new TennisBall(e.X - 25, e.Y - 25));
                pbs[pbs.Count - 1].Size = new Size(25, 25);     //画像の表示サイズ
                TennisBall.Count++;

            }

            //画像を表示するコントロール
            pbs[pbs.Count - 1].Image = balls[balls.Count - 1].Image;        //イメージの引っ張り出し
            pbs[pbs.Count - 1].Location = new Point((int)balls[balls.Count - 1].PosX, (int)balls[balls.Count - 1].PosY);        //画像の位置　(int)はしゃあない
            pbs[pbs.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;      //画像の表示モード
            pbs[pbs.Count - 1].Parent = this;       //no form  form = this ！

            moveTimer.Start();      //タイマースタート

            this.Text = Comment(SoccerBall.Count, TennisBall.Count);
            //this.Text = "ボールの数：" + SoccerBall.Count;  //staticにしたらそれすべて静的にしなきゃいけない

        }



        //タイマータイムアウト時のイベントハンドラ
        private void MoveTimer_Tick(Object sender, EventArgs e) {

            for (int i = 0; i < balls.Count; i++)
            {

                balls[i].Move();     //移動
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);        //画像の位置

            }

        }

        private static string Comment(int sbCount, int tbCount) {

            return "サッカーボール：" + sbCount + "　　テニスボール：" + tbCount;

        }

    }
}
