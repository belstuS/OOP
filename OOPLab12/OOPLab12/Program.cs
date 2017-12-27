using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Reflection.Emit;
namespace OOPLab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Reflector.informationAboutClass(typeof(Novosti));
            Reflector.callMethod("Novosti", "output");
            Reflector.informationAboutClass(typeof(descriptionOfProgram));
            Console.ReadKey();
        }
    }
};
