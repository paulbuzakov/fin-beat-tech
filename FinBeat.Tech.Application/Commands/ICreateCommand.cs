using FinBeat.Tech.Data.Domains;

namespace FinBeat.Tech.Application.Commands;

public interface ICreateCommand : ICommand<List<DictionaryItem>>
{
}