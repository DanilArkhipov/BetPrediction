namespace Common.Commands;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task ExecuteAsync(TCommand command);
}

public interface ICommandHandler<in TCommand, TResultData> where TCommand : ICommand
{
    Task<TResultData> ExecuteAsync(TCommand command);
}