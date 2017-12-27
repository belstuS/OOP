using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;

namespace Serialization
{
    [Serializable]
    class Program
    {
        static void Main(string[] args)
        {

            Rose plant = new Rose(123143, "dgfh");
            string line;

            Console.WriteLine("Объект создан");

            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("plant.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, plant);

                Console.WriteLine("Объект сериализован");
            }
          
            Console.WriteLine("\n");

            // десериализация из файла people.dat
            using (FileStream fs = new FileStream("plant.dat", FileMode.OpenOrCreate))
            {
                Rose pl = (Rose)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine("Цена: {0} --- Цвет: {1}", pl.Price, pl.Color);
            }

            Console.WriteLine("\n");
            Console.WriteLine("\n");

//////////////////////////////////////////////////////

            SoapFormatter formatter2 = new SoapFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("plant.json", FileMode.OpenOrCreate))
            {
                formatter2.Serialize(fs, plant);

                Console.WriteLine("Объект сериализован");
            }

            using (StreamReader sr = new StreamReader("plant.json"))
            {

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            using (FileStream fs = new FileStream("plant.json", FileMode.OpenOrCreate))
            {
                Rose pl = (Rose)formatter2.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine("Цена: {0} --- Цвет: {1}", pl.Price, pl.Color);
            }

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            /////////////////////////////////////////////////

            Rose p1 = new Rose(1231,"asfdgdf");
       
            XmlSerializer f = new XmlSerializer(typeof(Rose));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("p.xml", FileMode.OpenOrCreate))
            {
                f.Serialize(fs, p1);

                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream("p.xml", FileMode.OpenOrCreate))
            {
                Rose rose = (Rose)f.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine("Имя: {0} --- Возраст: {1}", rose.Price, rose.Color);
            }

            Console.WriteLine("\n");
            Console.WriteLine("\n");

            ////////////////////////////////////////////////


            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Rose));
              
            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, p1);
            }

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                Rose p = (Rose)jsonFormatter.ReadObject(fs);

                    Console.WriteLine("Имя: {0} --- Возраст: {1}", p.Color, p.Price);
                
            }


            Rose p21 = new Rose(1231, "asfdgdf");
            Rose p2 = new Rose(1231, "asfdgdf");
            Rose p3 = new Rose(1231, "asfdgdf");

            Rose[] arr = { p21, p2, p3 };

            BinaryFormatter json = new BinaryFormatter();

            using (FileStream fs = new FileStream("plant.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, plant);

                Console.WriteLine("Объект сериализован");
            }

            Console.WriteLine("\n");

            // десериализация из файла people.dat
            using (FileStream fs = new FileStream("plant.dat", FileMode.OpenOrCreate))
            {
                Rose pl = (Rose)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                foreach (Rose item in arr)
                {

                Console.WriteLine("Цена: {0} --- Цвет: {1}", pl.Price, pl.Color);
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("\n");


            XDocument xDOC = new XDocument();
            XElement price = new XElement("price", "12");
            XElement color = new XElement("color", "red");
            XElement Rose = new XElement("Roses");

            Rose.Add(price);
            Rose.Add(color);

            XElement Flowers = new XElement("Flowers");
            Flowers.Add(Rose);

            xDOC.Add(Flowers);
            xDOC.Save("linqtoxml.xml");
            XDocument xdoc = XDocument.Load("linqtoxml.xml");

            var items = from xe in xdoc.Element("Flowers").Elements("Roses")
                        select new Rose
                        {
                            Color = xe.Element("color").Value,
                            Price = Convert.ToInt32(xe.Element("price").Value)
                        };

            foreach (var item in items)
            {
                Console.WriteLine("Color of ROse: " + item.Price);
                Console.WriteLine("Price of ROse: " + item.Color);
            }
            XmlDocument xDocument = new XmlDocument();
            xDocument.Load("linqtoxml.xml");
            XmlElement xRoot = xDocument.DocumentElement;

            // выбор всех дочерних узлов
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);

            XmlNodeList infoRose = xRoot.SelectNodes("//Roses/color");
            foreach (XmlNode n in infoRose)
                Console.WriteLine(n.OuterXml);

        }

      }

          
    [Serializable]
    public class Rose 
    {
        public int Price;
        public string Color;
        public Rose()
        {

        }
        public Rose(int pric, string col)
        {

            Price = pric;
            Color = col;

        }
     

    }
}
