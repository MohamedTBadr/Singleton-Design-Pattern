namespace Singleton_Design_Pattern
{
    public class LogMessage
    {
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }=DateTime.UtcNow;
        public string LogType { get; set; }
    }
}