namespace Multithreading;

public class ClassLockMethodTryEnter
{
    //Метод TryEnter() также осуществляет вход в критическую секцию.
    //Этот метод возвращает булевое значение - true или false. Если метод возвращает true,
    //текущий поток является единственным потоком, который удерживает блокировку. Если метод возвращает false,
    //то поток не ждет освобождения блокировки. Например:
    public static void Run()
    {
        int x = 0;  // некоторый общий ресурс
        Lock _lockObj = new(); // объект-заглушка для синхронизации доступа
// запускаем пять потоков
        for (int i = 1; i < 6; i++)
        {
            Thread myThread = new(Print);
            myThread.Name = $"Поток {i}";
            myThread.Start();
        }
 
 
        void Print()
        {
            if (_lockObj.TryEnter())  // начало критической секции
            {
                try
                {
                    x = 1;
                    for (int i = 1; i < 6; i++)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                        x++;
                        //Thread.Sleep(100);
                    }
                }  
                finally { _lockObj.Exit(); } // завершение критической секции
            }
        }
    }
}