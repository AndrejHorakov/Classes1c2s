namespace Multithreading.Tasks;

public class UsingTaskProperties
{
    public static void Run()
    {
        Task task1 = new Task(() =>
        {
            Console.WriteLine($"Task{Task.CurrentId} Starts");
            Thread.Sleep(1000);
            Console.WriteLine($"Task{Task.CurrentId} Ends");
        });
        task1.Start(); //запускаем задачу
 
        // получаем информацию о задаче
        Console.WriteLine($"task1 Id: {task1.Id}");
        Console.WriteLine($"task1 is Completed: {task1.IsCompleted}");
        Console.WriteLine($"task1 Status: {task1.Status}");
 
        task1.Wait(); // ожидаем завершения задачи
    }
}