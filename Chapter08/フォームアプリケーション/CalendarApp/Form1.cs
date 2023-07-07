using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarApp {

    public partial class Form1 : Form {

        public Form1() {

            InitializeComponent();      //絶対消しちゃダメ　すべてのコンポーネントの情報が入っている

        }

#if !true

        #region 自力

        private void btDayCalc_Click( object sender , EventArgs e ) {

            var dtp = dtpDate.Value;
            var duration = DateTime.Now - dtp;

            //tbMessage.Text = "Textプロパティへ文字列を渡すと表示されます。";

            tbMessage.Text = "現在の" + ( duration.Days >= 0 ?
                            duration.Days.ToString() + "日前" : Math.Abs( duration.Days ).ToString() + "日後" );

        }

        private void btForwardYear_Click( object sender , EventArgs e ) {

            dtpDate.Value = dtpDate.Value.AddYears( -1 );

        }

        private void btNextYear_Click( object sender , EventArgs e ) {

            dtpDate.Value = dtpDate.Value.AddYears( 1 );

        }

        private void forwardMonth_Click( object sender , EventArgs e ) {

            dtpDate.Value = dtpDate.Value.AddMonths( -1 );

        }

        private void nextMonth_Click( object sender , EventArgs e ) {

            dtpDate.Value = dtpDate.Value.AddMonths( 1 );

        }

        private void forwardDay_Click( object sender , EventArgs e ) {

            dtpDate.Value = dtpDate.Value.AddDays( -1 );

        }

        private void nextDay_Click( object sender , EventArgs e ) {

            dtpDate.Value = dtpDate.Value.AddDays( 1 );

        }

        //イベントハンドラ　
        //実行時に一度だけ呼び出されるメソッド
        private void Form1_Load( object sender , EventArgs e ) {

            tbTimeNow.Text = DateTime.Now.ToString( "G" );

        }

        private void btAge_Click( object sender , EventArgs e ) {

            var target = DateTime.Now;
            var birth = dtpDate.Value;
            var age = target.Year - birth.Year;

            if( target < birth.AddYears( age ) ) age--;

            tbMessage.Text = age + "歳";

        }

        #endregion

#else

        #region 模範解答

        private void btDayCalc_Click( object sender , EventArgs e ) {

            var dtp = dtpDate.Value;
            var now = DateTime.Now;

            //tbMessage.Text = "Textプロパティへ文字列を渡すと表示されます。";

            tbMessage.Text = "入力した日にちから" + ( now - dtp ).Days + "日経過";
            

        }

        //イベントハンドラ　
        //実行時に一度だけ呼び出されるメソッド
        private void Form1_Load( object sender , EventArgs e ) {

            tbTimeNow.Text = DateTime.Now.ToString( "yyyy年MM月dd日(dddd) HH時mm分ss秒" );
            //?


        }

        //なくてもいい感じ
        private void btForwardYear_Click( object sender , EventArgs e ) {

        }

        //private void btNextYear_Click( object sender , EventArgs e ) {

        //}

        private void forwardMonth_Click( object sender , EventArgs e ) {

        }

        private void nextMonth_Click( object sender , EventArgs e ) {

        }

        private void forwardDay_Click( object sender , EventArgs e ) {

        }

        private void nextDay_Click( object sender , EventArgs e ) {
        
        }

        private void btAge_Click( object sender , EventArgs e ) {

            var age = btAge( dtpDate.Value , DateTime.Now );
            tbMessage.Text = "あなたの年齢は" + "歳です。";

        }

        private int btAge( DateTime birthday , DateTime targetDay ) {

            var age = targetDay.Year - birthday.Year;

            if( targetDay < birthday.AddYears( age ) ) age--;

            return age;

        }

        //タイマーイベントハンドラー
        private void tmTimeDisp_Tick( object sender , EventArgs e ) {

            tbTimeNow.Text = DateTime.Now.ToString( "yyyy年MM月dd日(dddd) HH時mm分ss秒" );

        }

        private void btNextYear_Click( object sender , EventArgs e ) {

            dtpDate.Value = dtpDate.Value.AddYears( 1 );
            tbMessage.Text = dtpDate.Value.AddYears( 1 ).ToShortDateString();

        }

        #endregion

#endif



    }

}
