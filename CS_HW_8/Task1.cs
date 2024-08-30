using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_8
{
    public class Task1
    {
        public static void PrintInfo()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}, Thread ID: {Thread.CurrentThread.ManagedThreadId}, Number {i + 1}");
                Thread.Sleep(500);
            }
        }
    }
}
