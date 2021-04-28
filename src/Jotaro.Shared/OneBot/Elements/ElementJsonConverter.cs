using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dahomey.Json;
using Jotaro.Shared.OneBot.Elements.ElementData;

namespace Jotaro.Shared.OneBot.Elements
{
    public class ElementJsonConverter : JsonConverter<Element>
    {
        private static readonly byte[] TypePropertyName = Encoding.UTF8.GetBytes("type");
        private static readonly byte[] DataPropertyName = Encoding.UTF8.GetBytes("data");

        private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions().SetupExtensions();

        public override Element Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions options)
        {
            if (JsonDocument.TryParseValue(ref reader, out var doc) &&
                doc.RootElement.TryGetProperty(TypePropertyName, out var typeProperty) &&
                doc.RootElement.TryGetProperty(DataPropertyName, out var dataProperty))
            {
                ElementType type;
                try
                {
                    type = JsonSerializer.Deserialize<ElementType>(typeProperty.GetRawText(), options);
                }
                catch (Exception)
                {
                    // Swallow here to ignore unknown type.
                    type = ElementType.Empty;
                }

                return type switch
                {
                    ElementType.Text => JsonSerializer.Deserialize<ElementText>(dataProperty.GetRawText(), options),
                    ElementType.Image => JsonSerializer.Deserialize<ElementImage>(dataProperty.GetRawText(), options),
                    ElementType.Record => JsonSerializer.Deserialize<ElementRecord>(dataProperty.GetRawText(), options),
                    ElementType.At => JsonSerializer.Deserialize<ElementAt>(dataProperty.GetRawText(), options),
                    ElementType.Reply => JsonSerializer.Deserialize<ElementReply>(dataProperty.GetRawText(), options),
                    ElementType.Face => JsonSerializer.Deserialize<ElementFace>(dataProperty.GetRawText(), options),
                    ElementType.Share => JsonSerializer.Deserialize<ElementShare>(dataProperty.GetRawText(), options),
                    ElementType.Music => JsonSerializer.Deserialize<ElementMusic>(dataProperty.GetRawText(), options),
                    ElementType.Video => JsonSerializer.Deserialize<ElementVideo>(dataProperty.GetRawText(), options),
                    // ElementType.Gift => JsonSerializer.Deserialize<ElementGift>(dataProperty.GetRawText(), options),
                    ElementType.RedBag => JsonSerializer.Deserialize<ElementRedBag>(dataProperty.GetRawText(), options),
                    // ElementType.Poke => JsonSerializer.Deserialize<ElementPoke>(dataProperty.GetRawText(), options),
                    ElementType.Forward => JsonSerializer.Deserialize<ElementForward>(dataProperty.GetRawText(),
                        options),
                    // ElementType.Node => JsonSerializer.Deserialize<ElementNode>(dataProperty.GetRawText(), options),
                    // ElementType.Tts => JsonSerializer.Deserialize<ElementTts>(dataProperty.GetRawText(), options),
                    _ => (Element?) null
                } ?? ElementEmpty.Instance;
            }

            return ElementEmpty.Instance;
        }

        public override void Write(Utf8JsonWriter writer, Element value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(TypePropertyName);
            JsonSerializer.Serialize(writer, value.Type, options);

            if (value.Data is ElementBase eb)
            {
                writer.WritePropertyName(DataPropertyName);
                JsonSerializer.Serialize(writer, eb, SerializerOptions);
            }

            writer.WriteEndObject();
        }
    }
}