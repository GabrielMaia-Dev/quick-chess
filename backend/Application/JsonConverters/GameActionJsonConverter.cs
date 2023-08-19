using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Chess;

namespace Application;

public class GameActionJsonConverter : JsonConverter<GameAction>
{
    private readonly Dictionary<string, Type> dictionary;

    public GameActionJsonConverter(Dictionary<string, Type> dictionary)
    {
        this.dictionary = dictionary;
    }
    public override GameAction? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if(reader.TokenType != JsonTokenType.StartObject) throw null!;

        reader.Read();
        if(reader.TokenType != JsonTokenType.PropertyName) throw null!;
        if(reader.GetString() != "$type") throw null!;
        
        reader.Read();
        var type = reader.GetString();

        if(type is null || !dictionary.ContainsKey(type)) throw null!;

        reader.Read();
        if(reader.TokenType != JsonTokenType.PropertyName) throw null!;
        if(reader.GetString() != "action") throw null!;

        reader.Read();
        var obj = JsonSerializer.Deserialize(ref reader, dictionary[type], options);


        reader.Read();

        if(reader.TokenType != JsonTokenType.EndObject) throw null!;
        return obj as GameAction;
    }

    public override void Write(Utf8JsonWriter writer, GameAction value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}