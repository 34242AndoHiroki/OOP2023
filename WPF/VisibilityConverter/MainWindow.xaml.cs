﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisibilityConverter {

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {

            InitializeComponent();

            //コンストラクタに書くよりも Window_Loaded の方がいいもかも
            //cbColors.SelectedItem = ColorViewModel.ColorList.ElementAt( 0 );        //自力
            //cbColors.SelectedIndex = 0;

        }

        private void Button_Click( object sender , RoutedEventArgs e ) {

            Resources[ "ButtonBrushKey" ] = new SolidColorBrush( Colors.Gray );

        }

        //模範解答
        private void Window_Loaded( object sender , RoutedEventArgs e ) {

            cbColors.SelectedIndex = 0;

        }

    }

}
