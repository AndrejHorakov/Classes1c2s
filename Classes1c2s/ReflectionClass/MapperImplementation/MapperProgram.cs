using ReflectionClass.MapperImplementation.Models;

namespace ReflectionClass.MapperImplementation;

public class MapperProgram
{
    public static void Main()
    {
        var src = new Source { Name = "Ivan", Age = 25 };
        var dest = new Dest();

        Mapper.Map(src, dest);

        Console.WriteLine($"Name: {dest.Name}, Age: {dest.Age}");
        // Ожидаемый результат: Name: Ivan, Age: 25
    }
}