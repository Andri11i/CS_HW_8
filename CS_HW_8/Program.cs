using System.Diagnostics.Metrics;
using System.Reflection;
using System.Threading;



// 1


Thread thread1 = new Thread(PrintInfo);
Thread thread2 = new Thread(PrintInfo);

thread1.Name = "Thread 1";
thread2.Name = "Thread 2";

thread1.Start();
thread2.Start();

Thread.Sleep(5000);
// 2


for (int i = 0; i < 10; i++)
{
    ThreadPool.QueueUserWorkItem(ThreadProc, i);
}

// 3


LockerTest Countfunc = new LockerTest();

Thread thread3 = new Thread(Countfunc.Countm);
Thread thread4 = new Thread(Countfunc.Countm);

thread3.Start();
thread4.Start();

thread3.Join();
thread4.Join();


Countfunc.printcounter();

// 4


Semaphore semaphore = new Semaphore(2, 2);

for (int i = 0; i < 5; i++)
{
    Thread thread = new Thread(AccessResource);
    thread.Name = $"Thread {i + 1}";
    thread.Start();
}

// methods and classes
static void ThreadProc(object obj)
{
    int current = (int)obj;
    Console.WriteLine($"Thread number: {current}, Thread ID: {Thread.CurrentThread.ManagedThreadId}");
}
static void PrintInfo()
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}, Thread ID: {Thread.CurrentThread.ManagedThreadId}, Number {i + 1}");
        Thread.Sleep(500);
    }
}


void AccessResource()
{
    Console.WriteLine($"{Thread.CurrentThread.Name} is waiting to access the resource...");
    semaphore.WaitOne(); 

    Console.WriteLine($"{Thread.CurrentThread.Name} has entered the resource.");

    Thread.Sleep(2000); 

    Console.WriteLine($"{Thread.CurrentThread.Name} is leaving the resource.");
    semaphore.Release();
}

class LockerTest
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
    public void printcounter()
    {
        Console.WriteLine($"Counter: {counter}");
    }
}
