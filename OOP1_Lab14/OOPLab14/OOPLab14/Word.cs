using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Lab_14_OOP
{
    [Serializable]
    [DataContract]
    public class Word : PO
    {
        [DataMember]
        public double version { get; set; }
        [DataMember]
        public const string companyManyfacturer = "Microsoft";
        public Word(string name, double ver) : base(name)
        {
            this.version = ver;
            this.koderName = name;
        }
        public Word() { }
        public void Create()
        {
            Console.WriteLine("Программа установлена");
        }
        public void Delete()
        {
            Console.WriteLine("Программа удалена");
        }
    }
}
