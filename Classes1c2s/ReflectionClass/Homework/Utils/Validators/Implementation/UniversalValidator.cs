using ReflectionClass.Homework.Utils.Validators.Abstraction;

namespace ReflectionClass.Homework.Utils.Validators.Implementation;

public class UniversalValidator : IValidator
{
        /// <summary>
        /// Универсальный метод, который валидирует ВООБЩЕ любой объект на основе его атрибутов.
        /// </summary>
        public bool Validate(object? obj, out List<string> errors)
        {
            errors = new List<string>();
            // TODO: Проверить на null

            // TODO: ШАГ 1. Получить тип объекта 

            // TODO: ШАГ 2. Извлечь все свойства
            
            // TODO: ШАГ 3. Получать все значения свойств у ТЕКУЩЕГО экземпляра
            // TODO: ШАГ 3.1 Проверять, обвешано ли свойство атрибутом MyRequired
            // TODO: ШАГ 3.2 Проверять, есть ли атрибут MyRange
            
            return errors.Count == 0;
        }
}