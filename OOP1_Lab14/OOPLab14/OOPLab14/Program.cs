using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Collections;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Binary;
namespace Lab_14_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            //1 a)
            Word program = new Word("Ann", 1.0);
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("fileforserealiz.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, program);
            }
            using (FileStream newfs = new FileStream("fileforserealiz.dat", FileMode.OpenOrCreate))
            {
                Word newProgram = (Word)formatter.Deserialize(newfs);
            }
            //1 d)
            XmlSerializer xSer = new XmlSerializer(typeof(Word));
            using (FileStream fs = new FileStream("word.xml", FileMode.OpenOrCreate))
            {
                xSer.Serialize(fs, program);
            }
            using (FileStream fs = new FileStream("word.xml", FileMode.OpenOrCreate))
            {
                Word newW = (Word)xSer.Deserialize(fs);
            }
            // 1 c)
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Word));
            using (FileStream fs = new FileStream("word.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fs, program);
            }
            using (FileStream fs = new FileStream("word.json", FileMode.OpenOrCreate))
            {
                Word newJson = (Word)jsonSerializer.ReadObject(fs);
            }
            // 1 b)
            SoapFormatter soap = new SoapFormatter();
            using (FileStream fs = new FileStream("word.soap", FileMode.OpenOrCreate))
            {
                soap.Serialize(fs, program);
            }
            using (FileStream fs = new FileStream("word.soap", FileMode.OpenOrCreate))
            {
                Word newSoapDeserial = (Word)soap.Deserialize(fs);
            }
            #endregion
            //Task 2
            #region
            Word program_2 = new Word("Hz", 2.0);
            Word program_3 = new Word("Ann", 1.0);
            Collections newCol = new Collections();
            newCol.Collection = new List<Word>();
            newCol.Collection.Add(program);
            newCol.Collection.Add(program_2);
            newCol.Collection.Add(program_3);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Collections));
            using (FileStream fs = new FileStream("collection.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, newCol);
            }
            using (FileStream fs = new FileStream("collection.xml", FileMode.OpenOrCreate))
            {
                Collections newColl_1 = (Collections)xmlSerializer.Deserialize(fs);
            }

            #endregion
            //Task 3
            #region
            //XPath request 1
            XDocument xDoc = XDocument.Load("collection.xml");
            foreach (XElement i in xDoc.Element("Collections").Elements("Collection").Elements("Item"))
            {
                XElement name = i.Element("koderName");
                XElement version = i.Element("version");
                using (StreamWriter fs = new StreamWriter("Task_4"))
                {
                    fs.WriteLine(name.Value);
                    fs.WriteLine(version.Value);
                }
            }
            //XPath request 2
            XmlDocument newDoc = new XmlDocument();
            newDoc.Load("collection.xml");
            XmlElement xRoot = newDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);
            #endregion
            //Task 4
            #region
            XDocument xdoc = XDocument.Load("collection.xml");
            var items = from xe in xdoc.Element("Collections").Elements("Collection").Elements("Item")
                        where xe.Element("koderName").Value == "Ann"
                        select xe;
            using (StreamWriter ws = new StreamWriter("Task_5"))
            {
                foreach (var item in items)
                    ws.WriteLine(item);
            }
            #endregion
        }
    }
}
