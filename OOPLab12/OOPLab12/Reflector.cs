using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace OOPLab12
{
    public class Reflector
    {
        public static void informationAboutClass(Type type)
        {
            string fileName = "information" + type.Name + ".txt";
            using (StreamWriter info = new StreamWriter(fileName))
            {
                info.WriteLine(informationMethods(type));
                info.WriteLine(informationFieldsProperies(type));
                info.WriteLine(informationInterfaces(type));
                info.WriteLine(informationMethodsByParameter(type));
            }
        }
       static String informationMethods(Type type)
        {
            
            String informMethods = "Information about Methods \r\n";
            foreach (MethodInfo method in type.GetMethods())
            {
                informMethods += "Method's Name: " + method.Name + "\r\n";
                informMethods += "Method's return Type: " + method.ReturnType + "\r\n";
                foreach (ParameterInfo param in method.GetParameters())
                {
                    informMethods += "Parameter Name: " + param.Name + "\r\n";
                    informMethods += "Method Name: " + param.ParameterType + "\r\n";
                }
                informMethods += "\r\n";
            }
            return informMethods;
        }
        static String informationFieldsProperies(Type type)
        {
            String informField = "Information about fileds \r\n";
            foreach (FieldInfo field in type.GetFields())
            {
                informField += "Field " + field.Name+ "\r\n";
            }
            return informField;
        }
        static String informationInterfaces(Type type)
        {
            String informationInterfaces = "Information About Interfaces\r\n";
            foreach (Type iType in type.GetInterfaces())
            {
                informationInterfaces += iType.Name;
            }
            return informationInterfaces;
        }
        static String informationMethodsByParameter(Type type)
        {
            String informationMethodByParam = "Methods with paramer type of \r\n";
            Console.WriteLine("Put type of parameter of method: ");
            String parametr = Console.ReadLine();
            informationMethodByParam += parametr;
            bool fl = false;
            foreach (MethodInfo method in type.GetMethods())
            {
                foreach (ParameterInfo paramtrs in method.GetParameters())
                {
                    if (!parametr.Equals(parametr))
                    {
                        fl = true;
                    }
                }
                if (fl)
                {
                    informationMethodByParam += method.Name+"\r\n";
                    fl = false;
                }
            }
            return informationMethodByParam;
        }
        public static void callMethod(String nameClass, String nameMethod)
        {
            string param1, param2;
            using (StreamReader d = new StreamReader("info.txt"))
            {
                param1 = d.ReadLine();
                param2 = d.ReadLine();
                Assembly asm = Assembly.LoadFrom("OOPLab12.exe");
                Type type = asm.GetType("OOPLab12."+nameClass);
                Console.WriteLine(type.Name);
                object obj = Activator.CreateInstance(type);
                MethodInfo method = type.GetMethod(nameMethod);
                object result = method.Invoke(obj, new object[] { param1, param2 });
            }
        }
    }
}
