﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {

    public partial class VersionForm : Form {

        public VersionForm() {

            InitializeComponent();

        }

        private void btOK_Click( object sender , EventArgs e ) {

            this.Close();       //OK ボタンを押すとダイアログを閉じる

        }

    }

}
