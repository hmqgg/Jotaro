using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json.Serialization;
using Cysharp.Text;
using Dahomey.Json.Attributes;
using gfoidl.Base64;
using Jotaro.Shared.Utils;

namespace Jotaro.Shared.OneBot.Elements.ElementData
{
    public class ElementVideo : ElementBase
    {
        private const string BASE64_PREFIX = "base64://";

        public ElementVideo(string file) : base(ElementType.Video)
        {
            File = file;
        }

        public ElementVideo(string file, ReadOnlySpan<byte> coverBytes) : base(ElementType.Video)
        {
            File = file;
            Cover = ZString.Concat(BASE64_PREFIX, Base64.Default.Encode(coverBytes));
        }

        public ElementVideo(string file, Stream coverStream, bool leaveOpen = false) : base(ElementType.Video)
        {
            File = file;
            Cover = ZString.Concat(BASE64_PREFIX, coverStream.ToBase64String());
            if (!leaveOpen)
            {
                coverStream.Dispose();
            }
        }

        [JsonPropertyName("file")]
        public string File { get; }

        [JsonIgnoreIfDefault]
        [DefaultValue("")]
        [JsonPropertyName("cover")]
        public string Cover { get; } = string.Empty;

        [JsonIgnoreIfDefault]
        [DefaultValue(1)]
        [JsonPropertyName("c")]
        public int C { get; set; } = 1;

        public override bool IsValid => !string.IsNullOrEmpty(File);
    }
}