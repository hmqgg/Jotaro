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
    public abstract class ElementFile : ElementBase
    {
        protected const string BASE64_PREFIX = "base64://";

        [JsonIgnore]
        protected readonly byte[] bytes;

        [JsonIgnore]
        protected readonly bool isByteArray;

        [JsonIgnore]
        protected readonly bool leaveOpen;

        [JsonIgnore]
        protected readonly Stream stream;

        [JsonIgnore]
        protected string file = string.Empty;

        protected ElementFile(ElementType type, string url) : base(type)
        {
            file = url;
            bytes = Array.Empty<byte>();
            stream = Stream.Null;
            leaveOpen = true;
        }

        protected ElementFile(ElementType type, ReadOnlySpan<byte> bytes) : base(type)
        {
            isByteArray = true;
            this.bytes = bytes.ToArray();
            stream = Stream.Null;
            leaveOpen = true;
        }

        protected ElementFile(ElementType type, Stream stream, bool leaveOpen = false) : base(type)
        {
            isByteArray = false;
            this.stream = stream;
            bytes = Array.Empty<byte>();
            this.leaveOpen = leaveOpen;
        }

        public override bool IsValid => !string.IsNullOrEmpty(file) || isByteArray ? bytes.Length > 0 : stream.CanRead;

        [JsonIgnoreIfDefault]
        [DefaultValue("")]
        [JsonPropertyName("url")]
        public virtual string Url { get; set; } = string.Empty;

        [JsonIgnoreIfDefault]
        [DefaultValue(1)]
        [JsonPropertyName("cache")]
        public virtual int Cache { get; set; } = 1;

        [JsonIgnoreIfDefault]
        [DefaultValue(1)]
        [JsonPropertyName("proxy")]
        public virtual int Proxy { get; set; } = 1;

        [JsonIgnoreIfDefault]
        [DefaultValue(0)]
        [JsonPropertyName("timeout")]
        public virtual int Timeout { get; set; } = 0;

        [JsonPropertyName("file")]
        public virtual string File
        {
            get
            {
                if (!string.IsNullOrEmpty(file))
                {
                    return file;
                }

                if (isByteArray)
                {
                    file = ZString.Concat(BASE64_PREFIX, Base64.Default.Encode(bytes));
                }
                else
                {
                    file = ZString.Concat(BASE64_PREFIX, stream.ToBase64String());
                    if (!leaveOpen)
                    {
                        stream.Dispose();
                    }
                }

                return file;
            }
        }
    }
}