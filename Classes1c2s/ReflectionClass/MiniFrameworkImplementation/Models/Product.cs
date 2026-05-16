using ReflectionClass.MiniFrameworkImplementation.Attributes;

namespace ReflectionClass.Homework.Models;

public class Product
{
    [MyRequired]
    public string Title { get; set; }

    [MyRange(1, 10000)]
    public int Price { get; set; }
}