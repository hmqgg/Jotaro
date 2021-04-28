using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementTts : ElementBase
    {
        public ElementTts(string text) : base(ElementType.Tts)
        {
            Text = text;
        }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        public override bool IsValid => !string.IsNullOrEmpty(Text);
    }
}