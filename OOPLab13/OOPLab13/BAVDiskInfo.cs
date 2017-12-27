using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace OOPLab13
{
    class BAVDiskInfo
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        //1.a
        public void FreeSpaceOnDrive()
        {
            long countOfMemory = 0;
            foreach (DriveInfo each in allDrives)
            {
                countOfMemory += each.AvailableFreeSpace;
            }
            Console.WriteLine("Total availabe space: {0}", countOfMemory);
        }
        //1.b
        public void Filesystem()
        {
            foreach (DriveInfo each in allDrives)
            {
                Console.WriteLine("File system of Drive {0} is {1}", each.Name, each.DriveFormat);
            }
        }
        //1.c
        public void InformationAboutDrives()
        {
            foreach (DriveInfo each in allDrives)
            {
                Console.WriteLine("Drive {0}", each.Name);
                Console.WriteLine("Total size: {0}", each.TotalSize);
                Console.WriteLine("Volume label {0}", each.VolumeLabel);
            }
        }
    }
}
