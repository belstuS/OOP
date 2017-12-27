using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace OOPLab13
{
    class BAVFileManager
    {
        FileStream fileStream;
        FileInfo file1;
        String path = "D:\\3сем\\ООП1\\OOP1_Lab13";
        String nameOfDir = "BAVdirinfo";
        string nameOfFile = "test.txt";
        public BAVFileManager(string nameOfDisk)
        {
            this.nameOfDisk = nameOfDisk;
        }
        string nameOfDisk;
        DriveInfo[] dir;
        DriveInfo dir1;
        static public void CreateDirectory(string path, string nameOfDir)
        {
            DirectoryInfo tryToCreateDir = Directory.CreateDirectory(path);
            if (!tryToCreateDir.Exists)
            {
                tryToCreateDir.Create();
            }
            tryToCreateDir.CreateSubdirectory(nameOfDir);
            Console.WriteLine("The directory was created successfully at {0}", Directory.GetCreationTime(path));
        }
        static bool CheckFile(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            if (file.Exists)
            {
                return true;
            }
            return false;
        }
        public void CreateFile(string path,  string file)
        {
            string fullname = path+"\\"+file;
            Console.WriteLine(fullname);
            if (CheckFile(fullname))
            {
                file1 = new FileInfo(fullname);
                file1.Create();
            }
        }
        public void Input(string[] directories)
        {
            foreach (string dir in directories)
            {
                byte[] input = Encoding.Default.GetBytes(dir);
                fileStream.Write(input, 0, input.Length);
            }
        }
        public void entryInFile(string[] directories)
        {
            fileStream = file1.Create();
            Input(directories);
            fileStream.Close();
        }
        public void CopyFile(string fileName, string path)
        {
            if (CheckFile(fileName))
            {
                FileInfo file = new FileInfo(fileName);
                file.CopyTo(path, true);//аргумент, разрешающий перезапись уже существующего файла
                Console.WriteLine("File is successfully copied");
            }
        }
        static public void deleteFile(string path)
        {
            if (CheckFile(path))
            {
                FileInfo file = new FileInfo(path);
                file.Delete();
                Console.WriteLine("File is successfully deleted");
            }
        }
        FileInfo[] getFiles(DirectoryInfo dir, string expansion)
        {
            FileInfo[] info = dir.GetFiles(expansion, SearchOption.TopDirectoryOnly);
            return info;
        }
        void copyFiles(string expansion, string dir, string path)
        {
            DirectoryInfo direct = new DirectoryInfo(dir);
            FileInfo[] fileinfo = getFiles(direct, expansion);
            foreach (FileInfo file in fileinfo)
                file.CopyTo(path+"\\"+file.Name, true);
        }
        public void listOfDirectory()
        {
            CreateDirectory(path, nameOfDir);
            this.CreateFile(path+ "\\" + nameOfDir, nameOfFile);
            string[] directories = Directory.GetDirectories(nameOfDisk);
            file1 = new FileInfo(path + "\\" + nameOfDir+"\\" + nameOfFile);
            entryInFile(directories);
            nameOfFile = "test1.txt";
            CopyFile(path+ "\\" +nameOfDir +  "\\test.txt", path+ "\\" + nameOfDir+"\\" +nameOfFile);
            deleteFile(path+ "\\" + nameOfDir + "\\test.txt");
            CreateDirectory(path, "BAVInspect");
            copyFiles("*.txt", path + "\\" + nameOfDir, path + "\\BAVInspect");
            AddToZip(path + "\\BAVInspect", path +"\\file.zip");
        }
        void AddToZip(string name, string zip)
        {
            ZipFile.CreateFromDirectory(name, zip);
            ZipFile.ExtractToDirectory(zip, name+"\\BAV");
        }
    }
}
