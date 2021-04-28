using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementPoke : ElementBase
    {
        public ElementPoke(long qq) : base(ElementType.Poke)
        {
            Qq = qq;
        }

        [JsonPropertyName("qq")]
        public long Qq { get; set; }

        public override bool IsValid => Qq > 0;
    }
}