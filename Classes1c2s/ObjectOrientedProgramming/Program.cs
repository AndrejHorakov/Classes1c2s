using ObjectOrientedProgramming.Examples;


// Создаем список роботов (используем базовый тип для полиморфизма)
List<RobotAnimal> zoo =
[
    new RobotMonkey(),
    new RobotElephant(),
    new ToyMonkey()
];

Console.WriteLine("--- Симулятор Робо-Зоопарка ---");

// Заставляем их работать несколько раз
for (int i = 0; i < 6; i++)
{
    foreach (var robot in zoo)
    {
        robot.Work();
        if (robot.BatteryLevel == 0)
            robot.Charge();
    }
}