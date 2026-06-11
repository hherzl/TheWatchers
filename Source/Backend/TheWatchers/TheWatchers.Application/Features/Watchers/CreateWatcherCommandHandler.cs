using TheWatchers.Application.Abstractions;
using TheWatchers.Application.Services;
using TheWatchers.SharedKernel.Models.Common;

namespace TheWatchers.Application.Features.Watchers;

public sealed class CreateWatcherCommandHandler(IWatchersService service) : IRequestHandler<CreateWatcherCommand, CreatedResponse<short?>>
{
    public async Task<CreatedResponse<short?>> HandleAsync(CreateWatcherCommand request, CancellationToken ct = default)
    {
        return new(await service.CreateWatcherAsync(request, ct));
    }
}
