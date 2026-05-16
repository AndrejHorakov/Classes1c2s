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
        var assemblies = Assembly.GetExecutingAssembly().GetTypes();
        
        // TODO: Найти все классы, реализующие IHandler<T>
        foreach (var type in assemblies)
        {
            if (!type.IsClass)
                continue;
            // var typeInheritsHandler = type.GetInterface(nameof(ICommandHandler<>));
            // if (typeInheritsHandler == null)
            //     continue;
            //
            // // TODO: Сохранить в словарь: [Тип команды] -> [Тип обработчика]
            // var genericType = typeInheritsHandler.GetGenericTypeDefinition();
            // _handlers[genericType] = typeInheritsHandler;
            
            
            
            var handlerInterface = type.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && 
                                     i.GetGenericTypeDefinition() == typeof(ICommandHandler<>));
        
            if (handlerInterface == null)
                continue;
        
            // Извлекаем тип команды (T из ICommandHandler<T>)
            var commandType = handlerInterface.GetGenericArguments()[0];
        
            // TODO: Сохранить в словарь: [Тип команды] -> [Тип обработчика]
            _handlers[commandType] = type;
        }
        
    }

    public void Send<T>(T command) where T : ICommand
    {
        // TODO: Найти нужный обработчик в словаре
        _handlers.TryGetValue(typeof(T), out var handler);
        if(handler == null)
            return;
        
        // TODO: Создать экземпляр обработчика (new или через контейнер)
        var instance = Activator.CreateInstance(handler) as ICommandHandler<T>;
        // TODO: Вызвать метод Handle у обработчика через рефлексию
        instance.Handle(command);
    }
}