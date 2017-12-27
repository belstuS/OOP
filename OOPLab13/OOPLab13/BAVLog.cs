using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace OOPLab13
{

    class BAVLog
    {
        FileInfo file1 =  new FileInfo("..\\BAVlogfile.txt");
        FileStream file;
        public void Call()
        {
            FileSystemWatcher watcher = new FileSystemWatcher("D:\\3сем\\ООП1\\OOP1_Lab13\\BAVDirInfo");
            using (FileStream file = new FileStream("..\\BAVlogfile.txt", FileMode.OpenOrCreate))
            {

                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                watcher.Filter = "*.txt";


                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);

                watcher.EnableRaisingEvents = true;
            }

        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }

   
}
