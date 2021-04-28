using System.Text.Json;
using Jotaro.Shared.OneBot.Elements;
using Jotaro.Shared.OneBot.Elements.ElementData;
using Xunit;

namespace Jotaro.Shared.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var text = new ElementMusic(ElementMusicType.Qq, "1234");
            var json = JsonSerializer.Serialize<Element>(text);
            Assert.NotNull(json);
        }

        [Fact]
        public void Test2()
        {
            var json = "{\"type\":\"share\",\"data\":{\"url\":\"www.baidu.com\"}}";
            var element = JsonSerializer.Deserialize<Element>(json);

            Assert.NotNull(element);
        }
    }
}