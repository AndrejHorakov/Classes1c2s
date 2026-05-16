using System.Threading.Channels;
using ReflectionClass.DependencyInjection.Repositories.Implementations;
using ReflectionClass.DependencyInjection.Repositories.Interfaces;
using ReflectionClass.DependencyInjection.Services.Implementations;

namespace ReflectionClass.DependencyInjection;

public static class DIProgram
{
    public static void Main()
    {
        var container = new MyContainer();
        container.Register<IRepo, Repo>(); 
        container.Register<Service,Service>();

        var service = container.Resolve<Service>();
        Console.WriteLine(service.ToString());
    }
}