using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_8
{
    public class Task2
    {
        public static void ThreadProc(object obj)
        {
            int current = (int)obj;
            Console.WriteLine($"Thread number: {current}, Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
