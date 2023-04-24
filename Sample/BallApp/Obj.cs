using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    //抽象クラス
    abstract class Obj {        //ボールに共通することの寄せ集め

        //フィールド
        private Image image;        //画像データ

        private double posX;        //ｘ座標
        private double posY;        //ｙ座標

        private double moveX;      //移動量（ｘ方向）
        private double moveY;      //移動量（ｙ方向）

        private static int count;     //ボールに個数情報を持たせる方法

        //プロパティ
        public double PosX { get => posX; set => posX = value; }        //いわゆるカプセル化
        public double PosY { get => posY; set => posY = value; }
        public Image Image { get => image; set => image = value; }


        //コンストラクタ
        public Obj( double PosX , double PosY , String Path ) {
                    //thisなし：ローカル変数　thisあり：インスタンスの変数        区別される

            this.PosX = PosX;
            this.PosY = PosY;
            Image = Image.FromFile( Path );

            //Count++;

        }

        //public static int Count { get => count; set => count = value; }     //見てるのはこれ。静的にする必要あり

        //移動メソッド（抽象メソッド）
        public abstract void Move();

    }

}

