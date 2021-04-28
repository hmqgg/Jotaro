using System.ComponentModel;
using System.Text.Json.Serialization;
using Dahomey.Json.Attributes;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementMusic : ElementBase
    {
        public ElementMusic(ElementMusicType type, string id) : base(ElementType.Music)
        {
            Type = type;
            Id = id;
        }

        public ElementMusic(string audio, string title = "") : base(ElementType.Music)
        {
            Type = ElementMusicType.Custom;
            Audio = audio;
            Title = title;
        }

        [JsonPropertyName("type")]
        public new ElementMusicType Type { get; set; }

        [JsonIgnoreIfDefault]
        [DefaultValue("")]
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonIgnoreIfDefault]
        [DefaultValue("")]
        [JsonPropertyName("audio")]
        public string Audio { get; set; } = string.Empty;

        [JsonIgnoreIfDefault]
        [DefaultValue("")]
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        public override bool IsValid =>
            Type == ElementMusicType.Custom ? !string.IsNullOrEmpty(Audio) : !string.IsNullOrEmpty(Id);
    }
}