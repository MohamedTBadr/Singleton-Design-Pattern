using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton_Design_Pattern
{
    public class MemoryLog
    {
        private int _ErrorCount = 0;
        private int _WarningCount = 0;
        private int _MessageCount = 0;
        private static readonly Lazy<MemoryLog> _instance =
            new Lazy<MemoryLog>(() => new MemoryLog());


        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Error Count: {_ErrorCount}");
            stringBuilder.AppendLine($"Warning Count: {_WarningCount}");
            stringBuilder.AppendLine($"Message Count: {_MessageCount}");
            stringBuilder.AppendLine($"Log Messages: {string.Join(", ", _logMessages.Select(m => m.Message))}");
            return stringBuilder.ToString();
        }

        private List<LogMessage> _logMessages = new List<LogMessage>();
        private IReadOnlyCollection<LogMessage> _logMessagesReadOnly => _logMessages;
        private static readonly object _lock = new object(); 



        private void AddLogMessage(string logMessage, string logType)
        {
            _logMessages.Add(new LogMessage
            {
                Message = logMessage,
                LogType = logType,
                Timestamp = DateTime.UtcNow
            });
        }


        private MemoryLog()
        {
        }
        public static MemoryLog GetInstance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void LogError(string message)
        {
            _ErrorCount++;
            AddLogMessage(message, "Error");
            Console.WriteLine($"Error: {message}");
        }
        public void LogWarning(string message)
        {
            _WarningCount++;
            AddLogMessage(message, "Warning");
            Console.WriteLine($"Warning: {message}");
        }
        public void LogMessage(string message)
        {
            _MessageCount++;
            AddLogMessage(message, "Message");
            Console.WriteLine($"Message: {message}");
        }
    }

}
