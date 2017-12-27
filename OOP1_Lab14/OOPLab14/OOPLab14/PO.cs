using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Lab_14_OOP
{
    [Serializable]
    [DataContract]
    public class PO
    {
        [DataMember]
        public string koderName;
        public PO(string name)
        {
            koderName = name;
        }
        public PO()
        {
        }
        OperatingSystem os = Environment.OSVersion;
        public void getOfOpereatingSystem()
        {
            Console.WriteLine("Platform:" + os.Platform);
            Console.WriteLine("Major: " + os.Version.Major);
            Console.WriteLine("Minor: " + os.Version.Minor);
        }
    }
}
