using ReflectionClass.MiniFrameworkImplementation.Attributes;

namespace ReflectionClass.MiniFrameworkImplementation.Models;

public class User
{
    [MyRequired]
    public string Name { get; set; }
    public int Age { get; set; }
}