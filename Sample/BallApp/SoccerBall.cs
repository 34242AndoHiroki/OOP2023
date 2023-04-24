﻿using System;
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

        private double moveX;      //移動量（ｘ方向）
        private double moveY;      //移動量（ｙ方向）

        private static int count;     //ボールに個数情報を持たせる方法

        //コンストラクタ
        public SoccerBall( double xp , double yp ) {

            Random random = new Random();       //乱数インスタンス

            this.Image = Image.FromFile( @"pic\soccer_ball.png" );        //@：すべて完全な文字列とみなす
            this.PosX = xp;     //０でもいいが、double型だから...
            this.PosY = yp;

            //条件演算子
            int rndX = random.Next(-15, 15);
            this.moveX = ( rndX != 0 ? rndX : 1 );       //乱数で移動量を設定

            int rndY = random.Next(-15, 15);
            this.moveY = ( rndY != 0 ? rndY : 1 );     //乱数で移動量を設定

            //Count++;

        }

        //プロパティ
        public double PosX { get => posX; set => posX = value; }        //いわゆるカプセル化
        public double PosY { get => posY; set => posY = value; }
        public Image Image { get => image; set => image = value; }
        //public static int Count { get => count; set => count = value; }     //見てるのはこれ。静的にする必要あり

        //メソッド
        public void Move() {

            Console.WriteLine("Ｘ座標 = {0} , Ｙ座標 = {1}", posX, posY);     //確認用

            if ( posY > 510 || posY < 0)       //ｙの折り返し処理
            {
                moveY = - moveY;
            }

            if (posX > 730 || posX < 0)       //ｘの折り返し処理
            {
                moveX = -moveX;
            }

            PosX += moveX;
            PosY += moveY;

        }

    }

}
