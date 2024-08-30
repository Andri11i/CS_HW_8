using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_8
{
    public class Task4
    {
        public static void AccessResource(Semaphore semaphore)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is waiting to access the resource...");
            semaphore.WaitOne();

            Console.WriteLine($"{Thread.CurrentThread.Name} has entered the resource.");

            Thread.Sleep(2000);

            Console.WriteLine($"{Thread.CurrentThread.Name} is leaving the resource.");
            semaphore.Release();
        }
    }
}
