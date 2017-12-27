using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace OOP15 {
    public static class MultiThreading {
        public static StreamWriter writer = new StreamWriter("C:\\Users\\User-PC\\Desktop\\00P15.txt");
        //static SemaphoreSlim sema = new SemaphoreSlim(0);
        public static void GetProcesses() {
            Process[] allProcesses = Process.GetProcesses();
            foreach (Process i in allProcesses) {
                if (i.ProcessName != "Idle") {
                    Console.WriteLine("ID: {0}\tИмя: {1}\tПриоритет: {2}\tВремя запуска: {3}\tВремя работы: {4}", i.Id, i.ProcessName, i.BasePriority, i.StartTime, (int)((DateTime.Now - i.StartTime).TotalSeconds));
                }
            }
        }

        public static void CreateNewDomain() {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("Имя: {0} ", domain.FriendlyName);
            Console.WriteLine("Детали конфигурации: ");
            Console.WriteLine("\tИмя приложения: {0}\n\tВерсия фреймворка: {1}\n\tФайл конфигурации: {2}", domain.SetupInformation.ApplicationName, domain.SetupInformation.TargetFrameworkName, domain.SetupInformation.ConfigurationFile);
            Console.WriteLine("Сборки: ");
            foreach (var i in domain.GetAssemblies()) {
                Console.WriteLine("\t{0}", i.ToString());
            }
            AppDomain newDomain = AppDomain.CreateDomain("New");
            Assembly assembly = Assembly.LoadFrom("OOP15.exe");
            newDomain.Load(assembly.FullName);
            AppDomain.Unload(newDomain);
        }

        public static void WritePrimeNumbers(object endNum) {
            bool IsPrime(int x) {
                for (int i = 2; i <= x / i; i++)
                    if ((x % i) == 0) return false;
                return true;
            }

            for (int i = 1; i < (int)endNum; i++) {
                if (IsPrime(i)) {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
            }
        }

        public static bool IsOdd(object o) {
            int x = (int)o;
            return (x % 2 == 1) ? true : false;

        }
        public static void WriteOddNumbers(object o) {
            int endNum = (int)o;
            //sema.Wait();
            for (int i = 1; i <= endNum; i++) {
                Thread.Sleep(500);
                if (IsOdd(i)) {
                    Console.WriteLine(i);
                    writer.WriteLine(i);

                }
            }

        }
        public static void WriteEvenNumbers(object o) {
            int endNum = (int)o;
            for (int i = 1; i <= endNum; i++) {
                Thread.Sleep(1000);
                if (!IsOdd(i)) {
                    Console.WriteLine(i);
                    writer.WriteLine(i);
                }
            }
            //sema.Release();
        }
        public static void PrintTime(object state) {
            Console.Clear();
            Console.WriteLine("Текущее время:  " +
                DateTime.Now.ToLongTimeString());
        }
    }
}