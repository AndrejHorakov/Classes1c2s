namespace GCClass;

public class Publisher
{
    // Событие, на которое будут подписываться другие объекты
    public event Action OnDataReceived;

    public void RaiseEvent() => OnDataReceived?.Invoke();
}

public class Subscriber
{
    private readonly string _name;

    public Subscriber(string name, Publisher publisher)
    {
        _name = name;
        // Подписка создает сильную ссылку от Publisher к Subscriber!
        publisher.OnDataReceived += HandleData;
    }

    private void HandleData() => Console.WriteLine($"{_name} получил данные.");

    // Финализатор — сработает только тогда, когда GC решит удалить объект
    ~Subscriber()
    {
        Console.WriteLine($"[!] Финализатор: Subscriber {_name} удален из памяти.");
    }
}