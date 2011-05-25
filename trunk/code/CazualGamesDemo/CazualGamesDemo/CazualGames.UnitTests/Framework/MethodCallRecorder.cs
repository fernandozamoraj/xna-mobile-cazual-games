using System.Collections.Generic;

namespace CazualGames.UnitTests.FrameWork
{
    public class MethodCallRecorder : IMethodCallRecorder
    {
        private Dictionary<string, int> _callLog;

        public MethodCallRecorder()
        {
            _callLog = new Dictionary<string, int>();
        }

        public Dictionary<string, int> CallLog
        {
            get { return _callLog; }
        }

        public int GetMethodCallCount(string methodName)
        {
            int numberOfCalls = 0;

            if(_callLog.ContainsKey(methodName))
            {
                numberOfCalls = _callLog[methodName];
            }

            return numberOfCalls;
        }

        public void RegisterMethodCall(string methodName)
        {
            if(!_callLog.ContainsKey(methodName))
            {
                _callLog.Add(methodName, 0);
            }

            _callLog[methodName]++;
        }
    }
}