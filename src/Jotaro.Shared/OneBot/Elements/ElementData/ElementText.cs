using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementText : ElementBase
    {
        public ElementText() : base(ElementType.Text)
        {
        }

        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;
    }
}