#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {

    public partial class Form1 : Form {

        //管理用のデータ
        BindingList< CarReport > CarReports = new BindingList< CarReport >();       //バインディングさせるリスト

        public Form1() {

            InitializeComponent();
            dgvCarReports.DataSource = CarReports;

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click( object sender , EventArgs e ) {

#if Mywork

            #region 自力

            CarReports.Add(

                new CarReport
                {
                    Date = dtpDate.Value.Date ,
                    Author = cuAuthor.Text ,
                    //Maker =  ,
                    CarName = cbCarName.Text ,
                    Report = tbReport.Text ,
                    CarImage = pbCarImage.Image ,
                }
                
            );

            #endregion

#elif Answer

            #region 模範解答



            #endregion

#endif

        }

        public CarReport.MakerGroup getSelectedMaker() {

#if Mywork

            #region 自力

            return CarReport.MakerGroup.トヨタ;

            #endregion

#elif Answer

            #region 模範解答

            return CarReport.MakerGroup.トヨタ;

            #endregion

#endif

        }

    }

}
