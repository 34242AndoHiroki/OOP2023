using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void btButton_Click(object sender, EventArgs e) {
            //tbNum1.Text = "楽しいＣ＃！！！";       //テキストボックスの編集
            //this.BackColor = Color.MintCream;       //これ（フォーム）の背景色を変更 自身の場合はthisを省略可能
            ///*this.*/btButton.BackColor = Color.Aquamarine;        //ボタンの背景色を変更（this.はいらない。そういう傾向）

            int ans = int.Parse(tbNum1.Text) + int.Parse(tbNum2.Text);
            tbAns.Text = ans.ToString();
            //tbAns.Text = (int.Parse(tbNum1.Text) + int.Parse(tbNum2.Text)).ToString();
            //上の行を分割
            /*int num1 = int.Parse(tbNum1.Text);
            int num2 = int.Parse(tbNum2.Text);
            int sum = num1 + num2;
            tbAns.Text = sum.ToString();*/

        }

        private void tbResult_TextChanged(object sender, EventArgs e) {

            /*int pow = 1;

            for (int i = 0; i < nudY.Value; i++)
            {
                pow *= ( int )nudX.Value;
            }

            return pow;*/

        }

        //イベントハンドラ
        private void btPow_Click(object sender, EventArgs e) {

            //パターン1　for文
            /*int pow = 1;

            for ( int i = 0; i < nudY.Value; i++ )
            {
                pow *= (int)nudX.Value;
            }*/

            //パターン２　powメソッド方式
            double pow = Math.Pow((int)nudX.Value , (int)nudY.Value );
            tbResult.Text = pow.ToString();

            //tbResult.Text = ((double)Math.Pow((int)nudX.Value , (int)nudY.Value )).ToString();  //１行にまとめた

        }

    }
}
