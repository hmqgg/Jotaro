using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementFace : ElementBase
    {
        public ElementFace() : base(ElementType.Face)
        {
        }

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        public override bool IsValid => !string.IsNullOrEmpty(Id);
    }
}