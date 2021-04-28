using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using Dahomey.Json.Attributes;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementNode : ElementBase
    {
        public ElementNode(int id) : base(ElementType.Node)
        {
            Id = id;
        }

        public ElementNode(long uin, string name, IEnumerable<Element>? content, IEnumerable<Element>? seq = null) :
            base(ElementType.Node)
        {
            Uin = uin;
            Name = name;
            Content = content;
            Seq = seq;
        }

        [JsonIgnoreIfDefault]
        [DefaultValue(0)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonIgnoreIfDefault]
        [DefaultValue(0)]
        [JsonPropertyName("uin")]
        public long Uin { get; set; }

        [JsonIgnoreIfDefault]
        [DefaultValue("")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonIgnoreIfDefault]
        [DefaultValue(null)]
        [JsonPropertyName("content")]
        public IEnumerable<Element>? Content { get; set; }

        [JsonIgnoreIfDefault]
        [DefaultValue(null)]
        [JsonPropertyName("seq")]
        public IEnumerable<Element>? Seq { get; set; }

        public override bool IsValid => Id != 0 || Uin > 0 && Content != null && Content.Any();
    }
}