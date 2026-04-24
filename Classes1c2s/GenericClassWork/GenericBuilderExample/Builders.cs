namespace GenericClassWork.GenericBuilderExample;

// TBuilder — это "я сам", TObject — то, что мы строим
public abstract class GenericBuilder<TObject, TBuilder>
    where TObject : DeliveryBox, new()
    where TBuilder : GenericBuilder<TObject, TBuilder>
{
    protected TObject _item = new TObject();

    public TBuilder WithLabel(string label)
    {
        _item.Label = label;
        return (TBuilder)this; // Вот тут магия дженерика!
    }

    public TObject Build()
    {
        return _item;
    }
}

// Теперь создаем конкретный строитель для Пиццы
public class PizzaBuilder : GenericBuilder<PizzaBox, PizzaBuilder>
{
    public PizzaBuilder WithSlices(int count)
    {
        _item.Slices = count;
        return this;
    }
}
public class CoffeeBuilder : GenericBuilder<CoffeeBox, CoffeeBuilder>
{
    public CoffeeBuilder WithAdditional(string additional)
    {
        _item.Additional = additional;
        return this;
    }
    public CoffeeBuilder WithTube()
    {
        _item.HasTube = true;
        return this;
    }
}

public static class GenericBuilderExample
{
    public static void Run()
    {
        var pizza = new PizzaBuilder()
            .WithLabel("Маргарита")
            .WithSlices(8)
            .Build();
        Console.WriteLine(pizza);

        var coffee = new CoffeeBuilder()
            .WithLabel("Капучино")
            .WithAdditional("Молоко")
            .WithTube()
            .Build();
        
        Console.WriteLine(coffee);
    }
}

