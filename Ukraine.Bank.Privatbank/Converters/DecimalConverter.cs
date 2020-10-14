using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ukraine.Bank.Privatbank.Converters
{
    public class DecimalConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return decimal.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}