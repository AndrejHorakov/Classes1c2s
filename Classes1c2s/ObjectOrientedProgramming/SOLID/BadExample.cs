namespace ObjectOrientedProgramming.SOLID;

class BadRobotMonkey {
    public void Work() {
        Console.WriteLine("Собираю бананы...");
    }
    
    public void Repair() {
        Console.WriteLine("Чиню шестеренки...");
    }

    public void SaveToDatabase() {
        Console.WriteLine("Сохраняю отчет в SQL Server...");
    }
}
class BadRobotElephant {
    public void Work() {
        Console.WriteLine("Поливать цветы...");
    }
    
    public void Repair() {
        Console.WriteLine("Чиню гайки...");
    }

    public void SaveToDatabase() {
        Console.WriteLine("Сохраняю отчет в SQL Server...");
    }
}

class BadZoo {
    private BadRobotMonkey _monkey = new BadRobotMonkey(); 
    private BadRobotElephant _elephant = new BadRobotElephant();

    public void StartDay() {
        _monkey.Work();
        _elephant.Work();
    }
}