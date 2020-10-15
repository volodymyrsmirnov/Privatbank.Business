using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Converters
{
    internal class StringDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string[] formats =
            {
                "dd.MM.yyyy HH:mm:ss",
                "dd-MM-yyyy HH:mm:ss",
                "dd-MM-yyyy",
                "dd.MM.yyyy",
                "HH:mm"
            };

            return DateTime.TryParseExact(
                reader.GetString(),
                formats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeLocal | DateTimeStyles.NoCurrentDateDefault, out var result)
                ? result
                : DateTime.MinValue;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(
                value.ToString("dd.MM.yyyy"));
        }
    }
}