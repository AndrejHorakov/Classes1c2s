using ReflectionClass.DependencyInjection.Repositories.Interfaces;

namespace ReflectionClass.DependencyInjection.Repositories.Implementations;

public class Repo : IRepo
{
    public void GetData() => Console.WriteLine("Repo работает!");
}