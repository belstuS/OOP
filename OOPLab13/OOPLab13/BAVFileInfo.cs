using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPLab13
{
    class BAVFileInfo
    {
        //полный путь
        //размер расширение имя
        String nameOfFile;
        FileInfo file;
        BAVFileInfo(String nameOfFile)
        {
            this.nameOfFile = nameOfFile;
            file = new FileInfo(nameOfFile);
        }
        public void RootDirectory()
        {
            Console.WriteLine("DirectoryName: {0}", file.DirectoryName);
        }
        public void InformationAboutFile()
        {
            Console.WriteLine("Name of file: {0} ", file.Name);
            Console.WriteLine("Extention of file: {0}", file.Extension);
            Console.WriteLine("Size of file: {0}", file.Length);
        }
        public void TimeOfCreation()
        {
            Console.WriteLine("TimeOfCreation: {0}", file.CreationTime);
        }
    }
}
