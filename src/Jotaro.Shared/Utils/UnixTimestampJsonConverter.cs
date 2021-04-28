using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Jotaro.Shared.Utils
{
    public class UnixTimestampJsonConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type _0, JsonSerializerOptions _1) =>
            DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64());

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options) =>
            writer.WriteNumberValue(value.ToUnixTimeSeconds());
    }
}