using FinBeat.Tech.Data;
using FinBeat.Tech.Data.Domains;
using Microsoft.EntityFrameworkCore;

namespace FinBeat.Tech.Application.Queries.Internal;

internal class GetAllQuery(FbtDbContext dbContext) : IGetAllQuery
{
    public async Task<DictionaryItem[]> GetAsync(CancellationToken cancellationToken)
    {
        return await dbContext.DictionaryItems.ToArrayAsync(cancellationToken);
    }
}