namespace ReflectionClass.DependencyInjection;

public class MyContainer
{
    private Dictionary<Type, Type> _registrations = new();

    public void Register<TInterface, TImplementation>() where TImplementation : TInterface
    {
        _registrations.Add(typeof(TInterface), typeof(TImplementation));
    }

    public T? Resolve<T>() where T : class
    {
        return Resolve(typeof(T)) as T;
    }

    private object? Resolve(Type type)
    {
        if (!_registrations.TryGetValue(type, out Type registration))
            return null;
        
        // TODO: Найти конструктор
        // TODO: Получить параметры конструктора 
        // TODO: Рекурсивно вызвать Resolve для каждого параметра
        // TODO: Создать объект
        var constructor = registration.GetConstructors().First();
        var parameters = constructor.GetParameters().ToList();
        List<object> constructorParameters = [];
        foreach (var parameter in parameters)
        {
            var parameterType = parameter.ParameterType;
            constructorParameters.Add(Resolve(parameterType));
        }
        
        return constructor.Invoke(constructorParameters.ToArray());
    }
}