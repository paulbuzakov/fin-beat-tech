using FinBeat.Tech.Contracts.DTO;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FinBeat.Tech.Api;

public class DictionaryListSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(DictionaryListDto))
        {
            schema.Example = new OpenApiArray()
            {
                new OpenApiObject()
                {
                    ["1"] = new OpenApiString("value1"),
                    ["5"] = new OpenApiString("value2"),
                    ["10"] = new OpenApiString("value32"),
                }
            };
        }
    }
}