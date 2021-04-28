using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementForward : ElementBase
    {
        public ElementForward(int id) : base(ElementType.Forward)
        {
            Id = id;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        public override bool IsValid => Id != 0;
    }
}