using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementRedBag : ElementBase
    {
        public ElementRedBag() : base(ElementType.RedBag)
        {
        }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
    }
}