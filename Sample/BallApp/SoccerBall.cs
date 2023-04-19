using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class SoccerBall {

        //フィールド
        private Image image;        //画像データ

        private double posX;        //ｘ座標
        private double posY;        //ｙ座標

        private double moveX = 10;      //移動量（ｘ方向）    10も可
        private double moveY = 10;      //移動量（ｙ方向）    10も可

        //コンストラクタ
        public SoccerBall() {

            Image = Image.FromFile( @"pic\soccer_ball.png" );        //@：すべて完全な文字列とみなす
            //image = Image.FromFile("pic\\soccerball.png");        //\:エスケープシーケンス、処理記号
            PosX = 0.0;     //０でもいいが、double型だから...
            PosY = 0.0;

        }

        //プロパティ
        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        public Image Image { get => image; set => image = value; }

        //メソッド
        public void Move() {

            Console.WriteLine("Ｘ座標 = {0} , Ｙ座標 = {1}", posX, posY);     //確認用

            /*if ( (PosX + moveX) >= 800 )
            {
                PosX = 799 - (moveX - (799 - PosX));
                moveX *= -1;
            }
            else if((PosX + moveX) < 0)
            {
                PosX = - (moveX - PosX);
                moveX *= -1;
            }*/

            if ( posY > 520 || posY < 0)       //ｙの折り返し処理
            {
                moveY = - moveY;
            }

            if (posX > 720 || posX < 0)       //ｘの折り返し処理
            {
                moveX = -moveX;
            }

            PosX += moveX;
            PosY += moveY;

        }

        




    }
}
