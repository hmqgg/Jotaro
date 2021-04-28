using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json.Serialization;
using Dahomey.Json.Attributes;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementImage : ElementFile
    {
        public ElementImage(string url) : base(ElementType.Image, url)
        {
        }

        public ElementImage(ReadOnlySpan<byte> bytes) : base(ElementType.Image, bytes)
        {
        }

        public ElementImage(Stream stream, bool leaveOpen = false) : base(ElementType.Image, stream, leaveOpen)
        {
        }

        [JsonIgnoreIfDefault]
        [DefaultValue("")]
        [JsonPropertyName("type")]
        public new string Type { get; set; } = string.Empty;

        [JsonIgnoreIfDefault]
        [DefaultValue("40000")]
        [JsonPropertyName("id")]
        public string Id { get; set; } = "40000";

        [JsonIgnoreIfDefault]
        [DefaultValue(1)]
        [JsonPropertyName("c")]
        public int C { get; set; } = 1;
    }
}