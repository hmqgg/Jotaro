using System.Text.Json.Serialization;
using Dahomey.Json.Attributes;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementAt : ElementBase
    {
        public ElementAt() : base(ElementType.At)
        {
        }

        [JsonPropertyName("qq")]
        public string Qq { get; set; } = string.Empty;

        [JsonIgnoreIfDefault]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        public override bool IsValid => Qq == "all" || long.TryParse(Qq, out var id) && id > 0;
    }
}