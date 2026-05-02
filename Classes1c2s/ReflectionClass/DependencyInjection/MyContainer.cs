namespace ReflectionClass.DependencyInjection;

public class MyContainer
{
    private Dictionary<Type, Type> _registrations = new();

    public void Register<TInterface, TImplementation>() { /* TODO */ }

    public T Resolve<T>()
    {
        return (T)Resolve(typeof(T));
    }

    private object Resolve(Type type)
    {
        // TODO: Найти конструктор (type.GetConstructors().First())
        // TODO: Получить параметры конструктора (GetParameters())
        // TODO: Рекурсивно вызвать Resolve для каждого параметра
        // TODO: Создать объект через Activator.CreateInstance(type, параметры)
        return null;
    }
}