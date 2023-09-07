//#define Mywork
#define Answer
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Exercise02 {
#if Mywork
    public class Novelist {
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string[] Masterpieces { get; set; }
    }
#elif Answer
    [XmlRoot("novelist")]
    [DataContract]
    public class Novelist {
        [XmlElement(ElementName = "name")]      //P.309
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "birth")]      //P.309
        [DataMember(Name = "birth")]
        public DateTime Birth { get; set; }

        [XmlArray("masterpieces")]
        [XmlArrayItem("title" , typeof(string))]        //配列用
        [DataMember(Name = "masterpieces")]
        public string[] Masterpieces { get; set; }
    }
#endif
}
