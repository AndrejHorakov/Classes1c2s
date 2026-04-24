namespace ObjectOrientedProgramming.Examples;

// 1. АБСТРАКЦИЯ: Создаем общую идею робота-животного
public interface IChargeable 
{
    void Charge(); // Просто заголовок, никакого кода внутри
}
abstract class RobotAnimal : IChargeable
{
    // 2. ИНКАПСУЛЯЦИЯ: BatteryLevel можно прочитать снаружи, 
    // но менять (set) может только сам класс или его наследники (protected).
    public int BatteryLevel { get; protected set; } = 100;

    public abstract bool Work();
    public void Charge()
    {
        BatteryLevel = 100;
        Console.WriteLine("Заряжено до 100%!");
    }
}

// 3. НАСЛЕДОВАНИЕ: Робо-Обезьяна перенимает всё от RobotAnimal
class RobotMonkey : RobotAnimal
{
    // 4. ПОЛИМОРФИЗМ: Реализуем Work именно для обезьяны
    public override bool Work()
    {
        if (BatteryLevel >= 10)
        {
            BatteryLevel -= 10;
            Console.WriteLine($"Обезьяна собирает бананы. Заряд: {BatteryLevel}%");
            return true;
        }

        Console.WriteLine("Обезьяна: Нужна подзарядка!");
        return false;
    }
}

class RobotElephant : RobotAnimal
{
    public override bool Work()
    {
        if (BatteryLevel >= 20)
        {
            BatteryLevel -= 20;
            Console.WriteLine($"Слон поливает цветы. Заряд: {BatteryLevel}%");
            return true;
        }

        Console.WriteLine("Слон: Нужна подзарядка!");
        return false;
    }
}

class ToyMonkey : RobotAnimal
{
    public override bool Work()
    {
        throw new NotImplementedException();
    }
}