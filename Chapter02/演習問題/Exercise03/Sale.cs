using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {      //これもまるまるコピー
#if true
    #region 自力
    //売り上げクラス
    public class Sale {

        //店舗名
        public string ShopName { get; set; }
        //商品カテゴリー
        public string ProductCategory { get; set; }
        //売上高
        public int Amount { get; set; }

    }
    #endregion
#else
    #region 模範解答
    //売り上げクラス
    public class Sale {

        //店舗名
        public string ShopName { get; set; }
        //商品カテゴリー
        public string ProductCategory { get; set; }
        //売上高
        public int Amount { get; set; }

    }
    #endregion
#endif
}
