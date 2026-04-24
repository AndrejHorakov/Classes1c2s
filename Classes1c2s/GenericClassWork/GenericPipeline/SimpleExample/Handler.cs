namespace GenericClassWork.GenericPipeline.SimpleExample;

// Абстрактный обработчик для любого типа данных T
public abstract class Handler<T>
{
    private Handler<T>? _nextHandler;

    // Метод для построения цепи
    public Handler<T> SetNext(Handler<T> handler)
    {
        _nextHandler = handler;
        return handler; // Возвращаем для цепочки
    }

    public virtual void Handle(T request)
    {
        // Если есть следующий обработчик — передаем ему
        _nextHandler?.Handle(request);
    }
}