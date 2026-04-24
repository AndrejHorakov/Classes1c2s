namespace Multithreading;

public class ParameterizedThreadStartExample
{
    //public delegate void ParameterizedThreadStart(object? obj);
    public static void Run()
    {
        // создаем новые потоки
        Thread myThread1 = new Thread(new ParameterizedThreadStart(Print));
        Thread myThread2 = new Thread(Print);
        Thread myThread3 = new Thread(message => Console.WriteLine($"{message}, {Thread.CurrentThread.ManagedThreadId}"));
 
        // запускаем потоки
        myThread1.Start("Hello");
        myThread2.Start("Привет");
        myThread3.Start("Salut");
    }
    
    static void Print(object? message) => 
        Console.WriteLine($"{message}, {Thread.CurrentThread.ManagedThreadId}");
    
    // void Print(object? obj)
    // {
    //     // здесь мы ожидаем получить число
    //     if (obj is int n)
    //     {
    //         Console.WriteLine($"n * n = {n * n}");
    //     }
    // }
}