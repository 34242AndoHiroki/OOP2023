﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {

    class TennisBall : Obj {

        //フィールド
        private double moveX;   //移動量（ｘ方向）
        private double moveY;   //移動量（ｙ方向）
        //private static int count;   //インスタンスの個数

        Random random = new Random();

        //プロパティ
        public double MoveX { get => moveX; set => moveX = value; }     //忘れ物
        public double MoveY { get => moveY; set => moveY = value; }     //忘れ物

        //public static int Count { get => count; set => count = value; }     //見てるのはこれ。静的にする必要あり

        //コンストラクタ
        public TennisBall(double xp, double yp)
            : /* 基底 */ base(xp, yp, @"pic\tennis_ball.png") {        //親コンストラクタを呼ぶ

            //条件演算子
            int rndX = random.Next(-15, 15);
            this.MoveX = (rndX != 0 ? rndX : 1);       //乱数で移動量を設定

            int rndY = random.Next(-15, 15);
            this.MoveY = (rndY != 0 ? rndY : 1);     //乱数で移動量を設定

        }

        //メソッド

        public override void Move() {

            Console.WriteLine("Ｘ座標 = {0} , Ｙ座標 = {1}", PosX, PosX);     //確認用

            if (PosY > 510 || PosY < 0)       //ｙの折り返し処理
            {
                MoveY = -MoveY;
            }

            if (PosX > 730 || PosX < 0)       //ｘの折り返し処理
            {
                MoveX = -MoveX;
            }

            PosX += MoveX;
            PosY += MoveY;

        }

    }

}
