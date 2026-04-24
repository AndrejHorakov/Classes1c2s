namespace ObjectOrientedProgramming.Inheritance;

class Animal 
{
    public void Eat() 
    {
        Console.WriteLine("Ест...");
    }
}

// Обезьяна наследует всё от Животного
class Monkey : Animal 
{
    public void Climb() 
    {
        Console.WriteLine("Лезет на дерево!");
    }
}