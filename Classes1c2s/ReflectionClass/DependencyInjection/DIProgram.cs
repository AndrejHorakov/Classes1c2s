using ReflectionClass.DependencyInjection.Repositories.Implementations;
using ReflectionClass.DependencyInjection.Repositories.Interfaces;
using ReflectionClass.DependencyInjection.Services.Implementations;

namespace ReflectionClass.DependencyInjection;

public class DIProgram
{
    static void Main(string[] args)
    {
        var container = new MyContainer();
        container.Register<IRepo, Repo>(); 

        var service = container.Resolve<Service>();
    }
}