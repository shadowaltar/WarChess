
namespace Engine.Logic.Logging;
public class Log
{
    public static void Info(string str)
    {
        Console.WriteLine("[INFO] " + str);
    }

    public static void Error(string str)
    {
        Console.WriteLine("[ERR ] " + str);
    }
}
