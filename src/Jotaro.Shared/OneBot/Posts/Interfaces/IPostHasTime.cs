using System;

namespace Jotaro.Shared.OneBot.Posts.Interfaces
{
    public interface IPostHasTime
    {
        DateTimeOffset Time { get; set; }
    }
}