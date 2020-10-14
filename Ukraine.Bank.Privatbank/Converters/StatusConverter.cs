using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ukraine.Bank.Privatbank.Converters
{
    internal class StatusConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString()
                .Equals("success", StringComparison.InvariantCultureIgnoreCase);
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}