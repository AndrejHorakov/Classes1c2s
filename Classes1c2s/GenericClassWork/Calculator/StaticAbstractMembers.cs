namespace GenericClassWork.Calculator;

public interface IAdvancedMath<T> where T : IAdvancedMath<T>
{
    static abstract T operator +(T a, T b);
}

public struct SimpleInt : IAdvancedMath<SimpleInt>
{
    public int Value;

    public SimpleInt(int value)
    {
        Value = value;
    }

    public static SimpleInt operator +(SimpleInt a, SimpleInt b)
    {
        return new SimpleInt { Value = a.Value + b.Value };
    }
    
    public static SimpleInt operator +(SimpleInt a, Product b)
    {
        return new SimpleInt { Value = a.Value + b.Price };
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public static class SAMExample
{
    public static void Run()
    {
        var a = new SimpleInt(1);
        var b = new SimpleInt(3);
        var product = new Product()
        {
            Price = 2,
        };
        var c = a + b;
        var d = a + product;
        Console.WriteLine(c);
        Console.WriteLine(d);
    }
}