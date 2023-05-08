using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    //抽象クラス
    abstract class Obj {        //ボールに共通することの寄せ集め

        //フィールド
        private Image image;        //画像データ

        private double posX;        //ｘ座標
        private double posY;        //ｙ座標

        private double moveX;      //移動量（ｘ方向）
        private double moveY;      //移動量（ｙ方向）

        //private static int count;     //ボールに個数情報を持たせる方法

        //プロパティ
        public Image Image { get => image; set => image = value; }
        public double PosX { get => posX; set => posX = value; }        //いわゆるカプセル化
        public double PosY { get => posY; set => posY = value; }
        public double MoveX { get => moveX; set => moveX = value; }     //忘れ物
        public double MoveY { get => moveY; set => moveY = value; }     //忘れ物


        //コンストラクタ
        public Obj( double PosX , double PosY , String Path ) {
                    //thisなし：ローカル変数　thisあり：インスタンスの変数        区別される

            this.PosX = PosX;
            this.PosY = PosY;
            Image = Image.FromFile( Path );

            //後ほど追加あり

            //Count++;

        }

        //public static int Count { get => count; set => count = value; }     //見てるのはこれ。静的にする必要あり

        //移動メソッド（抽象メソッド）
        public abstract void Move( PictureBox pbBar , PictureBox pbBox );
        public abstract void Move( Keys direction );


    }

}

