namespace GCClass;

public class SubscriberFixed : IDisposable
{
    private readonly string _name;
    private readonly Publisher _publisher;

    public SubscriberFixed(string name, Publisher publisher)
    {
        _name = name;
        _publisher = publisher;
        _publisher.OnDataReceived += HandleData;
    }

    private void HandleData() => Console.WriteLine($"{_name} работает.");

    // Реализуем метод Dispose для явной отписки
    public void Dispose()
    {
        _publisher.OnDataReceived -= HandleData;
        Console.WriteLine($"{_name} успешно отписался от событий.");
    }

    ~SubscriberFixed()
    {
        Console.WriteLine($"[!] Финализатор: Subscriber {_name} ОЧИЩЕН.");
    }
}