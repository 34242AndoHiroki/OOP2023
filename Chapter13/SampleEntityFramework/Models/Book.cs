using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem.Models {

    public class Book {

        public int Id { get; set; }     //主キー

        [ Required ]        //必須項目
        public string Title { get; set; }

        public int PublishedYear { get; set; }
        public virtual Author Author { get; set; }      //他のエンティティを参照させる場合に virtual

    }

}
