using System.Reflection;
using ReflectionClass.MediatorImplementation.Abstraction;

namespace ReflectionClass.MediatorImplementation;

public class Mediator
{
    // Здесь мы храним соответствие типа команды и её обработчика
    private Dictionary<Type, Type> _handlers = new();

    public void ScanAssembly()
    {
        // TODO: Получить все типы из текущей сборки Assembly.GetExecutingAssembly()
        // TODO: Найти все классы, реализующие IHandler<T>
        // TODO: Сохранить в словарь: [Тип команды] -> [Тип обработчика]
    }

    public void Send<T>(T command) where T : ICommand
    {
        // TODO: Найти нужный обработчик в словаре
        // TODO: Создать экземпляр обработчика (new или через контейнер)
        // TODO: Вызвать метод Handle у обработчика через рефлексию
    }
}