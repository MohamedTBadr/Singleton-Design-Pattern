


using Singleton_Design_Pattern;

public class Program
{
    public static void Main(string[] args)
    {
        var log1 = MemoryLog.GetInstance;
        Console.WriteLine($"Log1 Instance ID: {log1.GetHashCode()}");
     




        var log2 = MemoryLog.GetInstance;
        Console.WriteLine($"Log2 Instance ID: {log2.GetHashCode()}");
     




        Console.WriteLine(MemoryLog.ReferenceEquals(log1, log2)
            ? "log1 and log2 are the same instance."
            : "log1 and log2 are different instances.");
    }
}