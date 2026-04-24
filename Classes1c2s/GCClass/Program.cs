namespace GCClass;

static class Program
{
    static void Main()
    {
        Console.WriteLine("--- Старт программы ---");
        Publisher boss = new Publisher();

        // Создаем область видимости, чтобы локальная ссылка на 'sub' исчезла
        CreateAndForgetSubscriber(boss);

        // Пытаемся заставить GC поработать
        Console.WriteLine("Вызываем GC.Collect()...");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("GC завершил работу. Проверяем вывод...");
        // Финализатор НЕ СРАБОТАЕТ, так как 'boss' всё еще держит 'sub' через событие.
        
        // Вызываем метод, использующий подписчика, реализовывающего IDisposable
        SecureWork(boss);
        
        // Заставить GC поработать
        Console.WriteLine("Вызываем GC.Collect()...");
        GC.Collect();
        Console.WriteLine("GC завершил работу. Проверяем вывод...");
        Console.ReadKey();
        Console.WriteLine("--- Конец Main ---");
    }

    static void CreateAndForgetSubscriber(Publisher pub)
    {
        var sub = new Subscriber("Призрак", pub);
        Console.WriteLine("Subscriber создан и подписан на события.");
    }
    
    static void SecureWork(Publisher boss)
    {
        using (var sub = new SubscriberFixed("Исправленный", boss))
        {
            // sub работает...
        } // Здесь автоматически вызывается Dispose(), и подписка разрывается
    }
}