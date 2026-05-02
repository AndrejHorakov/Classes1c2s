
using ReflectionClass.MiniFrameworkImplementation.Models;
using ReflectionClass.MiniFrameworkImplementation.Validators;

namespace ReflectionClass.MiniFrameworkImplementation;

public class MiniFrameworkProgram
{
    public static void Run()
    {
        var validator = new MyRequiredValidator();
        var user = new User { Name = "" }; // Имя пустое - ошибка!

        if (!validator.Validate(user, out var errors))
        {
            Console.WriteLine("Найдено ошибок: " + errors.Count);
            errors.ForEach(e => Console.WriteLine(e));
        }
        else
        {
            Console.WriteLine("Валидация пройдена!");
        }
    }
}