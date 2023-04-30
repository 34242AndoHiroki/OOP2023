using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Bar : Obj{

        public Bar( double xp , double yp ) : base( xp , yp , @"C:\Users\ha34242j\source\repos\OOP2023\Sample\BallApp\pic\bar.png") {

            base.MoveX = 10;  //baseは親クラスのメンバにアクセスできる
            base.MoveY = 0;

        }

        //抽象クラスを継承しているので、不要なメソッドは空にする
        public override void Move() {

            //Console.WriteLine("Ｘ座標 = {0} , Ｙ座標 = {1}", PosX, PosX);     //確認用

            ;       //（空のメソッドにする）

        }

        public void Move( Keys direction ) {

            // PosX += 20;       //移動するかの確認用

            if( direction == Keys.Right )
            {

                PosX = ( PosX + 20 <= 650 ? PosX + 20 :  650 );

            }
            else if ( direction == Keys.Left )
            {

                PosX = ( PosX - 20 >= 0 ? PosX - 20 : 0 );

            }


            /*switch ( Keys )       //何かすると全パターン表示してくれるとか
            {



            }*/

        }

    }
}
