namespace Multithreading.ExamplesToImplement;

public class SingletonDoubleLocking
{
    private static SingletonDoubleLocking? _instance;
    private static object _locker = new();
    public static SingletonDoubleLocking UnsafeGetInstance()
    {
        if (_instance == null) 
        {
            // ПАУЗА: Поток А проверил, что null, и тут ОС переключила контекст на Поток Б.
            // Поток Б тоже проверил, что null. 
            // В итоге оба создадут по объекту. Синглтон мертв.
            _instance = new SingletonDoubleLocking(); 
        }
        
        return _instance;
    }
    public static SingletonDoubleLocking SafeGetInstance()
    {
        lock (_locker) // Каждый раз, когда нам нужен объект, мы встаем в очередь
        {
            if (_instance == null) 
                _instance = new SingletonDoubleLocking();
        }
        // Это безопасно, но УЖАСНО МЕДЛЕННО. 
        // Зачем нам ждать lock, если объект уже создан?
        return _instance;
    }
    
    public static SingletonDoubleLocking FastAndSafeGetInstance()
    {
        // ПРОВЕРКА 1: Если объект уже есть — сразу возвращаем его. 
        // Почти все вызовы закончатся здесь, без блокировок и тормозов.
        if (_instance == null) 
        {
            lock (_locker) // Если же объекта нет — заходим в очередь
            {
                // ПРОВЕРКА 2: Пока мы ждали своей очереди в lock, 
                // другой поток мог УЖЕ создать объект. 
                // Проверяем еще раз, чтобы не перезаписать.
                if (_instance == null) 
                {
                    _instance = new SingletonDoubleLocking();
                }
            }
        }
        return _instance;
    }
    
    
    
    
    
    
    
    // Всё уже придумано за нас
    private static readonly Lazy<SingletonDoubleLocking> _lazy = 
        new Lazy<SingletonDoubleLocking>(() => new SingletonDoubleLocking(), isThreadSafe: true);

    public static SingletonDoubleLocking Instance => _lazy.Value;
}