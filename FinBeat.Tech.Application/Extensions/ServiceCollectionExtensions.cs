using FinBeat.Tech.Application.Commands;
using FinBeat.Tech.Application.Commands.Internal;
using FinBeat.Tech.Application.Queries;
using FinBeat.Tech.Application.Queries.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace FinBeat.Tech.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<ICreateCommand, CreateCommand>();
        services.AddScoped<IGetAllQuery, GetAllQuery>();
        services.AddScoped<IGetQuery, GetQuery>();
    }
}