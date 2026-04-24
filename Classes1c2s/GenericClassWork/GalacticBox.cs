namespace GenericClassWork;

// T — это "Type". Сюда можно подставить что угодно!
public class GalacticBox<T> {
    public T Inhabitant { get; set; }

    public void Secure() {
        Console.WriteLine($"Существо {typeof(T).Name} надежно заперто!");
    }
}