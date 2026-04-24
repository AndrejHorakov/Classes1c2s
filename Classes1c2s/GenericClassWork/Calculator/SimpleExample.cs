namespace GenericClassWork.Calculator;

public interface IMathable<T> {
    T Add(T other);
}

public class MyInt : IMathable<MyInt> {
    public int Value { get; set; }
    public MyInt Add(MyInt other)
    {
        return new MyInt { Value = Value + other.Value };
    }
}

public class GenericCalculator<T> where T : IMathable<T> {
    public T Sum(T a, T b) => a.Add(b);
}





interface IMyComparable<T>
where T : class
{
    int Compare(T other);
}

public static class MyExample
{
    public static void Run()
    {
        Max([1,2,3,3,4]);
        Max([new Product(),new Product()]);
    }

    public static T Max<T>(T[] items)
    where T : IComparable<T>
    {
        var compareResult = items[0].CompareTo(items[1]);
        return items[0];
    }
}
public class Product : IAdvancedMath<Product>, IComparable<Product>
{
    public int Price { get; set; }
    // public int Compare(object other)
    // {
    //     var product = (Product)other;
    //     if (Price == product.Price)
    //         return 0;
    //     if (Price > product.Price)
    //         return 1;
    //     
    //     return -1;
    // }

    public int CompareTo(Product? other)
    {
        return Price > other.Price 
            ? 1 
            : Price == other.Price 
                ? 0
                :-1;
    }

    public static Product operator +(Product a, Product b)
    {
        return  new Product { Price = a.Price + b.Price };
    }
}









