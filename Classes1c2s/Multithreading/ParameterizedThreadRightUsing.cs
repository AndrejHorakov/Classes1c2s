namespace Multithreading;

public class ParameterizedThreadRightUsing
{
    public static void Run()
    {
        Person tom = new Person("Tom", 37);
        // создаем новый поток
        Thread myThread = new Thread(tom.Print);
        myThread.Start();
 
    }
}
record Person(string Name, int Age)
{
    public void Print()
    {
        Console.WriteLine($"Name = {Name}");
        Console.WriteLine($"Age = {Age}");
    }
}
