namespace FinBeat.Tech.Application;

public interface IQuery<TResult>
{
    Task<TResult> GetAsync(CancellationToken cancellationToken);
}

public interface IQuery<TData, TResult>
{
    Task<TResult> GetAsync(TData data, CancellationToken cancellationToken);
}