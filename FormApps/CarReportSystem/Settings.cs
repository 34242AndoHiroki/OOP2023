using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {

    //設定情報
    public class Settings {

        private static Settings instance;

        public int MainFormColor { get; set; }      //設定した色を記憶してくれる
        //public Color MainFormColor { get; set; }      //これなら cbColor.color で解決。

        //コンストラクタ
        //public Settings() { }     //普通のコンストラクタ

        private Settings() { }      //このままだとアクセスできなくてエラー

        public static Settings getInstance() {

            if ( instance == null ) {       //なければ作る
                instance = new Settings();
            }

            return instance;        //あれば返す

        }

    }

}
