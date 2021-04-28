using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementEmpty : ElementBase
    {
        public ElementEmpty() : base(ElementType.Empty)
        {
        }

        [JsonIgnore]
        public static ElementEmpty Instance => new ElementEmpty();

        public override bool IsValid => false;
    }
}