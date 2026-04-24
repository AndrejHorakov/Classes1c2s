namespace Multithreading.Tasks;

public class CreateTaskExample
{
    public static void Run()
    {
        //Первый способ создание объекта Task и вызов у него метода Start:
        Task task = new Task(() => Console.WriteLine("Hello Task!"));
        task.Start();
        
        //Второй способ заключается в использовании статического метода Task.Factory.StartNew().
        //Этот метод также в качестве параметра принимает делегат Action, который указывает,
        //какое действие будет выполняться. При этом этот метод сразу же запускает задачу:
        	
        Task task1 = Task.Factory.StartNew(() => Console.WriteLine("Hello Task!"));
        // В качестве результата метод возвращает запущенную задачу.
        
        //Третий способ определения и запуска задач представляет использование статического метода Task.Run():
        Task task2 = Task.Run(() => Console.WriteLine("Hello Task!"));
        
        //Метод Task.Run() также в качестве параметра может принимать делегат Action - выполняемое действие
        //и возвращает объект Task.
        
        //Итак, в данном коде задачи создаются и запускаются, но при выполнении приложения на консоли мы можем
        //не увидеть ничего. Почему? Потому что когда поток задачи запускается из основного потока программы -
        //потока метода Main, приложение может завершить выполнение до того, как все три или даже хотя бы одна из трех
        //задач начнет выполнение. Чтобы этого не произошло, мы можем программным образом ожидать завершения задачи.
    }

    public static void Run2()
    {
        var thread = new Thread(() =>
        {
            //Чтобы приложение ожидало завершения задачи, можно использовать метод Wait() объекта Task:
            Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
            task1.Start();
     
            Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));
     
            Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));
            task1.Wait();   // ожидаем завершения задачи task1
            task2.Wait();   // ожидаем завершения задачи task2
            task3.Wait();   // ожидаем завершения задачи task3
        });
 
        thread.Start();
    }

    public static void Run3()
    {
        //Стоит отметить, что метод Wait() блокирует вызывающий поток, в котором запущена задача,
        //пока эта задача не завершит свое выполнение. Например:
        Console.WriteLine("Main Starts");
        // создаем задачу
        Task task1 = new Task(() =>
        {
            Console.WriteLine("Task Starts");
            Thread.Sleep(1000);     // задержка на 1 секунду - имитация долгой работы
            Console.WriteLine("Task Ends");
        });
        task1.Start();  // запускаем задачу
        task1.Wait();   // ожидаем выполнения задачи
        Console.WriteLine("Main Ends");
    }
}