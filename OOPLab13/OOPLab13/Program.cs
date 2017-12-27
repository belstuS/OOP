using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace OOPLab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread fileThread = new Thread(() =>
            {
                BAVLog log = new BAVLog();
                log.Call();
            });
            Thread fileThread1 = new Thread(() =>
            {
                BAVFileManager exp1 = new BAVFileManager("D:\\");
                exp1.listOfDirectory();
                Console.ReadKey();
            });
            fileThread.Start();
            fileThread1.Start();
        }
    }
}
