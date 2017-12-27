using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;


namespace OOP15 {
    public class Program {
        static void Main(string[] args) {
            MultiThreading.GetProcesses();
            Console.WriteLine("\n\\\\\\\\\\\\\\\\\\\\\\\\\n");
            MultiThreading.CreateNewDomain();
            Console.WriteLine("\n\\\\\\\\\\\\\\\\\\\\\\\\\n");
            Console.WriteLine("Введите конечное число: ");
            int endNum = int.Parse(Console.ReadLine());
            Thread thread = new Thread(new ParameterizedThreadStart(MultiThreading.WritePrimeNumbers)) {
                Name = "WritePrimeThread",
                Priority = ThreadPriority.AboveNormal
            };
            Console.WriteLine(thread.ThreadState);
            Thread.Sleep(1000);
            thread.Start(endNum);
            Console.WriteLine(thread.ThreadState);
            Thread.Sleep(5000);
            thread.Suspend();
            Console.WriteLine(thread.ThreadState);
            Thread.Sleep(1000);
            Console.WriteLine(thread.ThreadState);
            Thread.Sleep(3000);
            thread.Resume();
            Console.WriteLine("Имя: {0}   Приоритет: {1}   Числовой идентификатор: {2}   Состояние: {3}", thread.Name, thread.Priority, thread.ManagedThreadId, thread.ThreadState);
            Thread.Sleep(5000);
            Console.WriteLine(thread.ThreadState);
            thread.Abort();
            Console.WriteLine(thread.ThreadState);

            ////////////////////////////////

            endNum = int.Parse(Console.ReadLine());
            Thread thread1 = new Thread(new ParameterizedThreadStart(MultiThreading.WriteOddNumbers));
            Thread thread2 = new Thread(new ParameterizedThreadStart(MultiThreading.WriteEvenNumbers)) {
                Priority = ThreadPriority.Highest
            };
            thread1.Start(endNum);
            thread2.Start(endNum);

            if (!thread1.IsAlive) {
                thread1.Abort();
            }
            if (!thread2.IsAlive) {
                thread2.Abort();
            }
            Console.ReadLine();
            MultiThreading.writer.Close();

            //////////////////////////////////

            TimerCallback timerCB = new TimerCallback(MultiThreading.PrintTime);

            Timer timer = new Timer(timerCB, null, 0, 1000);
            Console.ReadLine();
        }
    }
}