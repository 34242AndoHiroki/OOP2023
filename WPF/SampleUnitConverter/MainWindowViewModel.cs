using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {

    public class MainWindowViewModel : ViewModel {

        private double metricValue, imperialValue;

        //プロパティ
        public double MetricValue {

            get { return this.metricValue; }

            set {

                this.metricValue = value;
                this.OnPropertyChanged();       //通知が届くようにする

            }

        }

        public double ImperialValue {

            get { return this.imperialValue; }

            set {       //代入＝セッター

                this.imperialValue = value;
                this.OnPropertyChanged();       //通知が届くようにする

            }

        }

        //上のComboBoxで選択されている値（単位）
        public MetricUnit CurrentMetricUnit { get; set; }       //コンボボックスの値にアクセスできるプロパティ

        //上のComboBoxで選択されている値（単位）
        public ImperialUnit CurrentImperialUnit { get; set; }   //コンボボックスの値にアクセスできるプロパティ

        //▲ボタンで呼ばれるコマンド
        public ICommand ImperialToMetricUnit { get; private set; }

        //▼ボタンで呼ばれるコマンド
        public ICommand MetricToImperialUnit { get; private set; }

        //コンストラクタ
        public MainWindowViewModel() {

            this.CurrentMetricUnit = MetricUnit.Units.First();
            this.CurrentImperialUnit = ImperialUnit.Units.First();

            this.MetricToImperialUnit = new DelegateCommand(            //バインディングしたとき（矢印ボタンを押下したとき）に処理される
                () => this.imperialValue = this.CurrentImperialUnit.FromMetricUnit( this.CurrentMetricUnit , this.MetricValue ) );      //処理の登録

            this.ImperialToMetricUnit = new DelegateCommand(            //バインディングしたとき（矢印ボタンを押下したとき）に処理される
                () => this.MetricValue = this.CurrentMetricUnit.FromImperialUnit( this.CurrentImperialUnit , this.ImperialValue ) );    //処理の登録

        }

    }

}
