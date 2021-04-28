using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementGift : ElementBase
    {
        public ElementGift(long qq, int id) : base(ElementType.Gift)
        {
            Qq = qq;
            Id = id;
        }

        [JsonPropertyName("qq")]
        public long Qq { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        public override bool IsValid => Qq > 0 && Id >= 0;
    }
}