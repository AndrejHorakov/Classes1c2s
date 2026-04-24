namespace ObjectOrientedProgramming.Polymorphism;

class Animal
{
    public virtual void MakeSound()
    {
        // virtual — разрешаем переделывать
        Console.WriteLine("Тишина...");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Гав-гав!");
    }
}

class Monkey : Animal
{
    public override void MakeSound()
    {
        // override — переделываем под себя
        Console.WriteLine("У-у-а-а!");
    }
}

// var animals = new List<Animal>();
// animals.Add(new Animal());
// animals.Add(new Monkey());
// foreach(var animal in animals)
// {
//      animal.MakeSound();
// }

// Статический
class Calculator
{
    // Метод для целых чисел
    public int Add(int a, int b)
    {
        return a + b;
    }

    // ТО ЖЕ ИМЯ, но для дробных чисел (это и есть статический полиморфизм)
    public double Add(double a, double b)
    {
        return a + b;
    }
}