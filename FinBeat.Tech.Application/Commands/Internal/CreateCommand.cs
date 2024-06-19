using FinBeat.Tech.Data;
using FinBeat.Tech.Data.Domains;
using Microsoft.EntityFrameworkCore;

namespace FinBeat.Tech.Application.Commands.Internal;

internal class CreateCommand(FbtDbContext dbContext) : ICreateCommand
{
    public async Task ExecuteAsync(List<DictionaryItem> data, CancellationToken cancellationToken)
    {
        await dbContext.DictionaryItems.ExecuteDeleteAsync(cancellationToken: cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        var newList = data.OrderBy(item => item.Code).ToList();
        await dbContext.DictionaryItems.AddRangeAsync(newList, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}