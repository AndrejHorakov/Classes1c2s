using ReflectionClass.MediatorImplementation.Commands.Ping;

namespace ReflectionClass.MediatorImplementation;

public class MediatorProgram
{
    static void Main(string[] args)
    {
        var mediator = new Mediator();
        mediator.ScanAssembly(); // Он найдет PingHandler через рефлексию

        mediator.Send(new PingCommand());
    }
}