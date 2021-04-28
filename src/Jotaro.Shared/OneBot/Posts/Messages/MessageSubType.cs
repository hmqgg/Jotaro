using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Posts.Messages
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum MessageSubType
    {
        [EnumMember(Value = "normal")]
        Normal,

        [EnumMember(Value = "anonymous")]
        Anonymous,

        [EnumMember(Value = "notice")]
        Notice
    }
}