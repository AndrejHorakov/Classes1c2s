using ReflectionClass.DependencyInjection.Repositories.Interfaces;

namespace ReflectionClass.DependencyInjection.Services.Implementations;

public class Service
{
    public Service(IRepo repo)
    {
        repo.GetData();
    }
}