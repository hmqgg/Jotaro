using System.ComponentModel;
using System.Text.Json.Serialization;
using Dahomey.Json.Attributes;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementShare : ElementBase
    {
        public ElementShare(string url) : base(ElementType.Share)
        {
            Url = url;
        }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonIgnoreIfDefault]
        [DefaultValue("")]
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonIgnoreIfDefault]
        [DefaultValue("")]
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        [JsonIgnoreIfDefault]
        [DefaultValue("")]
        [JsonPropertyName("image")]
        public string Image { get; set; } = string.Empty;

        public override bool IsValid => !string.IsNullOrEmpty(Url);
    }
}