using ReflectionClass.MiniFrameworkImplementation.Attributes;

namespace ReflectionClass.MiniFrameworkImplementation.Models;

public class User
{
    [MyRequired]
    public string Name { get; set; }
    [MyRange(18, 65)]
    public int Age { get; set; }
}