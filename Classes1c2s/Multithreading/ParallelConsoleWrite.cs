namespace Multithreading;

public class ParallelConsoleWrite
{
    public static void Run()
    {
        // создаем новый поток
        Thread myThread = new Thread(Print);
        // запускаем поток myThread
        myThread.Start();

        // действия, выполняемые в главном потоке
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Главный поток: id:{Thread.CurrentThread.ManagedThreadId} {i}");
            Thread.Sleep(300);
        }
    }

    // действия, выполняемые во втором потокке
    static void Print()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Второй поток: id:{Thread.CurrentThread.ManagedThreadId} {i}");
            Thread.Sleep(400);
        }
    }
}