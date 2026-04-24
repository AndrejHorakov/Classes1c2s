namespace Multithreading;

public class ClassLockMethods
{
    //С помощью вызова метода Enter() у объекта Lock можно обозначить начало критической секции,
    //в которую опять же может войти только один поток. Остальные потоки опять же ожидают выхода этого потока
    //из критической секции. Для выхода из этой секции (ее завершения) у объекта Lock вызывается метод Exit():
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
            _lockObj.Enter();  // начало критической секции
            try
            {
                x = 1;
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    x++;
                    Thread.Sleep(100);
                }
            }  
            finally { _lockObj.Exit(); } // завершение критической секции
        }
    }
}