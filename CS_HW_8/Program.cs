using CS_HW_8;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Threading;

//1

Thread thread1 = new Thread(Task1.PrintInfo);
Thread thread2 = new Thread(Task1.PrintInfo);

thread1.Name = "Thread 1";
thread2.Name = "Thread 2";

thread1.Start();
thread2.Start();

Thread.Sleep(5000);

// 2
for (int i = 0; i < 10; i++)
{
    ThreadPool.QueueUserWorkItem(Task2.ThreadProc, i);
}

//  3
Task3.LockerTest countFunc = new Task3.LockerTest();

Thread thread3 = new Thread(countFunc.Countm);
Thread thread4 = new Thread(countFunc.Countm);

thread3.Start();
thread4.Start();

thread3.Join();
thread4.Join();

countFunc.PrintCounter();

// 4
Semaphore semaphore = new Semaphore(2, 2);

for (int i = 0; i < 5; i++)
{
    Thread thread = new Thread(() => Task4.AccessResource(semaphore));
    thread.Name = $"Thread {i + 1}";
    thread.Start();
}
