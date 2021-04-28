using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Jotaro.Shared.OneBot.Elements
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum ElementType
    {
        [EnumMember(Value = "empty")]
        Empty,

        [EnumMember(Value = "text")]
        Text,

        [EnumMember(Value = "image")]
        Image,

        [EnumMember(Value = "record")]
        Record,

        [EnumMember(Value = "at")]
        At,

        [EnumMember(Value = "reply")]
        Reply,

        [EnumMember(Value = "face")]
        Face,

        [EnumMember(Value = "share")]
        Share,

        [EnumMember(Value = "music")]
        Music,

        [EnumMember(Value = "video")]
        Video,

        [EnumMember(Value = "gift")]
        Gift,

        [EnumMember(Value = "redbag")]
        RedBag,

        [EnumMember(Value = "poke")]
        Poke,

        [EnumMember(Value = "forward")]
        Forward,

        [EnumMember(Value = "node")]
        Node,

        [EnumMember(Value = "tts")]
        Tts,

        /*
         * Not Implemented.
         */

        [EnumMember(Value = "xml")]
        Xml,

        [EnumMember(Value = "json")]
        Json,

        [EnumMember(Value = "cardimage")]
        CardImage
    }
}