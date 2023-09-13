using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem.Models {

    public class Author {

        public int Id { get; set; }         //主キー

        [ MaxLength( 30 ) ]     //最大文字数　もちろん MinLength（最小文字数）もある
        [ Required ]        //必須項目
        public string Name { get; set; }

        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public virtual ICollection< Book > Books { get; set; }      //他のエンティティを参照させる場合に virtual

    }

}
