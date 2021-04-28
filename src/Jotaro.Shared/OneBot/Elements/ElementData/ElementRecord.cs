using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json.Serialization;
using Dahomey.Json.Attributes;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementRecord : ElementFile
    {
        public ElementRecord(string url) : base(ElementType.Record, url)
        {
        }

        public ElementRecord(ReadOnlySpan<byte> bytes) : base(ElementType.Record, bytes)
        {
        }

        public ElementRecord(Stream stream, bool leaveOpen = false) : base(ElementType.Record, stream, leaveOpen)
        {
        }

        [JsonIgnoreIfDefault]
        [DefaultValue(0)]
        [JsonPropertyName("magic")]
        public int Magic { get; set; } = 0;
    }
}