namespace ObjectOrientedProgramming.Encapsulation;

public class Monkey
{
    private int _energy = 100; // Скрыто от чужих рук

    public void Sleep() 
    {
        _energy += 10; // Менять энергию можно только через этот метод
        Console.WriteLine("Обезьяна поспала.");
    }

    public void Climb()
    {
        if (_energy < 10)
            throw new Exception("Мало энергии.");
        _energy -= 10;
    }
}