using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {

    public class MainWindowViewModel : ViewModel {

        private double grumValue, poundValue;

        //プロパティ
        public double GrumValue {

            get { return this.grumValue; }

            set {

                this.grumValue = value;
                this.OnPropertyChanged();       //通知が届くようにする

            }

        }

        public double PoundValue {

            get { return this.poundValue; }

            set {       //代入＝セッター

                this.poundValue = value;
                this.OnPropertyChanged();       //通知が届くようにする

            }

        }

        //上のComboBoxで選択されている値（単位）
        public GrumUnit CurrentGrumUnit { get; set; }       //コンボボックスの値にアクセスできるプロパティ

        //上のComboBoxで選択されている値（単位）
        public PoundUnit CurrentPoundUnit { get; set; }   //コンボボックスの値にアクセスできるプロパティ

        //▲ボタンで呼ばれるコマンド
        public ICommand PoundToGrumUnit { get; private set; }

        //▼ボタンで呼ばれるコマンド
        public ICommand GrumToPoundUnit { get; private set; }

        //コンストラクタ
        public MainWindowViewModel() {

            this.CurrentGrumUnit = GrumUnit.Units.ElementAt( 1 );
            this.CurrentPoundUnit = PoundUnit.Units.ElementAt( 1 );

            this.GrumToPoundUnit = new DelegateCommand(            //バインディングしたとき（矢印ボタンを押下したとき）に処理される
                () => this.PoundValue = this.CurrentPoundUnit.FromGrumUnit( this.CurrentGrumUnit , this.GrumValue ) );      //処理の登録

            this.PoundToGrumUnit = new DelegateCommand(            //バインディングしたとき（矢印ボタンを押下したとき）に処理される
                () => this.GrumValue = this.CurrentGrumUnit.FromPoundUnit( this.CurrentPoundUnit , this.PoundValue ) );    //処理の登録

        }

    }

}
