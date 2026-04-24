namespace Multithreading;

public class ClassLockMethodEnterScope
{
    // Еще один способ демонстрирует метод EnterScope(),
    // который является рекомендуемым способом (с точки зрения Microsoft).
    // Он также осуществляет вход в критическую секцию. Если один поток уже захватил блокировку и вошел в эту секцию,
    // другие потоки ждут освобождения блокировки.
    // Данный метод прежде всего предназначен для использования в конструкции using,
    // которая автоматически освобождает все связанные ресурсы
    
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
            using (_lockObj.EnterScope())  // начало критической секции
            {
                x = 1;
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    x++;
                    Thread.Sleep(100);
                }
            }  // завершение критической секции
        }
    }
}