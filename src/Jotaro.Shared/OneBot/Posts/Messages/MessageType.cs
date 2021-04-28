using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Posts.Messages
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum MessageType
    {
        [EnumMember(Value = "private")]
        Private,

        [EnumMember(Value = "group")]
        Group
    }
}