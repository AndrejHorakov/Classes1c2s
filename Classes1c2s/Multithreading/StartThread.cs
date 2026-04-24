namespace Multithreading;

public class StartThread
{
    //Для создания потока применяется один из конструкторов класса Thread:

    //Thread(ThreadStart): в качестве параметра принимает объект делегата ThreadStart,
    //который представляет выполняемое в потоке действие

    //Thread(ThreadStart, Int32): в дополнение к делегату ThreadStart принимает числовое значение,
    //которое устанавливает размер стека, выделяемого под данный поток

    //Thread(ParameterizedThreadStart): в качестве параметра принимает объект делегата ParameterizedThreadStart,
    //который представляет выполняемое в потоке действие

    //Thread(ParameterizedThreadStart, Int32): вместе с делегатом ParameterizedThreadStart принимает числовое значение,
    //которое устанавливает размер стека для данного потока
    public static void Start()
    {
        Thread myThread1 = new Thread(Print); 
        Thread myThread2 = new Thread(new ThreadStart(Print));
        Thread myThread3 = new Thread(() => Console.WriteLine("Hello Threads"));
        
        //Для запуска нового потока применяется метод Start класса Thread:
        
        myThread1.Start();  // запускаем поток myThread1
        myThread2.Start();  // запускаем поток myThread2
        myThread3.Start();  // запускаем поток myThread3
    }
    
    static void Print() => Console.WriteLine("Hello Threads");
}