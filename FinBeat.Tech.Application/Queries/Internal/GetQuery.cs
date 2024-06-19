using FinBeat.Tech.Data;
using FinBeat.Tech.Data.Domains;
using Microsoft.EntityFrameworkCore;

namespace FinBeat.Tech.Application.Queries.Internal;

internal class GetQuery(FbtDbContext dbContext) : IGetQuery
{
    public async Task<DictionaryItem[]> GetAsync(ViewFilter filter, CancellationToken cancellationToken)
    {
        var query = dbContext.DictionaryItems.AsQueryable();
        if (filter.Code != null)
        {
            query = query.Where(i => i.Code == filter.Code);
        }

        if (!string.IsNullOrWhiteSpace(filter.Value))
        {
            query = query.Where(i => i.Value.StartsWith(filter.Value));
        }

        return await query.ToArrayAsync(cancellationToken);
    }
}