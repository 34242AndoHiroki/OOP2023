using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Bar : Obj{

        public Bar( double xp , double yp ) : base( xp , yp , @"C:\Users\ha34242j\source\repos\OOP2023\Sample\BallApp\pic\bar.png") {


        public Bar( double xp , double yp ) : base( xp , yp , @"pic\bar.png") {

            base.MoveX = 10;  //baseは親クラスのメンバにアクセスできる
            base.MoveY = 0;

        }


        //抽象クラスを継承しているので、不要なメソッドは空にする
        public override void Move( PictureBox pbBar , PictureBox pbBox ) {

            //Console.WriteLine("Ｘ座標 = {0} , Ｙ座標 = {1}", PosX, PosX);     //確認用

            ;       //（空のメソッドにする）

        }

        public override void Move( Keys direction ) {

            // PosX += 20;       //移動するかの確認用

            if( direction == Keys.Right )
            {

                //PosX = ( PosX + MoveX <= 650 ? PosX + MoveX :  650 );

                if ( PosX < 635 )
                {
                    PosX += MoveX;
                }

            }
            else if ( direction == Keys.Left )
            {

                //PosX = ( PosX - MoveX >= 0 ? PosX - MoveX : 0 );

                if( PosX > 0 )
            {
                    PosX -= MoveX;
                }

            }

        }

    }
}
