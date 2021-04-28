using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Dahomey.Json.Attributes;
using Jotaro.Shared.Utils;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementReply : ElementBase
    {
        public ElementReply(int id) : base(ElementType.Reply)
        {
            Id = id;
        }

        public ElementReply(string text, long qq, DateTimeOffset? time = null, long seq = 0) : base(ElementType.Reply)
        {
            Text = text;
            Qq = qq;
            Time = time;
            Seq = seq;
        }

        [JsonIgnoreIfDefault]
        [DefaultValue(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonIgnoreIfDefault]
        [DefaultValue("")]
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;

        [JsonIgnoreIfDefault]
        [DefaultValue(0)]
        [JsonPropertyName("qq")]
        public long Qq { get; set; }

        [JsonConverter(typeof(UnixTimestampJsonConverter))]
        [JsonIgnoreIfDefault]
        [DefaultValue(null)]
        [JsonPropertyName("time")]
        public DateTimeOffset? Time { get; set; }

        [JsonIgnoreIfDefault]
        [DefaultValue(0)]
        [JsonPropertyName("seq")]
        public long Seq { get; set; }

        public override bool IsValid => Id > 0 || Qq > 0 && !string.IsNullOrEmpty(Text);
    }
}