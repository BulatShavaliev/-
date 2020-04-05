using System;
using System.Threading;
using Timers = System.Timers;

class Test
{
    static void Main()
    {
        PriorityTest priorityTest = new PriorityTest();//create new переменную класса PriorityTest

        Thread thread1 = new Thread(priorityTest.ThreadMethod);//create new поток класса Thread 
        thread1.Name = "Thread1";
        Thread thread2 = new Thread(priorityTest.ThreadMethod);//create new поток класса Thread
        thread2.Name = "Thread2";
        thread2.Priority = ThreadPriority.Lowest;//выдача приоритета
        Thread thread3 = new Thread(priorityTest.ThreadMethod);//create new поток класса Thread
        thread3.Name = "Thread3";
        thread3.Priority = ThreadPriority.Highest;//выдача приоритета

        thread1.Start();
        thread2.Start();
        thread3.Start();
        // Allow counting for 10 seconds.
        Thread.Sleep(100); //время работы потоков
        priorityTest.LoopSwitch = false;
        Console.ReadKey();
    }
}

class PriorityTest //класc
{
    static bool loopSwitch;
    [ThreadStatic] static long threadCount = 0;

    public PriorityTest() //metod
    {
        loopSwitch = true;
    }

    public bool LoopSwitch
    {
        set { loopSwitch = value; }
    }

    public void ThreadMethod()
    {
        while (loopSwitch)
        {
            threadCount++;
        }
        Console.WriteLine("{0,-11} with {1,11} priority " + "has a count = {2,13}", Thread.CurrentThread.Name, Thread.CurrentThread.Priority.ToString(), threadCount.ToString("N0"));
    }
}
// The example displays output like the following:
//    ThreadOne   with     Normal priority has a count =   755,897,581
//    ThreadThree with вышеNormal priority has a count =   778,099,094
//    ThreadTwo   with нижеNormal priority has a count =     7,840,984