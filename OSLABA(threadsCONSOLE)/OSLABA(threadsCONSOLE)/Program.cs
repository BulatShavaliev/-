using System;
using System.Threading;
using Timers = System.Timers;
class Test
{
    public static int battery = 100;

    public static void Main()
    {
        Thread thread1 = new Thread(DischargingBattery);//create new поток класса Thread 
        thread1.Name = "Thread1";
        Thread thread2 = new Thread(DischargingBattery);//create new поток класса Thread
        thread2.Name = "Thread2";
        thread2.Priority = ThreadPriority.Lowest;//выдача приоритета
        Thread thread3 = new Thread(DischargingBattery);//create new поток класса Thread
        thread3.Name = "Thread3";
        thread3.Priority = ThreadPriority.Highest;//выдача приоритета
        thread1.Start();
        thread2.Start();
        thread3.Start();
        Console.ReadKey();
    }
    public static void DischargingBattery()
    {
        //int battery = 100;
        while (battery != 0)
        {
            battery--;
            battery--;
            Console.WriteLine("{0,-11} with {1,11} priority " + "has a count = {2,13}", Thread.CurrentThread.Name, Thread.CurrentThread.Priority.ToString(), battery.ToString(""));
        }
        Console.ReadLine();
    }
}