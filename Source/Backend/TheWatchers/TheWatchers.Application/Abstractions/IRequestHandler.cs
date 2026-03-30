namespace TheWatchers.Application.Abstractions;

public interface IRequestHandler<TRequest, TResponse> where TRequest : class where TResponse : class
{
    Task<TResponse> HandleAsync(TRequest request, CancellationToken ct = default);
}
