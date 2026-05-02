using ReflectionClass.MediatorImplementation.Abstraction;

namespace ReflectionClass.MediatorImplementation.Commands.Ping;

public class PingCommandHandler : ICommandHandler<PingCommand>
{
    public void Handle(PingCommand command)
    {
        Console.WriteLine($"Обработчик получил: {command.Message}");
    }
}