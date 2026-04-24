namespace Multithreading.Tasks;

public class SyncTasks
{
    public static void Run()
    {
        //По умолчанию задачи запускаются асинхронно. Однако с помощью метода RunSynchronously()
        //можно запускать синхронно:
        Console.WriteLine("Main Starts");
        // создаем задачу
        Task task1 = new Task(() =>
        {
            Console.WriteLine("Task Starts");
            Thread.Sleep(1000); 
            Console.WriteLine("Task Ends");
        });
        task1.RunSynchronously(); // запускаем задачу синхронно
        Console.WriteLine("Main Ends"); // этот вызов ждет завершения задачи task1 
    }
}