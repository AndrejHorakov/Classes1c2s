using System.Reflection;
using ReflectionClass.MediatorImplementation.Commands.Ping;

namespace ReflectionClass.MediatorImplementation;

public static class MediatorProgram
{
    public static void Main()
    {
        var mediator = new Mediator();
        mediator.ScanAssembly(); // Он найдет PingHandler через рефлексию
        
        mediator.Send(new PingCommand());

        
    }
}