#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

#if Mywork

namespace ColorChecker {

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {

            InitializeComponent();
            DataContext = GetColorList();

        }

        //色の変更
        private void Slider_ValueChanged( object sender , RoutedPropertyChangedEventArgs< double > e ) {

            colorArea.Background = new SolidColorBrush( Color.FromRgb( ( byte )rSlider.Value , ( byte )gSlider.Value , ( byte )bSlider.Value ) );

        }

        private void Button_Click( object sender , RoutedEventArgs e ) {

            var color = Color.FromRgb( ( byte )rSlider.Value , ( byte )gSlider.Value , ( byte )bSlider.Value );

            lbColor.Items.Add
                ( 
                    new MyColor { 
                        Color = color 
                    }
                );;

        }

        /// <summary>
        /// すべての色を取得するメソッド
        /// </summary>
        /// <returns></returns>
        public MyColor[] GetColorList() {

            return typeof( Colors ).GetProperties( BindingFlags.Public | BindingFlags.Static )
                .Select( i => new MyColor() { Color = ( Color )i.GetValue( null ) , Name = i.Name } ).ToArray();

        }

        private void lbColor_SelectionChanged( object sender , SelectionChangedEventArgs e ) {

            var selectedColor = ( ( MyColor )( ( ( ListBox )sender ).SelectedItem ) ).Color;

            ColorChange( selectedColor );

        }


        private void ComboBox_SelectionChanged( object sender , SelectionChangedEventArgs e ) {

            var selectedColor = ( ( MyColor )( ( ( ComboBox )sender ).SelectedItem ) ).Color;

            ColorChange( selectedColor );

        }

        //色を変更するメソッド
        private void ColorChange ( Color color ) {

            colorArea.Background = new SolidColorBrush( color );

            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;

        }

    }

    /// <summary>
    /// 色と色名を保持するクラス
    /// </summary>
    public class MyColor {

        public Color Color { get; set; }
        public string Name { get; set; }

        public override string ToString() {

            if ( GetColorList().Where( c => ( c.Color.R == Color.R && c.Color.G == Color.G && c.Color.B == Color.B ) ).Count() != 0 )
                return GetColorList().Where( c => ( c.Color.R == Color.R && c.Color.G == Color.G && c.Color.B == Color.B ) ).First().Name;

            return string.Format( "R:{0:N0} G:{1:N0} B:{2:N0}" , Color.R , Color.G , Color.B );

        }

        /// <summary>
        /// すべての色を取得するメソッド
        /// </summary>
        /// <returns></returns>
        public MyColor[] GetColorList() {

            return typeof( Colors ).GetProperties( BindingFlags.Public | BindingFlags.Static )
                .Select( i => new MyColor() { Color = ( Color )i.GetValue( null ) , Name = i.Name } ).ToArray();

        }

    }

}


#elif Answer



#endif


