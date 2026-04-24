namespace ObjectOrientedProgramming.SOLID;

public interface IRobot
{
    void Work();
}

public class RobotMonkey : IRobot
{
    public void Work()
    {
        Console.WriteLine("Обезьяна работает");
    }
}

public class RepairService
{
    public void Fix(IRobot robot)
    {
        Console.WriteLine("Робот починен");
    }
}

public interface IClimbable
{
    void Climb();
}

public interface IFlyable
{
    void Fly();
}

// Обезьяна только лезет, но не летает
public class SuperMonkey : IRobot, IClimbable
{
    public void Work() => Climb();
    public void Climb() => Console.WriteLine("Лезу на пальму");
}

class GoodZoo
{
    private readonly List<IRobot> _robots;

    // Мы передаем список роботов извне (Dependency Injection)
    public GoodZoo(List<IRobot> robots)
    {
        _robots = robots;
    }

    public void StartDay()
    {
        foreach (var robot in _robots)
        {
            robot.Work(); // Работает любой робот: хоть обезьяна, хоть слон, хоть пылесос
        }
    }
}