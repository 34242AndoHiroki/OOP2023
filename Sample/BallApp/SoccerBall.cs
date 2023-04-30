using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {

    class SoccerBall : Obj{

        //フィールド
        private static int count = 0;       //ここのカウントはサッカーのってのはわかるよね。全体で共有される。
        //private int count = 0;        //インスタンス変数　これだとインスタンスごとに+１される ＝ ずっと１

        Random random = new Random();

        //プロパティ
        //public static int Count { get => count; set => count = value; }     //見てるのはこれ。静的にする必要あり
        public static int Count { get => count; set => count = value; }

        //コンストラクタ
        public SoccerBall( double xp , double yp ) 
            // ↓ super() と同じ　↓
            : /* 基底 */ base( xp , yp , @"pic\soccer_ball.png") {        //親コンストラクタを呼ぶ

            //条件演算子
            int rndX = random.Next(-15, 15);
            this.MoveX = (rndX != 0 ? rndX : 1);       //乱数で移動量を設定

            int rndY = random.Next(-15, 15);
            this.MoveY = (rndY != 0 ? rndY : 1);     //乱数で移動量を設定

        }


        //メソッド

        public override void Move() {

            Console.WriteLine("Ｘ座標 = {0} , Ｙ座標 = {1}", PosX, PosX);     //確認用

            if ( PosY > 510 || PosY < 0)       //ｙの折り返し処理
            {
                MoveY = - MoveY;
            }

            if (PosX > 730 || PosX < 0)       //ｘの折り返し処理
            {
                MoveX = - MoveX;
            }

            PosX += MoveX;
            PosY += MoveY;

        }
       
    }

}
