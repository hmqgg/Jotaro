using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Elements
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum ElementMusicType
    {
        [EnumMember(Value = "qq")]
        Qq = 0,

        [EnumMember(Value = "163")]
        NetEase = 1,

        [EnumMember(Value = "xm")]
        Xm = 2,

        [EnumMember(Value = "custom")]
        Custom = 3
    }
}