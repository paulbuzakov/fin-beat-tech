using FinBeat.Tech.Application.Queries.Internal;
using FinBeat.Tech.Data.Domains;

namespace FinBeat.Tech.Application.Queries;

public interface IGetQuery : IQuery<ViewFilter, DictionaryItem[]>
{
}