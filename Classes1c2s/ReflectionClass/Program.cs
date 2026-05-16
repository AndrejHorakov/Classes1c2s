using System.Diagnostics;
using ReflectionClass.DependencyInjection;
using ReflectionClass.Homework.Services;
using ReflectionClass.Homework.Utils.MyMapper;
using ReflectionClass.Homework.Utils.Validators.Abstraction;
using ReflectionClass.Homework.Utils.Validators.Implementation;
using ReflectionClass.MiniFrameworkImplementation.Models;

// Настройка DI-контейнера
var container = new MyContainer();
container.Register<IValidator, UniversalValidator>();
// TODO: Раскомментировать, когда будет готова имплементация
//container.Register<IMapper, >();
// Регистрируем сам процессор (его зависимости контейнер разрешит сам!)
container.Register<BulkProcessor, BulkProcessor>();

// Получаем готовый процессор из контейнера
var processor = container.Resolve<BulkProcessor>();

// Генерируем тестовые данные
var rawData = new List<object>();
var rnd = new Random();
var errorsCountExpected = 0;
var clearDtosExpected = 0;
for (int i = 0; i < 100000; i++)
{
    var random = rnd.Next(1, 2);
    if (random == 1)
        errorsCountExpected++;
    var name = random == 1
        ? string.Empty
        : $"Name_{i}";
    
    var age = random == 1
        ? 30
        : rnd.Next(1, 100);
    if (age is < 18 or > 65)
        errorsCountExpected++;
    else
        clearDtosExpected++;
    
    rawData.Add(new User
    {
        Name = name, 
        Age = age
    });
}

// Запуск
var sw = Stopwatch.StartNew();
var clearDtos = processor.ProcessParallel(rawData, out var errors);
sw.Stop();

Console.WriteLine($"=== ИТОГИ РАБОТЫ ФРЕЙМВОРКА ===");
Console.WriteLine($"Время сборки, валидации и маппинга 100k элементов: {sw.ElapsedMilliseconds} мс");
Console.WriteLine($"Успешно смапплено в DTO: {clearDtos.Count} шт.");
Console.WriteLine($"Найдено ошибок валидации: {errors.Count} шт.");
            
// Проверка математики: 100 000 элементов. Каждый 10-й битый (10 000 ошибок). 
// Успешных должно быть ровно 90 000.
Console.WriteLine($"Фреймворк отработал корректно? {clearDtos.Count == clearDtosExpected && errors.Count == errorsCountExpected}");