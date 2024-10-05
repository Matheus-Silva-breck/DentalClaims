using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DentalClaims.Application.DTOs
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string Format = "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                int year = 0;
                int month = 0;
                int day = 0;

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        break;
                    }

                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        string propertyName = reader.GetString() ?? throw new JsonException("Property name cannot be null.");

                        reader.Read();
                        if (reader.TokenType == JsonTokenType.Number)
                        {
                            int value = reader.GetInt32();

                            switch (propertyName)
                            {
                                case "Year":
                                    year = value;
                                    break;
                                case "Month":
                                    month = value;
                                    break;
                                case "Day":
                                    day = value;
                                    break;
                                default:
                                    throw new JsonException($"Unexpected property name: {propertyName}");
                            }
                        }
                    }
                }

                return new DateOnly(year, month, day);
            }

            throw new JsonException("Expected StartObject token for DateOnly.");
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format));
        }
    }
}
