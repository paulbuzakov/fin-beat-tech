using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinBeat.Tech.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DictionaryController : ControllerBase
{
    [HttpPost("range")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> SaveRange()
    {
        var url = HttpContext.Request.GetDisplayUrl();
        const int createdRows = 0;
        return Created(url, createdRows);
    }
}