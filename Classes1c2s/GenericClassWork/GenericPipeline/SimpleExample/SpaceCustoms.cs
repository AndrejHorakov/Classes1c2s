namespace GenericClassWork.GenericPipeline.SimpleExample;

public class Cargo
{
    public string Name { get; set; }
    public bool IsRadioactive { get; set; }
    public bool HasInfection { get; set; }
}

// 1. Обработчик радиации
public class RadiationScanner : Handler<Cargo>
{
    public override void Handle(Cargo cargo)
    {
        if (cargo.IsRadioactive)
        {
            Console.WriteLine($"[STOP] Груз {cargo.Name} фонит! В карантин.");
        }
        else
        {
            Console.WriteLine($"[OK] {cargo.Name} чист от радиации.");
            base.Handle(cargo); // Идем дальше по цепи
        }
    }
}

// 2. Обработчик инфекций
public class InfectionScanner : Handler<Cargo>
{
    public override void Handle(Cargo cargo)
    {
        if (cargo.HasInfection)
        {
            Console.WriteLine($"[STOP] В {cargo.Name} найдены паразиты!");
        }
        else
        {
            Console.WriteLine($"[OK] {cargo.Name} биологически безопасен.");
            base.Handle(cargo);
        }
    }
}

public static class GenericClassWorkSpace
{
    public static void Run()
    {
        var radiation = new RadiationScanner();
        var infection = new InfectionScanner();

        // Соединяем звенья
        radiation.SetNext(infection);
        infection.SetNext(radiation); 

        var suspiciousBox = new Cargo
        {
            Name = "Ящик с Марса", 
            IsRadioactive = true, 
            HasInfection = true
        };

        // Запускаем первый сканер — он сам передаст второму, если всё ок
        radiation.Handle(suspiciousBox);
        infection.Handle(suspiciousBox);
    }
}