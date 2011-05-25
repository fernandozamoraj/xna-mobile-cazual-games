using System.Collections.Generic;

namespace CazualGames.UnitTests.FrameWork
{
    public interface IMethodCallRecorder
    {
        Dictionary<string, int> CallLog { get; }
        int GetMethodCallCount(string methodName);
        void RegisterMethodCall(string methodName);
    }
}