using System.Text.Json;
using System.Text.Json.Serialization;

namespace Engine.Visuals.Sprites;

public class FrameDimensionArrayConverter : JsonConverter<FrameDimension[]>
{
    public override FrameDimension[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var list = new List<int>();
        if (reader.Read() && reader.TokenType == JsonTokenType.StartArray)
        {
            while (true)
            {
                if (reader.Read() && reader.TokenType == JsonTokenType.StartArray)
                {
                    if (reader.TokenType == JsonTokenType.Number)
                    {
                        list.Add(reader.GetInt32());
                    }
                }
            }
        }
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, FrameDimension[] value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}