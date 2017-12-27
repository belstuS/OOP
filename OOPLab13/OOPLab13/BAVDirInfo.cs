using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPLab13
{
    class BAVDirInfo
    {
        String nameOfDirectory;
        DirectoryInfo dir;
        BAVDirInfo(String nameOfDirectory)
        {
            this.nameOfDirectory = nameOfDirectory;
            dir = new DirectoryInfo(@"D:\[sdk");
        }
        public void CountOfFiles()
        {
            FileInfo[] sp = dir.GetFiles();
            Console.WriteLine("Count of files in directory {0} = {1}", this.nameOfDirectory, sp.Length);
        }
        public void CountOfDirectories()
        {
            DirectoryInfo[] sp = dir.GetDirectories();
            Console.WriteLine("Count of files in directory {0} = {1}", this.nameOfDirectory, sp.Length);
        }
        public void ParentDirectories()
        {
            Console.WriteLine("List of parent directory: ");
            while (Directory.GetParent(this.nameOfDirectory) != null)
            {
                Console.WriteLine(Directory.GetParent(this.nameOfDirectory).Name);
                Directory.GetParent(this.nameOfDirectory);
            }

        }
    }
}
