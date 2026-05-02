using ReflectionClass.MediatorImplementation.Abstraction;

namespace ReflectionClass.MediatorImplementation.Commands.Ping;

public class PingCommand : ICommand
{
    public string Message = "Привет!";
}