using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Dahomey.Json.Attributes;
using Jotaro.Shared.OneBot.Elements;
using Jotaro.Shared.OneBot.Posts.Interfaces;
using Jotaro.Shared.Utils;

namespace Jotaro.Shared.OneBot.Posts.Messages
{
    public class PostMessage : Post, IPostHasTime, IPostHasSelfId
    {
        [JsonPropertyName("message_id")]
        public int MessageId { get; set; }

        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("message_type")]
        public MessageType MessageType { get; set; }

        [JsonPropertyName("message")]
        public IList<Element> Message { get; set; } = Array.Empty<Element>();

        [JsonPropertyName("raw_message")]
        public string RawMessage { get; set; } = string.Empty;

        [JsonPropertyName("font")]
        public string Font { get; set; } = string.Empty;

        // @TODO: Implement PostMessage and Sub types.

        [JsonIgnoreIfDefault]
        [DefaultValue(0)]
        [JsonPropertyName("self_id")]
        public long SelfId { get; set; }

        [JsonConverter(typeof(UnixTimestampJsonConverter))]
        [JsonPropertyName("time")]
        public DateTimeOffset Time { get; set; }
    }
}