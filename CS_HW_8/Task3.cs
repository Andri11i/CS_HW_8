using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_8
{
    public class Task3
    {
        public class LockerTest
        {
            private int counter = 0;
            static readonly object sigma = new object();

            public void Countm()
            {
                for (int i = 0; i < 1000; i++)
                {
                    lock (sigma)
                    {
                        counter++;
                    }
                }
            }

            public void PrintCounter()
            {
                Console.WriteLine($"Counter: {counter}");
            }
        }
    }
}
