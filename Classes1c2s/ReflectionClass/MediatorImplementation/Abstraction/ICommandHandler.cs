namespace ReflectionClass.MediatorImplementation.Abstraction;

public interface ICommandHandler<T> where T : ICommand
{
    void Handle(T command);
}