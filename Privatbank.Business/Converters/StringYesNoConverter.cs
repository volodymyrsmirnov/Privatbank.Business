using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Converters {
    internal class StringYesNoConverter : JsonConverter<bool> {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var result = reader.GetString();

            return result.Equals("yes", StringComparison.InvariantCultureIgnoreCase) ||
                   result.Equals("y", StringComparison.InvariantCultureIgnoreCase);
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) {
            throw new NotImplementedException();
        }
    }
}