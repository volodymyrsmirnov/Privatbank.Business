using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Converters
{
    internal class StringDateTimeArrayConverter : JsonConverter<DateTime[]>
    {
        public override DateTime[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var resultList = new List<DateTime>();

            if (reader.TokenType == JsonTokenType.StartArray)
                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                    resultList.Add(DateTime.TryParseExact(
                        reader.GetString(),
                        "dd.MM.yyyy HH:mm:ss",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AssumeLocal, out var result)
                        ? result
                        : DateTime.MinValue);

            return resultList.ToArray();
        }

        public override void Write(Utf8JsonWriter writer, DateTime[] value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}