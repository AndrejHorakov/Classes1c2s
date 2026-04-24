namespace ObjectOrientedProgramming.Examples;

public interface IMessageService
{
    void Send(string message);
}

public class TelegramService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine($"TG: {message}");
    }
}

public class SmsService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS: {message}");
    }
}

public class EmailService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine($"EMAIL: {message}");
    }
}

public class ZooAlert
{
    private readonly List<IMessageService> _services;
    
    // Мы передаем список интерфейсов
    public ZooAlert(List<IMessageService> services)
    {
        _services = services;
    }

    public void NotifyStaff(string alert)
    {
        foreach (var service in _services)
        {
            service.Send(alert); // Полиморфизм в действии
        }
    }
}

// // Собираем список всех нужных нам каналов связи
// var channels = new List<IMessageService> {
//     new TelegramService(),
//     new SmsService()
// };
//
// // Передаем их в систему уведомлений
// var alertSystem = new ZooAlert(channels);
//
// // Один вызов — и все оповещены!
// alertSystem.NotifyStaff("Внимание! Обезьяна украла ключи от склада бананов!");