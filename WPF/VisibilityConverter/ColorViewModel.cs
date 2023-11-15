using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VisibilityConverter {

    public class ColorViewModel {

        private static IList< ColorViewModel > colors = new List< ColorViewModel >      // IList< T > はインターフェース　生成不可！
        {
            new ColorViewModel{ Name = "赤" , Color = Colors.Red } ,
            new ColorViewModel{ Name = "黄" , Color = Colors.Yellow } ,
            new ColorViewModel{ Name = "青" , Color = Colors.Blue } ,
        };

        public static IList< ColorViewModel > ColorList { get { return colors; } }      //ゲッター　colors の取得

        public string Name { get; set; }
        public Color Color { get; set; }

    }

}
