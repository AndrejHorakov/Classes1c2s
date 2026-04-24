namespace Multithreading;

public class SemaphoreLibrary
{
    public static void Run()
    {
        // запускаем пять потоков
        for (int i = 1; i < 6; i++)
        {
            Reader reader = new Reader(i);
        }
        Thread.Sleep(3000);
        Reader.sem.Release(3);
    }
}
// Его конструктор принимает два параметра: первый указывает, какому числу объектов изначально будет доступен семафор,
// а второй параметр указывает, какой максимальное число объектов будет использовать данный семафор.
// В данном случае у нас только три читателя могут одновременно находиться в библиотеке,
// поэтому максимальное число равно 3.

class Reader
{
    // создаем семафор
    public static Semaphore sem = new Semaphore(0, 3);
    Thread myThread;
    int count = 3;// счетчик чтения
 
    public Reader(int i)
    {
        myThread = new Thread(Read);
        myThread.Name = $"Читатель {i}";
        myThread.Start();
    }
 
    public void Read()
    {
        while (count > 0)
        {
            sem.WaitOne();  // ожидаем, когда освободиться место
 
            Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");
 
            Console.WriteLine($"{Thread.CurrentThread.Name} читает");
            Thread.Sleep(1000);
 
            Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");
 
            sem.Release();  // освобождаем место
 
            count--;
            Thread.Sleep(1000);
        }
    }
}