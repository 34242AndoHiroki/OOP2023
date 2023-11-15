using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace VisibilityConverter {

    public class BooleanToVisibilityConverter : IValueConverter {

        public object Convert( object value , Type targetType , object parameter , CultureInfo culture ) {

            var bValue = value as bool? ?? false;       // ?? : P116 null合体演算子  ?. : P117 null条件演算子　as : 型キャスト  =>  null なら false
            return bValue ? Visibility.Visible : Visibility.Collapsed;      //条件演算子  => true : 表示 , false : 非表示

        }

        public object ConvertBack( object value , Type targetType , object parameter , CultureInfo culture ) {

            return value as Visibility? == Visibility.Visible;

        }

    }

}
