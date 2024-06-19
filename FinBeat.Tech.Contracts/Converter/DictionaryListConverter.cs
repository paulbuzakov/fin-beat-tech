using System.Text.Json;
using System.Text.Json.Serialization;
using FinBeat.Tech.Contracts.DTO;

namespace FinBeat.Tech.Contracts.Converter;

public class DictionaryListConverter : JsonConverter<DictionaryListDto>
{
    public override DictionaryListDto Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        var result = new DictionaryListDto();
        
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException("Expected StartArray token");
        }

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                break;
            }

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Expected StartObject token");
            }

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var key = reader.GetString();
                    reader.Read(); // Move to the value token
                    var value = reader.GetString();

                    if (int.TryParse(key, out int code))
                    {
                        result.Add(new DictionaryItemCreateDto { Code = code, Value = value });
                    }
                    else
                    {
                        throw new JsonException("Key is invalid");
                    }
                }
            }
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, DictionaryListDto value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (var item in value)
        {
            writer.WriteStartObject();
            writer.WriteString(item.Code.ToString(), item.Value);
            writer.WriteEndObject();
        }

        writer.WriteEndArray();
    }
}