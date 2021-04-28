using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Elements
{
    [JsonConverter(typeof(ElementJsonConverter))]
    public abstract class Element
    {
        protected Element(ElementType type)
        {
            Type = type;
        }

        // Internal Property Type to encourage using `element is ElementXXX xxx` instead of checking Type.
        [JsonIgnore]
        [JsonPropertyName("type")]
        internal ElementType Type { get; }

        [JsonIgnore]
        [JsonPropertyName("data")]
        public Element Data => this;
    }
}