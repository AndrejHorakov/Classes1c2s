namespace GenericClassWork.BuilderExample;

public class BreakfastBuilder
{
    private readonly Breakfast _breakfast;

    public BreakfastBuilder()
    {
        _breakfast = new Breakfast
        {
            Base = [],
            Species = []
        };
    }

    public BreakfastBuilder AddBase(string baseName)
    {
        _breakfast.Base.Add(baseName);
        return this;
    } 
    
    public BreakfastBuilder AddSpecies(string spiceName)
    {
        _breakfast.Species.Add(spiceName);
        return this;
    }

    public BreakfastBuilder WithDrink(string drink)
    {
        _breakfast.Drink = drink;
        return this;
    }
    
    public Breakfast Build()
    {
        return _breakfast;
    }
}

public static class BreakfastBuilderExample
{
    public static void Run()
    {
        var proteinBreakfast = new BreakfastBuilder();
        proteinBreakfast
            .AddBase("Яйца")
            .AddBase("Яйца")
            .AddBase("Яйца")
            .AddBase("Яйца")
            .WithDrink("Кофе");
        var smallBreakfast = new BreakfastBuilder();
        smallBreakfast
            .AddBase("Бутерброд")
            .WithDrink("Чай");

        Console.WriteLine(proteinBreakfast.Build());
        Console.WriteLine(smallBreakfast.Build());
    }
}