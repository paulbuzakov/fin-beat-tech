
namespace FinBeat.Tech.Application;

public interface ICommand<TData>
{
    Task ExecuteAsync(TData data, CancellationToken cancellationToken);
}

public interface ICommand<TData, TResult>
{
    Task<TResult> ExecuteAsync(TData data, CancellationToken cancellationToken);
}