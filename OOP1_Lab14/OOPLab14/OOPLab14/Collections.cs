using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.Collections;
using System.Xml.Serialization;

namespace Lab_14_OOP
{
    public class Collections
    {

        [XmlArray("Collection"), XmlArrayItem("Item")]
        public List<Word> Collection { get; set; }
    }
}
