using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Chess;

namespace Application;

public class ChessBoardConverter : JsonConverter<ChessBoard>
{
    public override ChessBoard Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, ChessBoard value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToFen());
    }
}