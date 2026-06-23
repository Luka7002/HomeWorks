using System;
using System.IO;

static class Logger
{
    public static void Log(string message)
    {
        try
        {
            File.AppendAllText("log.txt", DateTime.Now + " - " + message + "\n");
        }
        catch
        {
        }
    }
}
