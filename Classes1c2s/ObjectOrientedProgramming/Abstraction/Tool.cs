namespace ObjectOrientedProgramming.Abstraction;

abstract class Tool
{
    // Мы знаем, что инструмент надо использовать, но как именно — решит конкретный инструмент
    public abstract void Use();
}

class Hammer : Tool
{
    public override void Use()
    {
        Console.WriteLine("Стук-стук!");
    }
}