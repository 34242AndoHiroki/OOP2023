using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section01 {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void btRunNotepad_Click( object sender , EventArgs e ) {

            //プロセスをスタートするのみ
            var path = @"%SystemRoot%\system32\notepad.exe";        //メモ帳
            var fullpath = Environment.ExpandEnvironmentVariables( path );      //パスから完全パスの取得をする

            var startInfo = new ProcessStartInfo
            {

                FileName = fullpath ,           //場所
                Arguments = @"C:\temp\Sample.txt" ,     //ファイル名
                WindowStyle = ProcessWindowStyle.Maximized ,        //表示モード

            };

            //Process.Start( fullpath );      //指定されたプロセス（タスク）のスタート
            Process.Start( startInfo );

        }

        private void btRunAndWaitNotepad_Click( object sender , EventArgs e ) {
            //プロセスをスタート＆終了
            RunAndWaitNotepad();
            MessageBox.Show( "終了" );

        }

        private static int RunAndWaitNotepad() {

            var path = @"%SystemRoot%\system32\notepad.exe";
            var fullpath = Environment.ExpandEnvironmentVariables( path );

            using ( var process = Process.Start( fullpath ) ) {

                if ( process.WaitForExit( 10000 ) )     // 10s 以内に閉じるか = 10秒まで待ってくれる
                    return process.ExitCode;            // ExitCode : 0 : 正常終了　1 : 異常終了

                throw new TimeoutException();       //タイムアウトのエラー

            }

        }

    }

}
