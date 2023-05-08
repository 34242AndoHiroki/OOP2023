using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {

    class TennisBall : Obj {

        //フィールド
        private static int count = 0;
        //private static int count;   //インスタンスの個数

        Random random = new Random();

        //プロパティ
        //public static int Count { get => count; set => count = value; }     //見てるのはこれ。静的にする必要あり
        public static int Count { get => count; set => count = value; }

        //コンストラクタ
        public TennisBall(double xp, double yp)
            : /* 基底 */ base(xp, yp, @"pic\tennis_ball.png") {        //親コンストラクタを呼ぶ

            //条件演算子
            int rndX = random.Next(-20, 20);
            this.MoveX = (rndX != 0 ? rndX : 1);       //乱数で移動量を設定

            int rndY = random.Next(-20, 20);
            this.MoveY = (rndY != 0 ? rndY : 1);     //乱数で移動量を設定

        }

        //メソッド

        public override void Move( PictureBox pbBar , PictureBox pbBox ) {

            Rectangle rBar = new Rectangle(pbBar.Location.X, pbBar.Location.Y,
                                    pbBar.Width, pbBar.Height);

            Rectangle rBall = new Rectangle(pbBox.Location.X, pbBox.Location.Y,
                                                pbBox.Width, pbBox.Height);

            if (PosY > 537 || PosY < 0 || rBar.IntersectsWith(rBall))             //IntersectsWith：重なったかの判定メソッド
            {
                MoveY = -MoveY;
            }

            if (PosX > 760 || PosX < 0)
            {
                MoveX = -MoveX;
            }

            PosX += MoveX;
            PosY += MoveY;

        }

        public override void Move(Keys direction) {
            ;
        }

    }

}
