#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader {

    public class ItemData {

#if Mywork

        #region 自力

        public string Title { get; set; }
        public string Link { get; set; }

        public override string ToString() => Title;

        #endregion

#elif Answer

        #region 模範解答

        public string Title { get; set; }       //タイトルを保持する
        public string Link { get; set; }

        #endregion

#endif

    }

}
