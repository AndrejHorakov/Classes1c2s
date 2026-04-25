namespace Multithreading.ExamplesToImplement;

class Theater
{
    static int totalVisited;
    private static Semaphore Semaphore { get; } = new Semaphore(5, 5);

   public static void Main()
   {
        var cnt = 4000;
        var tasks = new Task[cnt];
        for (int i = 0; i < cnt; i++)
        {
            int viewerId = i;
            
            tasks[i] = Task.Run(() => EnterBath(viewerId));
        }
        
        Task.WhenAll(tasks);
        Console.WriteLine(totalVisited);
    }

    static void EnterBath(int id)
    {
        // Рандомно хотят в туалет в течение 20 секунд спектакля
        Thread.Sleep(new Random().Next(1, 20000));
        
        Semaphore.WaitOne();
        Console.WriteLine($"Зритель {id} ждет очереди...");
        
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"--- Зритель {id} зашел в кабинку.");
        Console.ResetColor();

        //Thread.Sleep(400); // Проводит там 1 секунду
        
        totalVisited++;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"xxx Зритель {id} вышел. Всего прошло: {totalVisited}");
        Semaphore.Release();
        Console.ResetColor();
    }
}