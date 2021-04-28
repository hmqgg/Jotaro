using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Posts
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum PostType
    {
        Unknown,

        [EnumMember(Value = "message")]
        Message,

        [EnumMember(Value = "notice")]
        Notice,

        [EnumMember(Value = "request")]
        Request
    }
}