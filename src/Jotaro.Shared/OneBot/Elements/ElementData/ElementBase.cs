using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public abstract class ElementBase : Element
    {
        protected ElementBase(ElementType type) : base(type)
        {
        }

        [JsonIgnore]
        public virtual bool IsValid => true;
    }
}