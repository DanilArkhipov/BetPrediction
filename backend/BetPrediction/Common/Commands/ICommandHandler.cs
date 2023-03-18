namespace Common.Commands;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task ExecuteAsync(TCommand command);
}