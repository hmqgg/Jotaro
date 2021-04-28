using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Posts
{
    public abstract class Post
    {
        [DefaultValue(PostType.Unknown)]
        [JsonPropertyName("post_type")]
        public PostType PostType { get; set; } = PostType.Unknown;
    }
}