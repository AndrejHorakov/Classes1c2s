using System.Diagnostics;

namespace Multithreading.ExamplesToImplement;

public class AsyncDemo
{

    public static void Main()
    {
        //Run();
        MultipleTasks();
        Console.ReadKey();
    }
    public static async Task Run()
    {
        Console.WriteLine($"Main запущен в потоке: {Thread.CurrentThread.ManagedThreadId}");
        
        Stopwatch sw = Stopwatch.StartNew();

        // 1. СИНХРОННОЕ ОЖИДАНИЕ (Плохо)
        Console.WriteLine("\n--- Синхронный метод (блокируем поток) ---");
        WaitSynchronously(); 
        
        // 2. АСИНХРОННОЕ ОЖИДАНИЕ (Хорошо)
        Console.WriteLine("\n--- Асинхронный метод (освобождаем поток) ---");
        await WaitAsynchronously();

        sw.Stop();
        Console.WriteLine($"\nОбщее время: {sw.ElapsedMilliseconds} мс");
    }

    static void WaitSynchronously()
    {
        // Поток "засыпает", он не может делать другую работу. 
        // Если это UI, кнопка "зависнет".
        Thread.Sleep(2000); 
        Console.WriteLine("Синхронная работа завершена.");
    }

    static async Task WaitAsynchronously()
    {
        // await говорит: "Я буду ждать здесь. Поток, иди пока займись другими задачами из пула".
        // Когда 2 секунды пройдут, какой-нибудь свободный поток вернется сюда.
        await Task.Delay(2000); 
        
        Console.WriteLine($"Асинхронная работа завершена в потоке: {Thread.CurrentThread.ManagedThreadId}");
    }
    
    static async Task MultipleTasks()
    {
        Console.WriteLine($"Загружаем 3 сайта одновременно... Поток {Thread.CurrentThread.ManagedThreadId}");
      
        Stopwatch sw = Stopwatch.StartNew();
        // Запускаем задачи, но НЕ ждем их сразу
        Task t1 = Task.Delay(1000); // Сайт 1
        Task t2 = Task.Delay(1000); // Сайт 2
        Task t3 = Task.Delay(1000); // Сайт 3
        
        // Теперь ждем, когда ВСЕ они завершатся
        await Task.WhenAll(t1, t2, t3);
        sw.Stop();
        Console.WriteLine($"Все сайты загружены за {sw.ElapsedMilliseconds/1000} секунд(у)! Поток {Thread.CurrentThread.ManagedThreadId}");
    }
}