using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            : /* 基底 */ base(xp, yp, @"C:\Users\ha34242j\source\repos\OOP2023\Sample\BallApp\pic\tennis_ball.png") {        //親コンストラクタを呼ぶ

            //条件演算子
            int rndX = random.Next(-30, 30);
            this.MoveX = (rndX != 0 ? rndX : 1);       //乱数で移動量を設定

            int rndY = random.Next(-30, 30);
            this.MoveY = (rndY != 0 ? rndY : 1);     //乱数で移動量を設定

        }

        //メソッド

        public override void Move() {

            Console.WriteLine("Ｘ座標 = {0} , Ｙ座標 = {1}", PosX, PosX);     //確認用

            if (PosY > 537 || PosY < 0)       //ｙの折り返し処理
            {
                MoveY = -MoveY;
            }

            if (PosX > 760 || PosX < 0)       //ｘの折り返し処理
            {
                MoveX = -MoveX;
            }

            PosX += MoveX;
            PosY += MoveY;

        }

    }

}
