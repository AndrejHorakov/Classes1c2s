using System.Reflection;
using ReflectionClass.MiniFrameworkImplementation.Attributes;

namespace ReflectionClass.MiniFrameworkImplementation.Validators;

public class MyRequiredValidator
{
    public bool Validate(object obj, out List<string> errors)
    {
        errors = new List<string>();
        // TODO: Получить все свойства объекта (obj.GetType().GetProperties())
        var properties = obj.GetType().GetProperties();
        
        // TODO: Проверить наличие атрибута [MyRequired] через GetCustomAttribute
        foreach (var property in properties)
        {
            if (property.GetCustomAttribute<MyRequiredAttribute>() is null)
                continue;
            if (property.GetValue(obj) is null)
            {
                errors.Add($"{property.Name} is required. Actual: null");
                continue;
            }

            if (property.GetValue(obj) is string valueString && string.IsNullOrEmpty(valueString))
                errors.Add($"{property.Name} is required. Actual: Empty!!!");
        }

        // TODO: Если атрибут есть, а значение свойства null или пустое — добавить ошибку
        return errors.Count == 0;
    }
}