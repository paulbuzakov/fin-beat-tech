using FinBeat.Tech.Application.Commands;
using FinBeat.Tech.Application.Queries;
using FinBeat.Tech.Contracts.DTO;
using FinBeat.Tech.Data.Domains;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace FinBeat.Tech.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DictionaryController : ControllerBase
{
    
    [HttpPost("range")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> SaveRange(
        [FromServices] ICreateCommand command,
        DictionaryListDto data,
        CancellationToken cancellationToken)
    {
        var dataList = data
            .Select((item) => DictionaryItem.Create(item.Code, item.Value))
            .ToList();
        await command.ExecuteAsync(dataList, cancellationToken);

        return Created(HttpContext.Request.GetDisplayUrl(), data);
    }

    [HttpGet()]
    [ProducesResponseType<DictionaryItem[]>(StatusCodes.Status200OK)]
    public async Task<DictionaryItem[]> GetAll(
        [FromServices] IGetQuery query,
        [FromQuery] ViewFilter filter,
        CancellationToken cancellationToken)
    {
        return await query.GetAsync(filter, cancellationToken);
    }

    [HttpGet("all")]
    [ProducesResponseType<DictionaryItem[]>(StatusCodes.Status200OK)]
    public async Task<DictionaryItem[]> GetAll(
        [FromServices] IGetAllQuery query,
        CancellationToken cancellationToken)
    {
        return await query.GetAsync(cancellationToken);
    }
}